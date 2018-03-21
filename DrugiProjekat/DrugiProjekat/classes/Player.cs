using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrugiProjekat.classes
{
    [Serializable]
    class Player
    {
        private string nickname;
        private bool tezina;
        private string playerName;
        private object tezina1;
        private int bodovi;

        public Player()
        {

        }

        public Player(string nickname, bool tezina)
        {
            this.nickname = nickname;
            this.tezina = tezina;
        }

        public Player(string playerName, object tezina1)
        {
            // TODO: Complete member initialization
            this.playerName = playerName;
            this.tezina1 = tezina1;
        }

        public override string ToString()
        {
            return nickname + " --- " + bodovi;
        }

        public void upisiUdatoteku(int vreme, int brojac)
        {
            RangLista rl = new RangLista();
            List<Player> igraci;
            if (this.tezina == true)
                igraci = rl.vratiListuIgracaLako();
            else
                igraci = rl.vratiListuIgracaTesko();
            switch (brojac)
            {
                case 1:
                    this.bodovi = vreme + 25;
                    break;
                case 2:
                    this.bodovi = vreme + 20;
                    break;
                case 3:
                    this.bodovi = vreme + 15;
                    break;
                case 4:
                    this.bodovi = vreme + 10;
                    break;
                case 5:
                    this.bodovi = vreme + 5;
                    break;
                case 6:
                    this.bodovi = vreme;
                    break;
                default:
                    this.bodovi = vreme;
                    break;
            }
            igraci.Add(this);
            if (igraci.Count() > 2)
            {
                for (int i = 0; i < igraci.Count() - 1; i++)
                {
                    for (int j = i + 1; j < igraci.Count(); j++)
                    {
                        if (igraci.ElementAt(i).bodovi < igraci.ElementAt(j).bodovi)
                        {
                             Player pom = new Player();
                             pom = igraci.ElementAt(i);
                             igraci[i] = igraci.ElementAt(j);
                             igraci[j] = pom;
                        }
                    }
                }
            }
            FileStream fs2;
            if (this.tezina == true)
                fs2 = File.OpenWrite("rang_lista_lako.txt");
            else
                fs2 = File.OpenWrite("rang_lista_tesko.txt");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs2, igraci);
            MessageBox.Show("Uspesno ste upisani u datoteku.");
            fs2.Dispose();

        }

    }
}
