using Chess.Rules.Sabitler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Rules.Taslar
{
    public abstract class Tas
    {
        public string Isim { get; set; }
        public string Resim { get; set; }
        public Renk Renk { get; set; }
        public bool Oynadı { get; set; }

        public bool HareketEt(Kare baslangıcKare, Kare hedefKare, List<Kare> kareler, Func<Koordinat, List<Kare>, List<Kare>> fonksiyon)
        {
            List<Kare> uygunKareler = fonksiyon(baslangıcKare.Koordinat, kareler);              

            bool hareketEdilebilir = uygunKareler.Contains(hedefKare);

            if (hareketEdilebilir)
            {
                ITas tas = baslangıcKare.Tas;

                baslangıcKare.Tas = null;
                baslangıcKare.Durum = KareDurum.Bos;
                baslangıcKare.Resim = null;

                hedefKare.Tas = tas;
                hedefKare.Durum = KareDurum.Dolu;
                hedefKare.Resim = this.Resim;

                Oynadı = true;
            }

            return hareketEdilebilir;
        }
    }
}
