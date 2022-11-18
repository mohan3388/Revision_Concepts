namespace QueueList
{
    class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Dequeue();
            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}