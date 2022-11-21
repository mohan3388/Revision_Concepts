using System.Runtime.Serialization.Formatters.Binary;

namespace FileIOStream
{
    class Test
    {
        string path = @"G:\RIvisionConcept\Revision_Concepts\FileIOStream\FileIOStream\TextFile.txt";
        string copypath = @"G:\RIvisionConcept\Revision_Concepts\FileIOStream\FileIOStream\TextCopy.txt";
        string[] lines;
        public void CheckFileExistorNot()
        {
            if (File.Exists(path))
            {
                Console.WriteLine("File Already Exist");
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }

        public void Readtext()
        {
            lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

        }
        public void CopyFiles()
        {
            File.Copy(path, copypath);

        }
        public void DeleteFile()
        {
            File.Delete(copypath);
        }

        public void ReadFromStreamReader()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public void WriteUsingStreamWritterer()
        {
            using(StreamWriter sw = File.AppendText(path))
            {

                sw.WriteLine(" Mohan you have pushed");
                sw.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
      

    }
    class Program
    {
        public static void Main()
        {
            Test test = new Test();
            test.WriteUsingStreamWritterer();
           // test.ReadFromStreamReader();
           // test.DeleteFile();
           // test.CheckFileExistorNot();
          // test.CopyFiles();
           //test.Readtext();
        }
    }
}