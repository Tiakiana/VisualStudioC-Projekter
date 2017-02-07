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
    }
}
