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
    class RangLista
    {
        public RangLista()
        {

        }
        
        public List<Player> vratiListuIgracaLako()
        {
            string dat = "rang_lista_lako.txt";
            if (!File.Exists(dat))
            {
                FileStream fs2 = new FileStream(dat, FileMode.Create, FileAccess.Write);
                fs2.Dispose();
            }
            List<Player> listaIgraca = new List<Player>();
            FileStream fs = File.OpenRead(dat);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                listaIgraca= bf.Deserialize(fs) as List<Player>;
                fs.Dispose();
                return listaIgraca;
            }
            catch (Exception e)
            {
                fs.Dispose();
                return listaIgraca;
            }

        }

        internal List<Player> vratiListuIgracaTesko()
        {
            string dat = "rang_lista_tesko.txt";
            if (!File.Exists(dat))
            {
                FileStream fs2 = new FileStream(dat, FileMode.Create, FileAccess.Write);
                fs2.Dispose();
            }
            List<Player> listaIgraca = new List<Player>();
            FileStream fs = File.OpenRead(dat);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                listaIgraca = bf.Deserialize(fs) as List<Player>;
                fs.Dispose();
                return listaIgraca;
            }
            catch (Exception e)
            {
                fs.Dispose();
                return listaIgraca;
            }
        }
    }
}
