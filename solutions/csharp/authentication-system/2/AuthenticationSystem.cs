using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{

    private const string EyeColorBlue = "blue";
    private const string EyeColorBrown = "brown";

    private readonly Identity admin;


    private readonly IDictionary<string, Identity> developers = new Dictionary<string, Identity>
    {
        ["Bertrand"] = new Identity
        {
            Email = "bert@ex.ism",
            EyeColor = EyeColorBlue
        },
        ["Anders"] = new Identity
        {
            Email = "anders@ex.ism",
            EyeColor = EyeColorBrown
        }
    };

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    public Identity Admin => this.admin;


    public IDictionary<string, Identity> GetDevelopers() => new ReadOnlyDictionary<string, Identity>(this.developers);
}


public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}
