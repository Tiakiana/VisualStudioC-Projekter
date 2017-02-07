using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usurpers
{
    class Enemy
    {
        public string Action;
       public  List<string> Traits = new List<string>();


        public override string ToString()
        {
            string res = "";

            foreach (string item in Traits)
            {
                res += item;
            }
            return res;
        }
    }
}
