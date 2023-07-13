using Chess.Rules.Sabitler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Rules
{
    public interface ITas
    {
        string Isim { get; set; }
        string Resim { get; set; }
        Renk Renk { get; set; }
        bool HareketEt(Kare baslangıcKare, Kare hedefKare, List<Kare> kareler, Func<Koordinat, List<Kare>, List<Kare>> fonksiyon);
        List<Kare> UygunKareleriHesapla(Koordinat koordinat, List<Kare> kareler);
    }
}
