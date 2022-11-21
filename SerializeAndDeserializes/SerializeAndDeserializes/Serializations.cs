using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeAndDeserializes
{
    public class Serializations
    {
        //    public void SerializeMethod()
        //    {
        //        Demo demo = new Demo();
        //        FileStream file = new FileStream(@"G:\RIvisionConcept\Revision_Concepts\SerializeAndDeserializes\SerializeAndDeserializes\TextFile.txt", FileMode.Create);
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(file, demo);
        //    }
        //}
        //[Serializable]
        //class Demo
        //{
        //    public int Id { get; set; } = 100;
        //    public string Name { get; set; }= "binary conversion";
    //    public void JsonSerialize()
    //    {
    //        blogSite blog = new blogSite()
    //        {
    //            Name = "sam",
    //            Desc = "welcome sam"
    //        };
    //        string JsonData = JsonConvert.SerializeObject(blog);
    //        Console.WriteLine(JsonData);
    //     }
    //}
    //    [DataContract]
    //    public class blogSite
    //    {
    //        [DataMember]
    //        public string Name { get; set; }
    //        [DataMember]
    //        public string Desc { get; set; }

        public void XMlSerialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OrderForm));
            FileStream fileStream = new FileStream(@"G:\RIvisionConcept\Revision_Concepts\SerializeAndDeserializes\SerializeAndDeserializes\TextFile.txt", FileMode.Create);
            OrderForm orderForm = new OrderForm();
            DateTime dt = new DateTime(2010,12,06);
            orderForm.dateTime = dt;
            serializer.Serialize(fileStream, orderForm);
        }
        }
    public class OrderForm
    {
        public DateTime dateTime;
    }
    }

