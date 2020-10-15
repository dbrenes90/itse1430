// 09/24/2020
// Daniel Brenes
// Lab 1 
// Budget

using System;

namespace Budget
{
    class Program
    {
        static string accountNumber = "";
        static string nickName = "";
        static decimal startingBalance = 0;
        static void Main ( string[] args )
        {
            Console.WriteLine("Welcome to the Account Budget Program");

            nickName = ReadName();

            accountNumber = ReadAcctNumber();


            startingBalance = ReadBalance();
            // userAccount();
            while (true)
            {
                switch (DisplayMenu())
                {
                    case '2': if (verifyExit()) return; break;
                    case '0': ReadAcctNumber(); break;
                    case '1': ReadBalance(); break;
                    case '3': startingBalance = AddMoney(startingBalance); break;
                    case '4': startingBalance = SubMoney(startingBalance); break;

                }
            }
        }

        private static decimal SubMoney ( decimal startingBalance )
        {
            do
            {
                Console.WriteLine("Enter the Expense amount (to deduct from balance) ");
                string value = Console.ReadLine();


                if (!Decimal.TryParse(value, out decimal subBalance) || subBalance <=0)

                    DisplayError("Value must be greater than 0");
                else if (subBalance < startingBalance)
                {
                    decimal newBalance = startingBalance - subBalance;



                    string description = addDescription();
                    string category = addCategory();
                    string date = addDate();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("--------Success!!----------");
                    Console.WriteLine("Your new account balance is : " + newBalance.ToString("C"));
                    Console.WriteLine("Description for added expense :\t" + description);
                    Console.WriteLine("Category of the expense :\t" + category);
                    Console.WriteLine("Date of the expense: \t\t" + date);
                    return newBalance;
                } else
                    DisplayError("Insufficient Funds");
            } while (true);
        }


        private static decimal AddMoney ( decimal startingBalance )
        {

            do
            {
                Console.WriteLine("Enter the amount you wish to add ");
                string value = Console.ReadLine();


                if (!Decimal.TryParse(value, out decimal addBalance) || addBalance <=0)

                    DisplayError("Value must be greater than 0");
                else
                {
                    decimal newBalance = startingBalance + addBalance;



                    string description = addDescription();
                    string category = addCategory();
                    string date = addDate();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("--------Success!!----------");
                    Console.WriteLine("Your new account balance is : " + newBalance.ToString("C"));
                    Console.WriteLine("Description for added income :\t" + description);
                    Console.WriteLine("Category of the income :\t" + category);
                    Console.WriteLine("Date of the income: \t\t" + date);
                    return newBalance;
                }
            } while (true);
        }

        private static string addDate ()
        {
            do
            {
                Console.WriteLine("Enter the Date in MM/DD/YYYY");
                string value = Console.ReadLine();

                if (DateTime.TryParse(value, out var dates))
                    return value;
                else
                    DisplayError("Not correct format. Enter the numbers with slashes");
            } while (true);
        }

        private static string addCategory ()
        {
            Console.WriteLine("Enter an optional category");
            string category = Console.ReadLine();
            return category;
        }

        private static string addDescription ()
        {
            do
            {
                Console.WriteLine("Enter the description for this income");
                string description = Console.ReadLine();
                if (String.IsNullOrEmpty(description))
                    DisplayError("Cannot be empty");
                else
                    return description;
            } while (true);
        }

        private static bool verifyExit ()
        {
            Console.WriteLine("Are you sure you want to quit?");
            Console.WriteLine("Enter Y for Yes. N for No.");


            string inputValue = Console.ReadLine();
            if (inputValue == "Y"|| inputValue == "y")
                return true;
            else
                return false;



        }

        static char DisplayMenu ()
        {
            do
            {


                Console.WriteLine("------Welcome to the Menu--------");
                Console.WriteLine("----Your Budget Information----");
                Console.WriteLine("Your name is \t\t\t" + nickName);
                Console.WriteLine("Your account number is \t\t" + accountNumber);

                Console.WriteLine("Your starting balance is \t" + startingBalance.ToString("C"));

                Console.WriteLine("Enter (0) to update your account number");
                Console.WriteLine("Enter (1) to modify the account balance");
                Console.WriteLine("Enter (2) to quit the program");
                Console.WriteLine("Enter (3) to Add money (Income)");
                Console.WriteLine("Enter (4) to Subtract money (Expense)");

                string value = Console.ReadLine();
                //Int32.TryParse(value, out int selection);


                if (String.Compare(value, "0", true) == 0)
                    return '0';
                else if (String.Compare(value, "1", true) == 0)
                    return '1';
                else if (String.Compare(value, "2", true) == 0)
                    return '2';
                else if (String.Compare(value, "3", true) == 0)
                    return '3';
                else if (String.Compare(value, "4", true) == 0)
                    return '4';
                else
                    DisplayError("Please select a valid option");

            } while (true);
        }
        /*static void userAccount()//string nickName, string accountNumber, decimal startingBalance)
        {
            Console.WriteLine("Enter your name:");
            nickName = ReadName();
            Console.WriteLine("Enter your Account Number:");
            accountNumber = ReadAcctNumber();
            Console.WriteLine("Enter the starting balance:");
            startingBalance = ReadBalance(0);
        }*/

        private static string ReadAcctNumber ()
        {
            Console.WriteLine("Enter your Account Number:");
            do
            {
                string value = Console.ReadLine();
                if (value == "")
                    DisplayError("Please enter your Account Number");
                else if (Int32.TryParse(value, out int inputNumber))
                {
                    accountNumber = inputNumber.ToString();
                    return accountNumber;
                } else
                    DisplayError("Please enter a valid Account Number (digits only)");
            } while (true);
        }

        private static string ReadName ()
        {
            Console.WriteLine("Enter your name:");
            do
            {
                string inputName = Console.ReadLine();

                if (inputName != "")
                    return inputName;
                DisplayError("Please enter your name");
            } while (true);
        }

        static decimal ReadBalance ()
        {
            Console.WriteLine("Enter the starting balance:");

            do
            {
                string inputValue = Console.ReadLine();
                Decimal.TryParse(inputValue, out decimal newBalance);

                if (String.IsNullOrEmpty(inputValue) || !(Decimal.TryParse(inputValue, out startingBalance))) //makes sure tryparse is true (user input is numbers )
                    DisplayError("Please enter a starting balance");
                else if (startingBalance <= 0)
                    DisplayError("Must be greater than 0");
                else
                    return newBalance;

            } while (true);
        }
        static void DisplayError ( string message )
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();


        }
    }
}