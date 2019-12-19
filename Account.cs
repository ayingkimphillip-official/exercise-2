using System;

class Account
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid AccountID {get; set;} = Guid.NewGuid();
    public float AccountBalance { get; set; } = 0.0f;

}