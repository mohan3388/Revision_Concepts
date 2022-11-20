using System.Text.RegularExpressions;

namespace LambdaExpression
{
    class test
    {
       
        string Pattern = "^[A-Z]{1,}[a-z]{2,}$";
        public string CheckName(string name) => Regex.IsMatch(name, Pattern) ? "Name is Valid" : "Name is not Valid";
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            test valid = new test();
            string user = valid.CheckName(name);
            if (user == "Name is Valid")
            {
                Console.WriteLine(user);
            }
            else
            {
                Console.WriteLine(user);
            }

        }
    }
}