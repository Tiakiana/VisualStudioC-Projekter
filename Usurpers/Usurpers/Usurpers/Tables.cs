using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Usurpers
{
    class Tables
    {

     //   public List<KeyValuePair<string, Hashtable>> GameTablesAdvance = new List<KeyValuePair<string, Hashtable>>();
       // public List<Hashtable> GameTables = new List<Hashtable>();
        public Dictionary<string, Hashtable> GameTables = new Dictionary<string, Hashtable>();
        public Dictionary<string, string> FullGameTables = new Dictionary<string, string>();
        public Dictionary<int, string> IndexOfTables = new Dictionary<int, string>();
        private string[] AllTables;
        Random rnd = new Random();


        public Tables()
        {
            LoadInFullTables();
        }

        public void LoadInFullTables()
        {
            string[] dirs = Directory.GetFiles("../../", "*Table.txt");
            int counter = 0;
            //foreach (string s in dirs)
            //{
            // //   IndexOfTables.Add(counter, s.Substring(6));
            //  //  counter++;
            //}

            foreach (string s in dirs)
            {
                StreamReader reader = new StreamReader(s);
                Hashtable chart = new Hashtable(100);
                List<string> lines = new List<string>();
                string line = "";
                while (((line = reader.ReadLine()) != null))
                {
                    lines.Add(line);
                }
                reader.Close();
                string result = "";
                for (int i = 0; i < lines.Count; i++)
                {
                    result += lines[i] + "\n";

                    
                }
                //     GameTablesAdvance.Add(new KeyValuePair<string, Hashtable>(s.Substring(6),chart));

                string trim = s.Substring(6);

                FullGameTables.Add(trim, result);
                // GameTables.Add(chart);
            }
        }

        public void LoadInTables()
        {

            string[] dirs = Directory.GetFiles("../../", "*Table.txt");
            int counter = 0;
            foreach (string s in dirs)
            {
                IndexOfTables.Add(counter,s.Substring(6));
                counter++;
            }

            foreach (string s in dirs)
            {
                StreamReader reader = new StreamReader(s);
                Hashtable chart = new Hashtable(100);
                List<string> lines = new List<string>();
                string line = "";
                while (((line = reader.ReadLine()) != null))
                {
                    lines.Add(line);
                }
                reader.Close();
                for (int i = 0; i < lines.Count; i++)
                {
                    int x = Int32.Parse(Regex.Match(lines[i], @"\d+").Value);
                    int y = Int32.Parse(Regex.Matches(lines[i], @"\d+")[1].Value);
                    for (int l = x; l <= y; l++)
                    {
                        if (!chart.Contains(l))
                        {
                            string output = Regex.Replace(lines[i], @"[\d-]", string.Empty);
                            //chart[l] = lines[i].Substring(4);
                            chart[l] = output;
                        }
                    }
                }
           //     GameTablesAdvance.Add(new KeyValuePair<string, Hashtable>(s.Substring(6),chart));

                

                GameTables.Add(s.Substring(6),chart);
               // GameTables.Add(chart);
            }
        }

        public World CreateWorld()
        {
            World world = new World();
            int x = rnd.Next(3, 7);

            for (int i = 0; i < x; i++)
            {
                string res = GetRandomItemFromTable("WorldPastEventTable.txt");
                world.Events.Add(res);

            }
            int y = rnd.Next(x - 1, x + 2);
            for (int i = 0; i < y; i++)
            {
                string res ="The " + GetRandomItemFromTable("IndividualTable.txt") + " who was met with the following fate: " + GetRandomItemFromTable("IndividualFateTable.txt");
                world.Individuals.Add(res);
            }


            return world;
            

        }


        public NPC CreateNPC()
        {
            string moti = (string) GameTables["NPCMotivationIntensityTable.txt"][rnd.Next(1, 101)] + " feeling of " + (string)GameTables["NPCMotivationFeelingTable.txt"][rnd.Next(1, 101)] + " towards " + (string)GameTables["NPCMotivationSubjectTable.txt"][rnd.Next(1, 101)];
            NPC npc = new NPC();
            npc.Motivation = moti;
            npc.Occupation = (string) GameTables["NPCOccupationTable.txt"][rnd.Next(1, 101)];
            npc.ContactReaction = (string)GameTables["ContactReactionTable.txt"][rnd.Next(1, 101)];
            npc.HostileReaction = (string)GameTables["NPCHostileReactionsTable.txt"][rnd.Next(1, 101)];
            npc.NeutralReaction = (string)GameTables["NPCNeutralReactionsTable.txt"][rnd.Next(1, 101)];
            npc.Quality = (string)GameTables["FollowerQualityTable.txt"][rnd.Next(1, 101)];
            return npc;
        }

        public Enemy CreateEnemy()
        {
            Enemy e = new Enemy();

            for (int i = 0; i < rnd.Next(4,8); i++)
            {
            
                string thing = (string)GameTables["EnemyTraitStrengthTable.txt"][rnd.Next(1, 101)];
                thing += "\n";
                thing += (string)GameTables["EnemyTraitNatureTable.txt"][rnd.Next(1, 101)];
                thing += "\n";
                thing += "\n";
                e.Traits.Add(thing);
            }

            e.Action = (string) GameTables["EnemyActionTable.txt"][rnd.Next(1, 101)];
            return e;
        }


        public string GetRandomItemFromTable(string tablename)
        {
            try
            {
                return (string) GameTables[tablename][rnd.Next(1, 101)];

            }
            catch (Exception)
            {

                return "You tried " + tablename+ ". No such table";
            }
        }
        public string GetItemFromTable(string tablename, int number)
        {
            try
            {
                return (string)GameTables[tablename][number];

            }
            catch (Exception)
            {

                return "You tried " + tablename + ". Either no such table or number was out of bounds";

            }
        }

        public string ShowTable(string tablename)
        {
            try
            {
                return (string) FullGameTables[tablename];

            }
            catch (Exception)
            {

                return "You tried " + tablename + ". No such table";

            }
        }
    }
}
