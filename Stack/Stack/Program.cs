using System.Collections;
using System.Collections.Generic;

namespace StackList
{
    class Stacks
    {
        public static void Main(string[] args)
        {
            Stack list = new Stack();
            list.Push(1);
            list.Push(2);
            list.Push("abc");
            list.Pop();
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}