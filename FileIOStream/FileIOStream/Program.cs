namespace FileIOStream
{
    class Test
    {
        string path = @"G:\RIvisionConcept\Revision_Concepts\FileIOStream\FileIOStream\TextFile.txt";
        string[] lines;
        public void Readtext()
        {
            lines=File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++) {
                Console.WriteLine(lines[i]);
            }
            Console.ReadKey();
        }
    }
    class Program
    {
        public static void Main()
        {
            Test test = new Test();
            test.Readtext();
        }
    }
}