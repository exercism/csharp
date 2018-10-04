using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class User
{
    public string Name { get; }
    public IDictionary<string, double> Owes { get; }
    public IDictionary<string, double> Owed_By { get; }
    public double Balance { get; set; }

    public User(string name)
    {
        Name = name;
        Owes = new Dictionary<string, double>();
        Owed_By = new Dictionary<string, double>();
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
        throw new NotImplementedException("You need to implement this function.");
    }

    public string Post(string url, string payload)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
