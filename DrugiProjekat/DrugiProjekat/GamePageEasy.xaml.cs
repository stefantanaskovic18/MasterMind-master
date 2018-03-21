using DrugiProjekat.classes;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DrugiProjekat
{
    /// <summary>
    /// Interaction logic for GamePageEasy.xaml
    /// </summary>
    public partial class GamePageEasy : Window
    {
        private DispatcherTimer timer;
        private int vreme;
        private int brojac;
        private Game igra;
        private bool izborTezine;
        private int[] kombinacija;
        private string playerName;
        private string prikaziKombinaciju;

        public GamePageEasy()
        {
            InitializeComponent();
            
        }

        private void startTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            lbl_igrac.Content = this.playerName;
            lbl_time.Content = ""+vreme.ToString();
            vreme--;
        }

        public void setPlayerName(Object name, Object tezina)
        {
            this.playerName = (string)name;
            this.izborTezine = (bool)tezina;
            brojac = 1;
            igra = new Game(new Player(playerName, izborTezine));
            kombinacija = igra.Kombijacija();
            for (int i = 0; i < kombinacija.Length; i++)
            {
                switch (kombinacija[i])
                {
                    case 1:
                        prikaziKombinaciju += " - SKOCKO - ";
                        break;
                    case 2:
                        prikaziKombinaciju += " - TREF - ";
                        break;
                    case 3:
                        prikaziKombinaciju += " - PIK - ";
                        break;
                    case 4:
                        prikaziKombinaciju += " - HERC - ";
                        break;
                    case 5:
                        prikaziKombinaciju += " - KARO - ";
                        break;
                    case 6:
                        prikaziKombinaciju += " - ZVEZDA - ";
                        break;
                }
            }
                for (int i = 1; i < 25; i++)
                {
                    String imeKvadrata = "p" + i;
                    Rectangle obj = (Rectangle)this.FindName(imeKvadrata);
                    obj.MouseLeftButtonUp += ukloni;
                }
            if (izborTezine)
                vreme = 120;
            else
                vreme = 60;
            startTimer();
        }

        private void ukloni(object sender, MouseButtonEventArgs e)
        {
            Rectangle obj = sender as Rectangle;
            obj.Fill = null;
        }

        private void popuni_red(Rectangle r)
        {
            
            for (int i = 1; i < 25; i++)
            {
                String name = "p" + i;
                Rectangle obj = (Rectangle)this.FindName(name);
                if (obj.Fill == null)
                {
                    obj.Fill = r.Fill;
                    break;
                }
            }
        }

        private bool proveri_red()
        {
            if (brojac == 1 && (((Rectangle)this.FindName("p1")).Fill != null) && ((Rectangle)this.FindName("p2")).Fill != null && ((Rectangle)this.FindName("p3")).Fill != null && ((Rectangle)this.FindName("p4")).Fill != null)
            {
                return true;
            }
            else if (brojac == 2 && (((Rectangle)this.FindName("p5")).Fill != null) && ((Rectangle)this.FindName("p6")).Fill != null && ((Rectangle)this.FindName("p7")).Fill != null && ((Rectangle)this.FindName("p8")).Fill != null)
            {
                return true;
            }
            else if (brojac == 3 && (((Rectangle)this.FindName("p9")).Fill != null) && ((Rectangle)this.FindName("p10")).Fill != null && ((Rectangle)this.FindName("p11")).Fill != null && ((Rectangle)this.FindName("p12")).Fill != null)
            {
                return true;
            }
            else if (brojac == 4 && (((Rectangle)this.FindName("p13")).Fill != null) && ((Rectangle)this.FindName("p14")).Fill != null && ((Rectangle)this.FindName("p15")).Fill != null && ((Rectangle)this.FindName("p16")).Fill != null)
            {
                return true;
            }
            else if (brojac == 5 && (((Rectangle)this.FindName("p17")).Fill != null) && ((Rectangle)this.FindName("p18")).Fill != null && ((Rectangle)this.FindName("p19")).Fill != null && ((Rectangle)this.FindName("p20")).Fill != null)
            {
                return true;
            }
            else
                return false;
        }

        private void skocko_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (proveri_red())
            {
            }
            else
                popuni_red(skocko);
            
        }

        private void tref_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (proveri_red())
            {
            }
            else
                popuni_red(tref);
        }

        private void pik_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (proveri_red())
            {
            }
            else
                popuni_red(pik);
        }

        private void herc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (proveri_red())
            {
            }
            else
                popuni_red(herc);
        }

        private void karo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (proveri_red())
            {
            }
            else
                popuni_red(karo);
        }

        private void star_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (proveri_red())
            {
            }
            else
                popuni_red(star);
        }

        private void upitnik_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            if (brojac == 1 && (((Rectangle)this.FindName("p4")).Fill != null && ((Rectangle)this.FindName("p3")).Fill != null && ((Rectangle)this.FindName("p2")).Fill != null && ((Rectangle)this.FindName("p1")).Fill != null))
            {
                proveri_stanje(1, 5);
                brojac++;
            }
            else if (brojac == 2 && (((Rectangle)this.FindName("p5")).Fill != null && ((Rectangle)this.FindName("p6")).Fill != null && ((Rectangle)this.FindName("p7")).Fill != null && ((Rectangle)this.FindName("p8")).Fill != null))
            {
                proveri_stanje(5, 9);
                brojac++;
            }
            else if (brojac == 3 && (((Rectangle)this.FindName("p9")).Fill != null && ((Rectangle)this.FindName("p10")).Fill != null && ((Rectangle)this.FindName("p11")).Fill != null && ((Rectangle)this.FindName("p12")).Fill != null))
            {
                proveri_stanje(9, 13);
                brojac++;
            }
            else if (brojac == 4 && (((Rectangle)this.FindName("p13")).Fill != null && ((Rectangle)this.FindName("p14")).Fill != null && ((Rectangle)this.FindName("p15")).Fill != null && ((Rectangle)this.FindName("p16")).Fill != null))
            {
                proveri_stanje(13, 17);
                brojac++;
            }
            else if (brojac == 5 && (((Rectangle)this.FindName("p17")).Fill != null && ((Rectangle)this.FindName("p18")).Fill != null && ((Rectangle)this.FindName("p19")).Fill != null && ((Rectangle)this.FindName("p20")).Fill != null))
            {
                proveri_stanje(17, 21);
                brojac++;
            }
            else if (brojac == 6 && (((Rectangle)this.FindName("p21")).Fill != null && ((Rectangle)this.FindName("p22")).Fill != null && ((Rectangle)this.FindName("p23")).Fill != null && ((Rectangle)this.FindName("p24")).Fill != null))
            {
                proveri_stanje(21, 25);
                brojac++;
            }
        }

        private void proveri_stanje(int x1, int x2)
        {
            int[] uneta_kombinacija = new int[4];
            int j = 0;
            for (int i = x1; i < x2; i++)
            {
                string name = "p" + i;
                Rectangle obj = (Rectangle)this.FindName(name);
                if (obj.Fill == skocko.Fill)
                    uneta_kombinacija[j] = 1;
                else if (obj.Fill == tref.Fill)
                    uneta_kombinacija[j] = 2;
                else if (obj.Fill == pik.Fill)
                    uneta_kombinacija[j] = 3;
                else if (obj.Fill == herc.Fill)
                    uneta_kombinacija[j] = 4;
                else if (obj.Fill == karo.Fill)
                    uneta_kombinacija[j] = 5;
                else if (obj.Fill == star.Fill)
                    uneta_kombinacija[j] = 6;
                j++;
            }


            int na_mestu = brojPogodakaNaMestu(uneta_kombinacija);
            int nisuNaMestu = brojPogodakaVanMesta(uneta_kombinacija);
            

            popuniKruzice(na_mestu, nisuNaMestu-na_mestu);
            if (na_mestu == 4)
            {
                timer.Stop();   
                MessageBox.Show("Resili ste skocka!! Bravo: "+lbl_igrac.Content);
                igra.getPlayer().upisiUdatoteku(vreme, brojac);
                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();
            }
            if (brojac == 6 && na_mestu < 4)
            {
                MessageBox.Show("Niste resili skocka, kombinacija je bila: " + prikaziKombinaciju);
                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();
            }
        }

        private void popuniKruzice(int na_mestu, int van_mesta)
        {
            
            int koji_red = 0;
            if (brojac == 1)
                koji_red = 1;
            else if (brojac == 2)
                koji_red = 5;
            else if (brojac == 3)
                koji_red = 9;
            else if (brojac == 4)
                koji_red = 13;
            else if (brojac == 5)
                koji_red = 17;
            else if (brojac == 6)
                koji_red = 21;

            int br = koji_red;
            for (int i = koji_red; i < na_mestu + koji_red; i++)
            {
                string name = "e" + i;
                Ellipse obj = (Ellipse)this.FindName(name);
                obj.Fill = new SolidColorBrush(Colors.Red);
                br++;
            }
            for (int i=br; i < van_mesta + koji_red + na_mestu; i++) 
            {
                
                    string name = "e" + i;
                    Ellipse obj = (Ellipse)this.FindName(name);
                    obj.Fill = new SolidColorBrush(Colors.Yellow);
            }

        }

        private int brojPogodakaVanMesta(int[] uneta_kombinacija)
        {
            int brojVanMesta = 0;
            int[] kopijaNiza = (int[])kombinacija.Clone();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (uneta_kombinacija[i] == kopijaNiza[j])
                    {
                        brojVanMesta++;
                        uneta_kombinacija[i] = -1;
                        kopijaNiza[j] = -2;
                    }
                }
            }
            return brojVanMesta;
        }

        private int brojPogodakaNaMestu(int[] uneta_kombinacija)
        {
            int broj_pogodaka = 0;
            for (int i = 0; i < 4; i++)
            {
                if (uneta_kombinacija[i] == kombinacija[i])
                    broj_pogodaka++;
            }
            return broj_pogodaka;
        }
    }
}
