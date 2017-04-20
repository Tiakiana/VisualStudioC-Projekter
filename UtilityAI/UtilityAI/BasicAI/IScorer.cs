using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityAI
{
    interface IScorer
    {
        Context Context { get; set; }
         float ReturnScore();


    }
}
