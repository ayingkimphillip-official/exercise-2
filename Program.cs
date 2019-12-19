using System;

namespace Bank_Aying
{
    class Program
    {
        public static void Main(string[] args)
        {
            var bank = new BankOfAying();
            bank.BankOfAyingAccounts();
            string name = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            bool continueloop = true;

            while (continueloop)
            {
                Console.Clear();
                bank.getWelcomeMessage();

                Console.WriteLine("Please Enter 1.) To Register, 2.) To Login, e.) To Exit.");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("[REGISTRATION]");
                        Console.WriteLine("Please enter your Name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Please enter Username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Please enter Password: ");
                        password = Console.ReadLine();

                        var bankID = bank.Registration(name, username, password);
                        Console.WriteLine($"CONGRATULATIONS! Account ID for {name}: {bankID}");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("[LOGIN]");
                        Console.WriteLine("Please enter Username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Please enter Password: ");
                        password = Console.ReadLine();
                        var bankAccount = bank.LoginActions(username, password);
                        // bool withinAccount = true;


                        if (bankAccount != null)
                        {
                            Console.Clear();
                            bool continueWithinAccount = true;
                            while (continueWithinAccount)
                            {
                                Console.Clear();
                                Console.WriteLine($"Welcome {bankAccount.Name}: {bankAccount.AccountID}!");
                                Console.WriteLine("What would it be for today?");
                                Console.Write("1.) View Balance; 2.) Deposit to own account; 3.) Withdraw; 4.) Deposit to another account; 5.) Logout: ");
                                string loginAction = Console.ReadLine();
                                switch (loginAction)
                                {
                                    case "1":
                                        Console.Clear();
                                        bank.ActionList(loginAction, 0.0f, bankAccount.AccountID, bankAccount.AccountID);
                                        Console.ReadKey();
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine("You have chosen to deposit to your own account. Please enter amount to Deposit: ");
                                        bank.ActionList(loginAction, float.Parse(Console.ReadLine()), bankAccount.AccountID, bankAccount.AccountID);
                                        Console.ReadKey();
                                        break;
                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine("You have chosen to withdraw from your own account. Please enter amount to Withdraw: ");
                                        bank.ActionList(loginAction, float.Parse(Console.ReadLine()), bankAccount.AccountID, bankAccount.AccountID);
                                        Console.ReadKey();
                                        break;
                                    case "4":
                                        Console.Clear();
                                        Console.WriteLine("You have chosen to deposit to another account.");
                                        Console.WriteLine("Please input the Account ID you wish to deposit to: ");
                                        var anotherAccountID = Guid.Parse(Console.ReadLine());
                                        Console.WriteLine("Please input the amount you wish to deposit to: ");
                                        var amountOfDeposit = float.Parse(Console.ReadLine());
                                        bank.ActionList(loginAction, amountOfDeposit, bankAccount.AccountID, anotherAccountID);
                                        Console.ReadKey();
                                        break;
                                    case "5":
                                        Console.Clear();
                                        Console.WriteLine("You have chosen to Logout. Please back again.");
                                        continueWithinAccount = false;
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
                            Console.WriteLine("You have entered an invalid account. Please try again.");
                            Console.ReadKey();
                        }
                        Console.ReadKey();
                        break;
                    case "e":
                        Console.Clear();
                        Console.WriteLine("You have chosen to Exit. See you again soon!");
                        continueloop = false;
                        break;
                    default:
                        Console.WriteLine("You have entered invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
