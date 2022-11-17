namespace Encapsulation
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            student st = new student();
            st.Id = 1;
            st.Name = "govind";

            Console.WriteLine(st.Id + " " + st.Name);
        }
    }
}