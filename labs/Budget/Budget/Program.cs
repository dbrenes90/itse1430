using System;
// 09/24/2020
// Daniel Brenes
// Lab 1 
// Budget


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
                    case '2': if(verifyExit())return; break;
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
    

        private static decimal AddMoney (decimal startingBalance)
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
                }
                
                else
                    DisplayError("Please enter a valid Account Number (digits only)");
            } while (true);
        }

        private static string ReadName()
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
        static void DisplayError( string message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();


        }
    }
}/*
namespace MovieLibrary2
{
    public class Program
    {
        static void Main ( string[] args )
        {

            //Parameters vs arguments

            // while => while (E) S;
            // 0 + iterations, pre test condition

            while (true)
            {
                //scope - lifetime of a variable: starts at declaration and continues until end of current scope
                //char choice = DisplayMenu();
                //if (choice == 'Q')
                //      return;
                //  else if (choice == 'A')
                //      AddMovie();
                switch (DisplayMenu())
                {
                    case 'Q': return;
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;

                }
            };






        }
        static string title = "";
        static string description = "";
        static string rating = "";
        static int duration;
        static bool isClassic;

        static void AddMovie ()
        {
            //Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();

            //Type inferencing - compile time only
            //Restrictions: only works with local variables ONLY
            // 2. Variable must be initialized.
            // 3. (Sort of) Cannot figure out type or it is wrong
            //string title = ReadString(true);
            //int title2 = "";
            title = ReadString(true); //string title = ReadString(true);
                                      //variable is not dynamic, but the compiler determines the type when using var
                                      //var use it when it makes sense, don't use it when it doesn't
                                      // makes sense when the type of the variable is relevant to you, or implicit

            //Get description
            Console.WriteLine("Description (optional): ");
            //string description = Console.ReadLine();
            description = ReadString(false);

            //Get Rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
            rating = ReadString(false);

            //Get duration
            Console.WriteLine("Duration (in minutes): ");
            duration = ReadInt32(0);

            //Get is classic
            Console.WriteLine("Is Classic (Y/N)?: ");
            //string isClassic = Console.ReadLine();
            isClassic = ReadBoolean();
        }

        static char DisplayMenu ()
        {
            // 1 + iteration, post test statement
            //do Statement while (expression);
            // block statement => {S*}
            do
            {
                Console.WriteLine("Movie Library");//output to user
                Console.WriteLine("--------------------");

                Console.WriteLine("A)dd Movie");
                Console.WriteLine("V)iew Movie");
                Console.WriteLine("Q)uit");

                //Get input from user
                string value = Console.ReadLine();

                //C++; if(x=10);  //Not valid in C#
                // if (Expression evaluates to a boolean) Statement;
                // if(E) S else S;

                //if (value == "Q")  // 2 equal signs => equality
                if (String.Compare(value, "Q", true) == 0)
                    return 'Q';
                else if (String.Compare(value, "A", StringComparison.CurrentCultureIgnoreCase) == 0)
                    return 'A';
                else if (String.Compare(value, "V", true) == 0)
                    return 'V';

                DisplayError("Invalid option");

            } while (true);



        }
        private static void DisplayError ( string message )
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }
        static bool ReadBoolean ()
        {
            do
            {
                string value = Console.ReadLine();

                //Not useful because of how it is parsed
                //Boolean.TryParse(value, out bool result)

                //switch 0 replacement for if-else-if WHEN
                //Each condition is against same variable
                // AND equality
                // switch (Expression)
                // {
                //  case*
                //  {default}
                // }
                // case ::* case E : Statement*
                // default :: default : S*

                //if (value == "Y" || value == "y") //NOT THE SAME :: = VALUE == "y" || "Y"
                //   return true;
                //else if (value == "N" || value =="n")
                //  return false;
                //else
                // S;
                // C++ Differences
                // 1. No fallthrough  case E: S; break; case E2: S;
                // 2. Any expression type is allowed (C++ does not use other than int)
                // 3. Case labels must be unique and compile time constants
                // 4. Multiple statements are allowed
                switch (value.ToLower())
                {
                    case "X": Console.WriteLine("Wrong Value"); break;

                    //case "Y":               //IF case statement empty (including semicolon) then fallthrough
                    case "y": return true;

                    //case "N": 
                    case "n": return false;
                    //case "A":
                    case "a":
                    {
                        // Use block statement for more than 1 statement
                        Console.WriteLine("Wrong Value");
                        Console.WriteLine("Wrong Value again");

                        break;
                    }

                    default: break; //if nothing else
                };


                DisplayError("Invalid option");
            } while (true);

        }
        static int ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);
        }
        static int ReadInt32 ( int minimumValue )
        {
            do
            {
                string value = Console.ReadLine();

                //Parse to int, int Int32.Parse(string) - not safe
                //int result = Int32.Parse(value);

                //Parameter kinds
                //Input parameter ("pass by value") - a copy of the argument is placed into parameter inside function definition
                //  Input /output parameter ("pass by reference") - a reference to the argument is passed to the function and both original argument and parameter reference same value (C++: int&)
                //  output parameter - function caller does not provide input, function always provides the output (C++: return type)
                //bool Int32.TryParse(string, out int result)
                // Double.Parse/TryParse .. convert to a double
                // Single.Parse/TryParse.. single
                // Boolean.Parse/TryParse
                // Int16.Parse/TryParse

                //Inline variable declaration - only works with out parameters only
                //int result;
                //if(Int32.TryParse(value, out int result) && result >= minimumValue)
                if (Int32.TryParse(value, out var result) && result >= minimumValue)
                    return result;

                // Terminates the loop
                //break;
                //Terminate the iteration
                //continue;

                if (minimumValue != Int32.MinValue)
                    DisplayError("Value must be at least " + minimumValue); //String concatenation
                else
                    DisplayError("Must be integral value");
            } while (true);

        }

        static void ViewMovie ()
        {
            Console.WriteLine("Title\t\tRating\tDuration\tisClassic");
            //Console.WriteLine("----------------");
            Console.WriteLine("".PadLeft(60, '-'));

            //1. Format arguments with WriteLine also WriteLine(object, argument..)
            //Format string - consists of string characters with arguments specified in curly braces as zero-based ordinals
            // 1. Readable but not great (format string)
            // 2. No compile time checking, runtime error (must pass same number of arguments for string calls)

            // Console.WriteLine("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);

            //2. String format
            //var message = String.Format("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);
            //Console.WriteLine(message);

            //3. String concatenation
            // Advantages: Programmatically build it
            // A: Somewhat readable
            // D: Harder to read as it gets longer
            // D: Bad performance (lots of memory allocated and being used) (must start with a string)
            //var message = title + "\t" + rating + "\t" + duration + "\t" + isClassic;
            //var message = title + "\t" + rating + "\t" + duration.ToString() + "\t" + isClassic.TosTring;
            // Console.WriteLine(message);

            //4. String builder
            // Advantage: Efficient on memory
            // A: Conditional formatting
            // D: Longer
            // D: Harder to read
            var builder = new StringBuilder();
            builder.Append(title);
            builder.Append("\t");
            builder.Append(rating);
            builder.Append("\t");
            builder.Append(duration);
            builder.Append("\t");
            builder.Append(isClassic);
            builder.Append("\t");
            // message = builder.ToString();
            // Console.WriteLine(message);

            //5. String Joining
            //message = String.Join("\t", title, rating, duration, isClassic);

            //Conditional operator C ? T : F
            // if (condition) return True else return False

            //6. String interpolation - $"  .. {variable}.."
            // Advantage: Use expressions instead of ordinals
            // A: More readable than any other approach
            // A: Compile time checked
            // D: Compile time only
            // D: Only works with string literals

            var classicIndicator = isClassic ? "Yes" : "No";
            /* var classicIndicator = "";
             if (isClassic)
                 classicIndicator = "Yes";
             else
                 classicIndicator = "No";
             */
