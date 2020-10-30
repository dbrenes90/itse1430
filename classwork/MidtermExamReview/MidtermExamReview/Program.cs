using System;

namespace MidtermExamReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string x = "";
            x = Console.ReadLine();



            string DoWork(string x)
            {
               x = "Hello, " + x;

                return x;
            }

            string y = DoWork(x);

            x = y;

            DateTime now = DateTime.Now;

           // daysworked = Int32.Parse("X");

            Console.WriteLine(x);
        }
    }
}
