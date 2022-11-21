using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializableandDeserializable
{
    public class Serialization
    {
        const string path = @"G:\RIvisionConcept\Revision_Concepts\SerializableandDeserializable\SerializableandDeserializable\File.txt";
        public void Serializedata()
        {
            Demos data = new Demos();
            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryFormatter bn = new BinaryFormatter();

            bn.Serialize(stream, data);
            stream.Close();
            Console.WriteLine("Convert object to binary");
            string text = File.ReadAllText(path);
            Console.WriteLine(text);

        }
    }
    [Serializable]
    public class Demos
    {
        public string AppName { get; set; } = "Binary Serialize";
        public int AppId { get; set; } = 1001;
    }
}
