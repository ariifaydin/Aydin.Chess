using Chess.Rules.Sabitler;
using Chess.Rules.Taslar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Rules
{
    public class Kare
    {
        public Kare()
        {
            Koordinat = new Koordinat();
            TasTipleri = new TasTipleri();
        }

        public ITas Tas { get; set; }
        public KareDurum Durum { get; set; }
        public Renk Renk { get; set; }
        public Koordinat Koordinat { get; set; }
        public string Resim { get; set; }
        public TasTipleri TasTipleri { get; set; }



    }
}
