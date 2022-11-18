using System.Collections;

namespace HashTable
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("1", "raj");
            ht.Add("2", "mks");
            foreach(string key in ht.Keys)
            {
                Console.WriteLine(key+" " + ht[key]);
            }
        }
    }
}