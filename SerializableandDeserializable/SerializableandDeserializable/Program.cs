using System.Runtime.Serialization.Formatters.Binary;

namespace SerializableandDeserializable
{
  

    class Program
    {
        public static void Main(string[] args)
        {
            //Deserialization deserialization = new Deserialization();
            //deserialization.Deserialize();
            Serialization serialization = new Serialization();
            serialization.Serializedata();
            //Test demo = new Test();
            //demo.banaryDeserialize();
        }
    }
}