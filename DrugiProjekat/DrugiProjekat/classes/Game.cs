using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrugiProjekat.classes
{
    class Game
    {
        private int[] kombinacija;
        private Player igrac;

        public Game(Player igrac)
        {
            this.igrac = igrac;
            kombinacija = new int[4];
            Random gen = new Random();
            for (int i = 0; i < 4; i++)
            {
                kombinacija[i] = gen.Next(1, 7);
            }
            //kombinacija[0] = 1;
            //kombinacija[1] = 1;
            //kombinacija[2] = 2;
            //kombinacija[3] = 2;
        }

        public int[] Kombijacija()
        {
            return kombinacija;
        }

        public Player getPlayer()
        {
            return this.igrac;
        }


    }
}
