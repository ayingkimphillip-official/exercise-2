using System;

class Person
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Account{ get; set; }

    public float AccountBalance { get; set; }

    public void AccountGenerator()
    {  
        Account = new Random().Next(0,999999);
        Console.WriteLine(Account);
    }
}