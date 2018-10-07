using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class User
{
    public string name { get; }
    public IDictionary<string, double> owes { get; private set; }
    public IDictionary<string, double> owed_by { get; private set; }
    public double balance => owed_by.Sum(x => x.Value) - owes.Sum(x => x.Value);

    public User(string name)
    {
        this.name = name;
        owes = new Dictionary<string, double>();
        owed_by = new Dictionary<string, double>();
    }

    public void Lend(User borrower, double amount)
    {
        var remaining = amount;
        if (owes.ContainsKey(borrower.name))
        {
            remaining = owes[borrower.name] - amount;
            if (remaining > 0)
            {
                owes[borrower.name] = remaining;
                return;
            }

            owes.Remove(borrower.name);
            remaining *= -1;
        }

        if (remaining > 0)
        {
            if (owed_by.ContainsKey(borrower.name))
            {
                owed_by[borrower.name] += remaining;
            }
            else
            {
                owed_by.Add(borrower.name, remaining);
                owed_by = owed_by.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }

    public void Borrow(User lender, double amount)
    {
        var remaining = amount;
        if (owed_by.ContainsKey(lender.name))
        {
            remaining = owed_by[lender.name] - amount;
            if (remaining > 0)
            {
                owed_by[lender.name] = remaining;
                return;
            }

            owed_by.Remove(lender.name);
            remaining *= -1;
        }

        if (remaining > 0)
        {
            if (owes.ContainsKey(lender.name))
            {
                owes[lender.name] += remaining;
            }
            else
            {
                owes.Add(lender.name, remaining);
                owes = owes.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}

public class RestApi
{
    private IList<User> users;

    public RestApi(string database)
    {
        users = JsonConvert.DeserializeObject<List<User>>(database);
    }

    public string Get(string url, string payload = null)
    {
        if (payload != null)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(payload);
            var requestedUsers = values["users"];
            return JsonConvert.SerializeObject(users.Where(x => requestedUsers.Contains(x.name)));
        }

        return JsonConvert.SerializeObject(users);
    }

    public string Post(string url, string payload)
    {
        if (url == "/add")
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(payload);
            var newUser = new User(values["user"]);
            users.Add(newUser);
            return JsonConvert.SerializeObject(newUser);
        }
        else if (url == "/iou")
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(payload);
            var lender = users.First(x => x.name.Equals(values["lender"]));
            var borrower = users.First(x => x.name.Equals(values["borrower"]));
            var amount = (double)values["amount"];
            lender.Lend(borrower, amount);
            borrower.Borrow(lender, amount);

            return JsonConvert.SerializeObject(new[] { lender, borrower }.OrderBy(x => x.name));
        }

        return String.Empty;
    }
}
