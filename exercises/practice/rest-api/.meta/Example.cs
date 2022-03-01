using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class User
{
    public string name { get; }
    public IDictionary<string, double> owes { get;  set; }
    public IDictionary<string, double> owed_by { get;  set; }
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
        users = JsonSerializer.Deserialize<List<User>>(database);
    }

    public string Get(string url, string payload = null)
    {
        if (payload != null)
        {
            var values = JsonSerializer.Deserialize<Dictionary<string, IEnumerable<string>>>(payload);
            var requestedUsers = values["users"];
            return JsonSerializer.Serialize(users.Where(x => requestedUsers.Contains(x.name)));
        }

        return JsonSerializer.Serialize(users);
    }

    public string Post(string url, string payload)
    {
        if (url == "/add")
        {
            var values = JsonSerializer.Deserialize<Dictionary<string, string>>(payload);
            var newUser = new User(values["user"]);
            users.Add(newUser);
            return JsonSerializer.Serialize(newUser);
        }
        else if (url == "/iou")
        {
            var values = JsonSerializer.Deserialize<Dictionary<string, object>>(payload);
            var lender = users.First(x => x.name.Equals(values["lender"].ToString()));
            var borrower = users.First(x => x.name.Equals(values["borrower"].ToString()));
            var amount = double.Parse(values["amount"].ToString());
            lender.Lend(borrower, amount);
            borrower.Borrow(lender, amount);

            return JsonSerializer.Serialize(new[] { lender, borrower }.OrderBy(x => x.name));
        }

        return String.Empty;
    }
}
