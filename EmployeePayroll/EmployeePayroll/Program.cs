namespace EmployeePayroll
{
    public class EmpWage
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int randValue = random.Next(3);
            int EmpWagePerHrs = 20;
            int EmpWageFullDay = 8;
            int PartTimeHrs = 4;
            int isFullTime = 1;
            int isPartTime = 2;
            if (randValue == isFullTime)
            {
                Console.WriteLine("Employee is present");
                int empwage = EmpWagePerHrs * EmpWageFullDay;
                Console.WriteLine(empwage);
            }
            else if (randValue == isPartTime)
            {
                Console.WriteLine("Employee is present parttime");
                int empwage = EmpWagePerHrs * PartTimeHrs;
                Console.WriteLine(empwage);
            }
            else
            {
                Console.WriteLine("Employee is absent");
            }

            switch (randValue)
            {
                case 1:
                    Console.WriteLine("Employee is present");
                    int empwagefull = EmpWagePerHrs * EmpWageFullDay;
                    Console.WriteLine(empwagefull);
                    break;

                case 2:
                    Console.WriteLine("Employee is present parttime");
                    int empwagepart = EmpWagePerHrs * PartTimeHrs;
                    Console.WriteLine(empwagepart);
                    break;
                default: Console.WriteLine("apsent"); break;
            }
        }
    }
}