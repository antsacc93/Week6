using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.SupermercatoEF
{
    public static class Helper //where T : class
    {
        public static void StampaCollection<T>(ICollection<T> collection) where T : class
        {
            if(collection.Count == 0)
            {
                Console.WriteLine("Lista vuota");
                return;
            }
            foreach(var item in collection)
            {
                Console.WriteLine(item);
            }
        }

    }
}
