namespace HashSetProblem
{
    class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("hii");
            set.Add("mks");

            foreach(var a in set)
            {
                Console.WriteLine(a);
            }
        }
    }
}