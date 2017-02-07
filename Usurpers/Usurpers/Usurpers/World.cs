using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usurpers
{
    class World
    {
        public List< string> Events = new List<string>();
        public List<string> Individuals = new List<string>();
        public override string ToString()
        {
            string res = "";
            foreach (string item in Events)
            {
                res += "Grand Event: " + item + "\n";

            }
            res += "And here are some notewothy personas: \n \n" ;
            foreach (string item in Individuals)
            {
                res += item + "\n \n" ;
            }

            return res;
        }
    }
}
