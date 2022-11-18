namespace DelegatesExample
{
    class Delegate
    {
        public delegate void operation(int x, int y);
        public void Addition(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        class Program
        {
            public static void Main(string[] args)
            {
                Delegate del = new Delegate();
                operation op = new operation(del.Addition);
                op(5, 10);
            }
        }
    }
}