using System;

class BankOfAying
{
    public Account[] listOfAccounts { get; set; }
    private int indexInAccount { get; set; } = 0;

    public void BankOfAyingAccounts()
    {
        listOfAccounts = new Account[10];
        for (var i = 0; i < listOfAccounts.Length; i++)
        {
            listOfAccounts[i] = new Account();
        }
    }

    public string getWelcomeMessage()
    {
        return "Hello User! Welcome to Bank of Aying!";
    }

    public Guid Registration(string name, string username, string password)
    {
        listOfAccounts[indexInAccount].Name = name;
        listOfAccounts[indexInAccount].Username = username;
        listOfAccounts[indexInAccount].Password = password;
        indexInAccount++;

        return listOfAccounts[indexInAccount].AccountID;
    }

    public Account LoginActions(string username, string password)
    {
        foreach (Account totalAccounts in listOfAccounts)
        {
            if (totalAccounts.Username == username && totalAccounts.Password == password)
            {
                return totalAccounts;
            }
        }
        return null;
    }

    public Account ActionList(string action, float input, Guid ownAccountID, Guid otherAccount)
    {
        switch (action)
        {
            case "1":
                for (int i = 0; i < listOfAccounts.Length; i++)
                {
                    if (listOfAccounts[i].AccountID == ownAccountID)
                    {
                        Console.WriteLine($"Your Account Balance is: {listOfAccounts[i].AccountBalance}");
                    }
                }
                break;
            case "2":
                for (int i = 0; i < listOfAccounts.Length; i++)
                {
                    if (listOfAccounts[i].AccountID == ownAccountID)
                    {
                        Deposit(input, ownAccountID);
                    }
                }
                break;
            case "3":
                for (int i = 0; i < listOfAccounts.Length; i++)
                {
                    if (listOfAccounts[i].AccountID == ownAccountID)
                    {
                        Withdraw(input, ownAccountID);
                    }
                }
                break;
            case "4":
                for (int i = 0; i < listOfAccounts.Length; i++)
                {
                    if (listOfAccounts[i].AccountID == otherAccount)
                    {
                        DepositToAnotherAccount(input, ownAccountID, otherAccount);
                        // Console.WriteLine($"Your updated Account Balance is: {listOfAccounts[i].AccountBalance}");
                    }
                }
                break;
        }
        return null;
    }

    public Account[] Deposit(float input, Guid ownAccountID)
    {
        for (int i = 0; i < listOfAccounts.Length; i++)
        {
            if (listOfAccounts[i].AccountID == ownAccountID)
            {
                listOfAccounts[i].AccountBalance = listOfAccounts[i].AccountBalance + input;
                Console.WriteLine($"Your updated Account Balance is: {listOfAccounts[i].AccountBalance}");
            }
        }
        return listOfAccounts;
    }

    public Account[] Withdraw(float input, Guid ownAccountID)
    {
        for (int i = 0; i < listOfAccounts.Length; i++)
        {
            if (listOfAccounts[i].AccountID == ownAccountID && listOfAccounts[i].AccountBalance >= input)
            {
                listOfAccounts[i].AccountBalance = listOfAccounts[i].AccountBalance - input;
                Console.WriteLine($"Your updated Account Balance is: {listOfAccounts[i].AccountBalance}");
                break;
            }
            else
            {
                Console.WriteLine("Insufficient Funds. Please try again.");
                break;
            }
        }
        return listOfAccounts;
    }

    public Account DepositToAnotherAccount(float input, Guid ownAccountID, Guid otherAccountID)
    {
        Deposit(input, otherAccountID);
        Withdraw(input, ownAccountID);
        return null;
    }
}