using System;

class BankOfAying
{
    private Account[] Accounts { get; set; }
    private int IndexInAccount { get; set; } = 0;

    public BankOfAying()
    {
        Accounts = new Account[10];
        for(int i = 0; i < Accounts.Length; i++) Accounts[i] = new Account();
        Console.WriteLine("Welcome to Bank of Aying");
    }

    public Guid Registration(string name, string username, string password)
    {
        Guid AccountIDHolder;
        Accounts[IndexInAccount].Name = name;
        Accounts[IndexInAccount].Password = password;
        Accounts[IndexInAccount].Username = UniqueUsernameFinder(username);
       
        if(Accounts[IndexInAccount].Username != username)
        {
            AccountIDHolder = Accounts[IndexInAccount].AccountID;
            Console.Clear();
            Console.WriteLine("Username already taken. Please enter another one.");
        }
        else
        {
            Accounts[IndexInAccount].AccountID = Guid.NewGuid();
            AccountIDHolder = Accounts[IndexInAccount].AccountID;
            Console.Clear();
            Console.WriteLine($"Congratulations {name} for a successful registration.");
            Console.WriteLine($"You have been assigned with Account ID: {AccountIDHolder}");
            IndexInAccount++;
        }
        return AccountIDHolder;
    }

    public string UniqueUsernameFinder(string username)
    {
        for (int i = 0; i < Accounts.Length; i++)
        {
            if (Accounts[i].Username == null)
            {
                Accounts[i].Username = username;
                break;
            }
            else if (Accounts[i].Username != null && Accounts[i].Username == username)
            {
                break;
            }
        }
        return Accounts[IndexInAccount].Username;
    }

    public Account Login(string username, string password)
    {
        for (int i = 0; i < Accounts.Length; i++)
        {
            if (Accounts[i].Username == username && Accounts[i].Password == password)
            {
                return Accounts[i];
            }
        }
        return null;
    }

    public Account Deposit(float deposit, Guid AccountID)
    {
        for (int i = 0; i < Accounts.Length; i++)
        {
            if (Accounts[i].AccountID == AccountID)
            {
                Accounts[i].AccountBalance = Accounts[i].AccountBalance + deposit;
                return Accounts[i];
            }
        }
        return null;
    }

    public Account Withdraw(float withdraw, Guid AccountID)
    {
        for (int i = 0; i < Accounts.Length; i++)
        {
            if (Accounts[i].AccountID == AccountID)
            {
                if (Accounts[i].AccountBalance >= withdraw)
                {
                    Accounts[i].AccountBalance = Accounts[i].AccountBalance - withdraw;
                    return Accounts[i];
                }
                else
                {
                    Console.WriteLine("Insufficient funds. Please try again.");
                    break;
                }
            }
        }
        return null;
    }

    public Account OtherAccountIDFinder(Guid otherAccountID)
    {
        for (int i = 0; i < Accounts.Length; i++)
        {
            if (Accounts[i].AccountID == otherAccountID)
            {
                return Accounts[i];
            }
        }
        return null;
    }
}

