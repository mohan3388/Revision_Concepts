namespace LinkedList
{
    class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddLast("a");
            list.AddLast("b");
            list.AddLast("c");
            list.AddFirst("d");
            foreach(string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}