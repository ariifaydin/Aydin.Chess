using Chess.Rules.Sabitler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Rules.Taslar
{
    public class At : Tas, ITas
    {
        public List<Kare> UygunKareleriHesapla(Koordinat koordinat, List<Kare> kareler)
        {
            List<Kare> _kareler = new List<Kare>();

            Kare kare = kareler.Where(k => k.Koordinat.X == koordinat.X - 1 && k.Koordinat.Y == koordinat.Y + 2).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X -2 && k.Koordinat.Y == koordinat.Y - 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X - 2 && k.Koordinat.Y == koordinat.Y + 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 2 && k.Koordinat.Y == koordinat.Y - 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 1 && k.Koordinat.Y == koordinat.Y - 2).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 1 && k.Koordinat.Y == koordinat.Y + 2).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 2 && k.Koordinat.Y == koordinat.Y + 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X - 1 && k.Koordinat.Y == koordinat.Y - 2).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            return _kareler;
        }

        public static void Yerlestir(List<Kare> kareler, bool webmi = false)
        {
            foreach (Kare kare in kareler)
            {
                if ((kare.Koordinat.X == 2 && kare.Koordinat.Y == 1) || (kare.Koordinat.X == 7 && kare.Koordinat.Y == 1))
                {
                    if (webmi)
                    {
                        kare.Tas = new At { Renk = Renk.Beyaz, Resim = $"{TasResimleri.WEB_BEYAZ_AT}", Isim = nameof(At) };
                        kare.Resim = $"{TasResimleri.WEB_BEYAZ_AT}";
                    }
                    else
                    {
                        kare.Tas = new At { Renk = Renk.Beyaz, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_AT}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_AT}";
                    }
                    kare.Durum = KareDurum.Dolu;
                }

                if ((kare.Koordinat.X == 2 && kare.Koordinat.Y == 8) || (kare.Koordinat.X == 7 && kare.Koordinat.Y == 8))
                {
                    if (webmi)
                    {
                        kare.Tas = new At { Renk = Renk.Siyah, Resim = $"{TasResimleri.WEB_SIYAH_AT}", Isim = nameof(At) };
                        kare.Resim = $"{TasResimleri.WEB_SIYAH_AT}";
                    }
                    else
                    {
                        kare.Tas = new At { Renk = Renk.Siyah, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_AT}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_AT}";
                    }
                    
                    kare.Durum = KareDurum.Dolu;
                }
            }
        }

        private void KareyiEkle(List<Kare> kareler, Kare kare)
        {
            if (kare?.Tas is null)
            {
                kareler.Add(kare);
            }
            else if (kare?.Tas != null && kare?.Tas.Renk != this.Renk)
            {
                kareler.Add(kare);
            }
        }
    }
}
