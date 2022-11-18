namespace Generics
{
    class GenericProblem
    {
        public static void Generic<T>(T data)
        {
            Console.WriteLine(data);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            GenericProblem.Generic(101);
            GenericProblem.Generic("hii");
        }
    }
}