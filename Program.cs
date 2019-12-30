using System;

class Program
{
    static void Main(string[] args)
    {
        var bank = new BankOfAying();
        bool loopbank = true;
        string Name = string.Empty;
        string Username = string.Empty;
        string Password = string.Empty;

        while (loopbank)
        {
            Console.Clear();
            Console.WriteLine("Please Enter Type of Action: ");
            Console.WriteLine("1.) Register");
            Console.WriteLine("2.) Login");
            Console.WriteLine("E.) Exit");
            switch (Console.ReadLine().ToUpper())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("[REGISTER]");
                    Console.WriteLine("Please enter Name: ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Please enter Username: ");
                    Username = Console.ReadLine();
                    Console.WriteLine("Please enter Password: ");
                    Password = PasswordMasking();
                    var ID = bank.Registration(Name, Username, Password);

                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("[LOGIN]");
                    Console.WriteLine("Please enter Username: ");
                    Username = Console.ReadLine();
                    Console.WriteLine("Please enter Password: ");
                    Password = PasswordMasking();
                    var account = bank.Login(Username, Password);

                    if (account != null)
                    {
                        Console.Clear();
                        bool loginloop = true;
                        float deposit;
                        float withdraw;
                        float depositOtherAccount;
                        Guid otherAccountID;

                        while (loginloop == true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome back {account.Name}: {account.AccountID}");
                            Console.WriteLine("What do you plan to do today?");
                            Console.WriteLine("1.) View Balance");
                            Console.WriteLine("2.) Deposit");
                            Console.WriteLine("3.) Withdraw");
                            Console.WriteLine("4.) Deposit to other account");
                            Console.WriteLine("5.) Logout");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine($"Your Account Balance is: Php {account.AccountBalance}");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to Deposit to your own Account.");
                                    Console.WriteLine("How much would you like to Deposit?");
                                    bool isdepositfloat = float.TryParse(Console.ReadLine(), out deposit);

                                    if (isdepositfloat == true)
                                    {
                                        Console.Clear();
                                        var depositAccount = bank.Deposit(deposit, account.AccountID);
                                        Console.WriteLine($"Your updated Account Balance is: Php {depositAccount.AccountBalance}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect values for amount. Please try again.");
                                    }

                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to Withdraw from your own Account.");
                                    Console.WriteLine("How much would you like to Withdraw?");
                                    bool iswithdrawfloat = float.TryParse(Console.ReadLine(), out withdraw);

                                    if (iswithdrawfloat == true)
                                    {
                                        Console.Clear();
                                        var withdrawAccount = bank.Withdraw(withdraw, account.AccountID);
                                        Console.WriteLine($"Your updated Account Balance is: Php {withdrawAccount.AccountBalance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect values for amount. Please try again.");
                                    }

                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to Deposit to another Account.");
                                    Console.WriteLine("Please input the Account ID of the Account you want to Deposit to.");
                                    bool isOtherAccountGuid = Guid.TryParse(Console.ReadLine(), out otherAccountID);

                                    if (isOtherAccountGuid == true)
                                    {
                                        var otherAccount = bank.OtherAccountIDFinder(otherAccountID);

                                        if (otherAccount != null)
                                        {
                                            Console.WriteLine("How much would you like to Deposit?");
                                            bool isAmountFloat = float.TryParse(Console.ReadLine(), out depositOtherAccount);

                                            if (isAmountFloat == true)
                                            {
                                                if (account.AccountBalance >= depositOtherAccount)
                                                {
                                                    bank.Withdraw(depositOtherAccount, account.AccountID);
                                                    bank.Deposit(depositOtherAccount, otherAccount.AccountID);

                                                    Console.Clear();
                                                    Console.WriteLine($"Your updated Balance is: Php {account.AccountBalance}");
                                                    Console.WriteLine($"You have deposited an amount of Php {depositOtherAccount} to Account ID: {otherAccount.AccountID}");
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Insufficient funds. Please input another amount.");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Incorrect values for amount. Please try again.");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("No Account Found. Please try again.");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Incorrect values for account ID. Please try again.");
                                    }

                                    Console.ReadKey();
                                    break;
                                case "5":
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to Logout. See you again soon.");
                                    loginloop = false;
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("You have entered an invalid input. Please try again.");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have entered invalid credentials. Please Try again.");
                    }
                    Console.ReadKey();
                    break;
                case "E":
                    Console.Clear();
                    Console.WriteLine("You have chosen to Exit. See you again soon!");
                    loopbank = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You have entered an invalid input. Please try again.");
                    break;
            }
        }
    }

    public static string PasswordMasking()
    {
        bool continuepassmask = true;
        string password = string.Empty;

        while (continuepassmask == true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length -1));
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    continuepassmask = false;
                }
            }
        }
        return password;
    }
}
