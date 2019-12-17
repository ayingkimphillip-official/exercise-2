using System;

namespace Bank_Aying
{
    static class Globals
    {
        public static Person[] listOfUsers = new Person[5];
        public static bool starter = true;
    }

    class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < Globals.listOfUsers.Length; i++)
            {
                Globals.listOfUsers[i] = new Person();
            }
            
            int numberOfAccounts = 0;
            int inputOfAccounts = 0;
            while (Globals.starter)
            {
                Console.WriteLine("Hello User! Welcome to Bank of Aying!");
                Console.WriteLine("Please input 1: To Register and 2: To Login and e: To Exit");
                string userInitialAction = Console.ReadLine();
                
                switch (userInitialAction.ToLower())
                {
                    case ("1"):
                        Console.WriteLine("You have chosen to Register.");
                        Console.WriteLine("How many accounts do you wish to register?");
                        
                        int number = int.Parse(Console.ReadLine());
                        numberOfAccounts = numberOfAccounts + number;
                        inputOfAccounts = inputOfAccounts + number;
                        
                        if (inputOfAccounts <= Globals.listOfUsers.Length)
                        {
                            Registration(number, inputOfAccounts);
                            // for (int i = 0; i < Globals.listOfUsers.Length; i++)
                            // {
                            //     Console.WriteLine($"User{i + 1} Name: {Globals.listOfUsers[i].Name}");
                            //     Console.WriteLine($"User{i + 1} Username: {Globals.listOfUsers[i].Username}");
                            //     Console.WriteLine($"User{i + 1} Password: {Globals.listOfUsers[i].Password}");
                            //     Console.WriteLine($"User{i + 1} Account Number: {Globals.listOfUsers[i].Account}");
                            // }
                        }
                        else
                        {
                            Console.WriteLine("Number of entries exceed the storage capacity. Please try again.");
                        }
                        break;
                    case ("2"):
                        Console.WriteLine("You have chosen to Login.");
                        LoginActions();
                        break;
                    case ("e"):
                        Console.WriteLine("You have chosen to Exit. See you again soon!");
                        Globals.starter = false;
                        break;
                    default:
                        Console.WriteLine("You have entered an invalid input. Please try again.");
                        continue;
                }
            }
        }

        public static int Registration(int number, int inputOfAccounts)
        {
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Please Enter name: ");
                Globals.listOfUsers[i].Name = Console.ReadLine();
                Console.WriteLine("Please Enter username: ");
                Globals.listOfUsers[i].Username = Console.ReadLine();
                Console.WriteLine("Please Enter password: ");
                Globals.listOfUsers[i].Password = Console.ReadLine();
                Globals.listOfUsers[i].Account = new Random().Next(0, 999999);
                
            }

            for (int i = 0; i < Globals.listOfUsers.Length; i++)
            {
                Console.WriteLine($"User{i + 1} Name: {Globals.listOfUsers[i].Name}");
                Console.WriteLine($"User{i + 1} Username: {Globals.listOfUsers[i].Username}");
                Console.WriteLine($"User{i + 1} Password: {Globals.listOfUsers[i].Password}");
                Console.WriteLine($"User{i + 1} Account Number: {Globals.listOfUsers[i].Account}");

            }

            return inputOfAccounts;
        }

        public static void LoginActions()
        {
            bool continueAction = true;
            Console.WriteLine($"User[0]: {Globals.listOfUsers[0].Name}");
            Console.WriteLine($"User[1]: {Globals.listOfUsers[1].Name}");
            Console.WriteLine("Please enter Username: ");
            string holderUsername = Console.ReadLine();
            Console.WriteLine("Please enter Password: ");
            string holderPassword = Console.ReadLine();

            
                for (int i = 0; i < Globals.listOfUsers.Length; i++)
                {
                    if (holderUsername == Globals.listOfUsers[i].Username)
                    {
                        Console.WriteLine($"Input username: {holderUsername}");
                        Console.WriteLine("You have entered the correct username.");

                        if (holderPassword == Globals.listOfUsers[i].Password)
                        {
                            Console.WriteLine($"Input password: {holderPassword}");
                            Console.WriteLine("You have entered the correct password.");

                            while (continueAction == true)
                            {
                                Console.WriteLine($"Welcome {Globals.listOfUsers[i].Name}!!");
                                Console.WriteLine("Please input 1: To Deposit to own account, 2: To Withdraw; 3: To Deposit to another account; e: to exit");

                                string action = Console.ReadLine();
                                float accountBalance;

                                switch (action.ToLower())
                                {
                                    case ("1"):
                                        Console.WriteLine("You chose to Deposit to your own account.");
                                        Console.WriteLine("Please enter amount you wish to deposit: ");
                                        accountBalance = float.Parse(Console.ReadLine());
                                        Globals.listOfUsers[i].AccountBalance = Globals.listOfUsers[i].AccountBalance + accountBalance;
                                        Console.WriteLine($"You have deposited Php {accountBalance} to your account ({Globals.listOfUsers[i].Account})");
                                        Console.WriteLine($"Your updated Account Balance for your Account Number ({Globals.listOfUsers[i].Account}) is: {Globals.listOfUsers[i].AccountBalance}");

                                        break;

                                    case ("2"):
                                        Console.WriteLine("You chose to Withdraw from your own account.");
                                        Console.WriteLine("Please enter amount you wish to withdraw: ");
                                        accountBalance = float.Parse(Console.ReadLine());
                                        if (Globals.listOfUsers[i].AccountBalance < accountBalance)
                                        {
                                            Console.WriteLine("Insufficient Funds. Please try again.");
                                        }
                                        else
                                        {
                                            Globals.listOfUsers[i].AccountBalance = Globals.listOfUsers[i].AccountBalance - accountBalance;
                                            Console.WriteLine($"You have withdrawn Php {accountBalance} to your account ({Globals.listOfUsers[i].Account})");
                                            Console.WriteLine($"Your updated Account Balance for your Account Number ({Globals.listOfUsers[i].Account}) is: {Globals.listOfUsers[i].AccountBalance}");
                                        }
                                        
                                        break;
                                        
                                    case ("3"):
                                        Console.WriteLine("You chose to Deposit to your another account.");
                                        Console.WriteLine("Please enter account number you wish to deposit to: ");
                                        int depositee = int.Parse(Console.ReadLine());

                                        for (int j = 0; j < Globals.listOfUsers.Length; j++)
                                        {
                                            if (depositee == Globals.listOfUsers[j].Account)
                                            {
                                                Console.WriteLine("Account number entered found in database. How much do you want to deposit to this account?");
                                                accountBalance = float.Parse(Console.ReadLine());
                                                Globals.listOfUsers[j].AccountBalance = Globals.listOfUsers[i].AccountBalance + accountBalance;
                                                Console.WriteLine($"You have deposited to Account Number ({Globals.listOfUsers[j].Account}) an amount of: {Globals.listOfUsers[j].AccountBalance}");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Account number entered not in database. Please try again.");
                                                break;
                                            }
                                        }

                                    break;

                                    case ("e"):
                                        Console.WriteLine("You have chosen to Exit. See you again soon!");
                                        Globals.starter = false;
                                        continueAction = false;

                                        break;

                                    default:
                                        Console.WriteLine("You have entered an invalid input. Please Try again.");

                                        break;
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Input username: {holderUsername}");
                            Console.WriteLine($"Input password: {holderPassword}");
                            Console.WriteLine("You have entered incorrect credentials. Please try again.");
                            break;
                        }
                    }
                }
            Globals.starter = false;
        }
    }
}
