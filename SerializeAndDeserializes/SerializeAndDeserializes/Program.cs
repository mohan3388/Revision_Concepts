namespace SerializeAndDeserializes
{
    class Program
    {
        public static void Main(string[] args)
        {
            Deserializations deserializations = new Deserializations();
            //deserializations.DeserializeMethod();
           // deserializations.JsonDeserialize();
            Serializations serializations = new Serializations();
            serializations.XMlSerialize();
            //serializations.SerializeMethod();
           // serializations.JsonSerialize();
        }
    }
}