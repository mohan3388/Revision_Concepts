using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProblem
{
    public class LinqOperations
    {
        public void GetRecords(List<Model> model)
        {
            var result=model.OrderBy(x=>x.Id).Take(2).ToList();
            Display(result);

        }
        public void Display(List<Model> list)
        {
            foreach(var model in list)
            {
                Console.WriteLine(model.Id+" "+model.Name+" "+model.Description);
            }
        }
    }
}
