namespace FileIOStream
{
    class Test
    {
        string path = @"G:\RIvisionConcept\Revision_Concepts\FileIOStream\FileIOStream\TextFile.txt";
        string copypath = @"G:\RIvisionConcept\Revision_Concepts\FileIOStream\FileIOStream\TextCopy.txt";
        string[] lines;
        public void Readtext()
        {
            lines=File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++) {
                Console.WriteLine(lines[i]);
            }
           
        }
        public void CopyFiles()
        {
            File.Copy(path, copypath);
           
        }
    }
    class Program
    {
        public static void Main()
        {
            Test test = new Test();
            test.CopyFiles();
           //test.Readtext();
        }
    }
}