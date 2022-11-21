using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAndDeserializes
{
    public class Deserializations
    {
    //    public void DeserializeMethod()
    //    {
          
    //        FileStream fileStream = new FileStream(@"G:\RIvisionConcept\Revision_Concepts\SerializeAndDeserializes\SerializeAndDeserializes\TextFile.txt", FileMode.Open);

    //        BinaryFormatter formatter = new BinaryFormatter();
    //        Demo deserialization = (Demo)formatter.Deserialize(fileStream);
    //        Console.WriteLine($"AppName:-{deserialization.Id}--AppId:-{deserialization.Name}");
    //     }
    //}
    //[Serializable]
    //public class Demo
    //{
    //    public int Id { get; set; } = 100;
    //    public string Name { get; set; } = "binary conversion";

        public void JsonDeserialize()
        {
            string json = @"{
            'Name':'mks',
             'Description':'welcome to india'

}";
            Blogs blogs=JsonConvert.DeserializeObject<Blogs>(json);
            Console.WriteLine(blogs.Name+" "+blogs.Description);
        }
    }
    [DataContract]
    public class Blogs
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
