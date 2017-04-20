using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityAI
{

    //the main qualifier, that little baby qualifiers inherrit from.
    abstract class  BaseQualifier
    {

     
        private float score;
        public float Score { get { return score; } }


        
       
        public List<IAction> ActionsInterfaces = new List<IAction>();



        public List<IScorer> scorers = new List<IScorer>();


        
        public void SetScore(float i)
        {
            score = i;
        }

       
        //Giver qualifieren den endelige scorer som selectoren bliver færdig med.
        public void PingScorers()
        {
            foreach (IScorer item in scorers)
            {
                score += item.ReturnScore();
            }
        }





        public void UseActions() {
            foreach (IAction item in ActionsInterfaces)
            {
                item.Execute();
            }
        }


    }
}
