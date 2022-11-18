using System.Text.RegularExpressions;

namespace RegularExpression
{
    class program
    {
        public static void Main(string[] args)
        {
            
            try
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                string pattrn = "^[A-Z]{1,}[A-Za-z]{2,}";
                if (Regex.IsMatch(name, pattrn))
                {
                    Console.WriteLine("valid name " + name);
                }
                else
                {
                    Console.WriteLine("not valid");
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}