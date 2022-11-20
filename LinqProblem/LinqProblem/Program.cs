namespace LinqProblem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("list of product");
            LinqOperations operations=new LinqOperations();
            List<Model> list = new List<Model>();
            list.Add(new Model() { Id=1, Name="vivek", Description="ojhj"});
            list.Add(new Model() { Id = 2, Name = "raj", Description = "ytre" });
            list.Add(new Model() { Id = 3, Name = "bhupi", Description = "jlkj" });
            operations.GetRecords(list);
        }
    }
}