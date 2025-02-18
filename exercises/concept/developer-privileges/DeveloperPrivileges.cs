public class Authenticator
{
    // TODO: Implement the Authenticator.Admin property
    public Identity Admin { get; }

    // TODO: Implement the Authenticator.Developers property
    public IDictionary<string, Identity> Developers { get; }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public required string EyeColor { get; set; }
    public required decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public required string Email { get; set; }
    public required FacialFeatures FacialFeatures { get; set; }
    public required IList<string> NameAndAddress { get; set; }
}
