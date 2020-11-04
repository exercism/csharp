using System.Collections.Generic;

public class Authenticator
{
    private class EyeColor
    {
        public string Blue = "blue";
        public string Green = "green";
        public string Brown = "brown";
        public string Hazel = "hazel";
        public string Brey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    private Identity admin;

    private IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin
    {
        get { return admin; }
        set { admin = value; }
    }

    public IDictionary<string, Identity> GetDevelopers()
    {
        return developers;
    }
}

public struct Identity
{
    public string Email { get; set; }

    public string EyeColor { get; set; }
}