/*
            var message = $"{title}\t\t{rating}\t{duration}\t\t{classicIndicator}";
            // Same as var message = String.Format("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);
            Console.WriteLine(message);

            //Write description if available
            if (!String.IsNullOrEmpty(description))
                Console.WriteLine(description);


            Console.WriteLine("");

            //TODO: Description if available
            //Console.WriteLine("  " + description);

            //TODO: If available
            //Console.WriteLine("  " + rating);

            //Console.WriteLine(duration);

            //Console.WriteLine(isClassic);
        }
        //Arithmetic (unary)
        // +E
        // -E

        //Arithmetic (binary) - type coercion
        // addition 10+12
        // subtraction 123-110.4
        // multiplication 10*20
        // division 30/3  
        // modulus 7%4 =>3 (remainder, only works with integrals)

        //int division problem
        // 10/3 => int / int => int
        // 10.0/3 => double / int => double = 3.33
        // (double)10 / 3 => double/ int

        //typecast => (T)E
        // not allowed => (string)10, (int)"Hello", (int)10.5

        //Logical operators (booleans)
        // NOT => !Expression: boolean
        // AND => : boolean
        // OR => E || E : boolean

        //Relational operators (primitives + a few extra)
        //Equality => E == E
        //Inequality => E != E
        //greater than =>
        //greater than or equal to =>
        //same as java and C++ 
        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

                //If not required or not empty return
                if (!required || value != "")
                    return value;


                DisplayError("Value is required");
            } while (true);
        }



        //Funciton definition - declaration + implementation
        // [modifiers] T id ([parameters) {S*}
        //Function signature - [return-type] name, parameter types

        static void FunWithStrings ()
        {
            //5 characters in it, takes up 10 bytes.. each character is 2 bytes.(unicode based) 
            // C++ difference: no NULL
            // Escape sequence begins with \ and is followed by 1 character
            // \n - new line
            // \t - tab
            // \" - "
            // \' - ' (char literal)
            // \\ - \
            // \xHH- hex equivalent \x0A
            //var name = "Bob\c"; //Compiler warning - Bobc , compiler takes out slash
            //var message = "Hello \"Bob\"\nWorld";

            //File paths - always escape sequences
            var filePath = "C:\\Temp\\test.pdf"; //C:\Temp\test.pdf
            var filePath2 = @"C:\Temp\test.pdf"; //Verbatim string

            //Strings are immutable, cannot be modified

            //TODO: null and empty string
            var emptyString = "";
            var spaceString = " ";

            var emptyString2 = String.Empty; //""
            var areEqual = emptyString == emptyString2; // True

            //Checking for empty string
            //1. Comparison
            var isEmpty = emptyString == "";
            var isEmpty1_Part2 = emptyString == String.Empty;

            //2. Length
            var isEmpty2 = emptyString.Length == 0;

            //3. String Compare => return int
            //    < 0  left < right
            //    == 0 left == right
            //    > 0 left > right

            var isEmpty3 = String.Compare(emptyString, "") == 0;

            //4. Preferred IsNullOrEmpty => boolean
            var isEmpty4 = String.IsNullOrEmpty(emptyString);

            // Can be null ... Not C++ null
            string nullString = null;
            //nullString.ToUpper(); // Will crash
            var areEqual3 = emptyString == nullString; // false... null does not equal empty
                                                       // var willCrash = nullString.Length == 0;  //Will crash the program
            var willNotBeEqual = String.Compare(emptyString, null) == 0;

            //var isEmpty5 = nullString != null && nullString != ""; //Inefficient

            //Converting to string E.ToString()
            var asString = emptyString.ToString();
            asString = 10.ToString(); // "10"
            asString = (50*3).ToString();// "150"

            // Common Function -> E.func()

            // Comparison
            // 1. Relational Operators == != case sensitive
            // 2. String.Compare
            var relationalCompare = String.Compare("Hello", "hello") == 0; //Case sensitive, culture aware
            var caseInsensitiveCompare = String.Compare("Hello", "hello", true) == 0; // case insensitive, culture aware

            //locale - Windows cultural settings (,%$00.00, 0000/00/00)
            var ordinalCompare = String.Compare("Hello", "hello", StringComparison.OrdinalIgnoreCase) == 0; //Case insensitive, ordinal (keys, paths)

            //3. Case conversion - PLEASE DON'T DO THIS    (no in-place string modification in C#)
            var toUpper = "Hello".ToUpper(); //HELLO ToUpper() => string
            var toLower = "Hello".ToLower(); //hello ToLower() => string

            // trim and padding
            var areSpacesEqual = "" == " ";
            var name2 = "   Bob \t ";
            name2 = name2.Trim(); //Removes leading and trailing whitespace (newlines, tabs, spaces) - "Bob"
            //TrimStart, TrimEnd to trim start or ending of strings

            filePath2 = filePath2.TrimEnd('\\');

            //PadLeft(#) PadRight(#) puts spaces on left or right, pads to width, never truncates
            var paddedName = name2.PadLeft(10); // "       Bob"

            //String formatting
            //1. Format argument overloads WriteLine(string, {args})
            //2. String.format

            //3. String concatenation
            // Advantages: Programmatically build it
            // A: Somewhat readable
            // D: Harder to read as it gets longer
            // D: Bad performance (lots of memory allocated and being used)
            var message = title + "\t" + rating + "\t" + duration + "\t" + isClassic;
            //var message = title + "\t" + rating + "\t" + duration.ToString() + "\t" + isClassic.TosTring;
            Console.WriteLine(message);

            //4. String builder
            // Advantage: Efficient on memory
            // A: Conditional formatting
            // D: Longer
            // D: Harder to read

            //5. Joining strings
            //6. String interpolation

            // Contains ( string ) => boolean
            // Index/IndexOfAny ( string) => index
            // StartsWith / EndsWith

            var leftPath = @"C:\temp\";
            var rightPath = @"\folderA\file.txt";

            var endsWithSlash = leftPath.EndsWith(@"\");
            var startsWithSlash = rightPath.StartsWith(@"\");

            var path = leftPath;
            if (endsWithSlash && !startsWithSlash)
                path += rightPath;
            else if (endsWithSlash && startsWithSlash)
                path += rightPath.Substring(1); //"folderA\file.txt"
            else //!endsWithSlash && StartsWithSlash
                path += rightPath;

        }
    }
}*/
