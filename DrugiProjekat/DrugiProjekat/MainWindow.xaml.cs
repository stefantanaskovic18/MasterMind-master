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
using DrugiProjekat.classes;

namespace DrugiProjekat
{
    public partial class MainWindow : Window
    {
        public delegate void delPassData(Object playerName, Object tezina);
        private bool tezina;
        private string imeIgraca;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btb_startGame_Click(object sender, RoutedEventArgs e)
        {
            GamePageEasy gpEasy = new GamePageEasy();
            this.imeIgraca = txtime_igraca.Text;
            if (easy.IsChecked == true)
                this.tezina = true;
            else
                this.tezina = false;


            delPassData delegat = new delPassData(gpEasy.setPlayerName);
            delegat(imeIgraca, tezina);
            gpEasy.Show();
            this.Close();
            
        }

        private void btnRangListaEasy_Click(object sender, RoutedEventArgs e)
        {
            RangLista rl = new RangLista();
            string x = "";
            List<Player> igraci = rl.vratiListuIgracaLako();
            for (int i = 0; i < igraci.Count(); i++)
            {
                x += igraci.ElementAt(i).ToString() + "\n";
            }
            MessageBox.Show("RANG LISTA: \n"+x);
        }

        private void btnRangListaHard_Click(object sender, RoutedEventArgs e)
        {
            RangLista rl = new RangLista();
            string x = "";
            List<Player> igraci = rl.vratiListuIgracaTesko();
            for (int i = 0; i < igraci.Count(); i++)
            {
                x += igraci.ElementAt(i).ToString() + "\n";
            }
            MessageBox.Show("RANG LISTA: \n" + x);
        }



        
    }
}
