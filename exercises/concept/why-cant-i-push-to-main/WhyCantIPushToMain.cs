using System;
using System.Collections.Generic;

public class Authenticator
{
    // TODO: Impleent the Authenticator.Admin property
    public Identity Admin { get; }

    // TODO: Impleent the Authenticator.Developers property
    public IDictionary<string, Identity> Developers { get; }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}
