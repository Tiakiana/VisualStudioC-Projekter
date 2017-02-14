using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Usurpers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Tables tbls = new Tables();

        public MainWindow()
        {


            tbls.LoadInTables();
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            ResultBox.Text = tbls.CreateNPC().ToString();


        }

        private void EnemyBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.CreateEnemy().ToString();
        }

        private void LocalEvent_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.GetRandomItemFromTable("RandomEncounterTable.txt");
        }

        private void FactionEvent_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.GetRandomItemFromTable("FactionEventTable.txt");

        }

        private void CharacterEvent_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.GetRandomItemFromTable("CharacterEventTable.txt");

        }

        private void RegionalEvent_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.GetRandomItemFromTable("RegionalEventTable.txt");
        }

        private void RandomEvent_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.GetRandomItemFromTable("RandomEncounterTable.txt");

        }

        private void EnemyAction_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.GetRandomItemFromTable("EnemyActionTable.txt");

        }

        private void World_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.CreateWorld().ToString();
        }

        private void AdventureLocation_Click(object sender, RoutedEventArgs e)
        {
            ResultBlock.Text = tbls.GetRandomItemFromTable("AdventureLocationTable.txt");
        }

        private void Region_Click(object sender, RoutedEventArgs e)
        {
            ResultBlock.Text = tbls.GetRandomItemFromTable("RegionalTerrainTable.txt");

        }

        private void Factions_Click(object sender, RoutedEventArgs e)
        {
            ResultBlock.Text = tbls.GetRandomItemFromTable("FactionsTable.txt");

        }

        private void Quest_Click(object sender, RoutedEventArgs e)
        {
            ResultBlock.Text = tbls.GetRandomItemFromTable("QuestTable.txt");

        }

        private void Combat_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("CombatTable.txt");
        }

        private void ActionEvent_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("ActionEventTable.txt");

        }

        private void HeroicAction_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("HeroicActionTable.txt");
       
        }

        private void Fatigue_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("FatigueTable.txt");

        }

        private void Injury_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("InjuryTable.txt");

        }

        private void Improvement_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("ImprovementTable.txt");

        }

        private void Exposure_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("ExposureTable.txt");

        }

        private void Mental_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("MentalTable.txt");

        }

        private void TravelTime_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("TravelTable.txt");

        }

        private void Sanity_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("SanityTable.txt");

        }

        private void Gruesome_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = tbls.ShowTable("GruesomeTable.txt");

        }
    }
}
