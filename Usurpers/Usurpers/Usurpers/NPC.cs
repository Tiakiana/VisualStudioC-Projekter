using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usurpers
{
    class NPC
    {
        public string Name, Motivation, Occupation, Quality, NeutralReaction, HostileReaction, ContactReaction;

        public NPC(string name, string motivation, string occupation, string quality, string neutralReaction, string hostileReaction, string contactReaction)
        {
            Name = name;
            Motivation = motivation;
            Occupation = occupation;
            Quality = quality;
            NeutralReaction = neutralReaction;
            HostileReaction = hostileReaction;
            ContactReaction = contactReaction;
        }

        public NPC()
        {

        }

        public override string ToString()
        {
            string res = "Motivation: " + Motivation + "\n" +
                         "Occupation: " + Occupation + "\n" +
                         "Quality: " + Quality;
            return res;
        }
    }
}
