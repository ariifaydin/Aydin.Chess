using Chess.Rules.Sabitler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Rules.Taslar
{
    public class Sah : Tas, ITas
    {
        public List<Kare> UygunKareleriHesapla(Koordinat koordinat, List<Kare> kareler)
        {
            List<Kare> _kareler = new List<Kare>();

            Kare kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 1 && k.Koordinat.Y == koordinat.Y + 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 1 && k.Koordinat.Y == koordinat.Y).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X + 1 && k.Koordinat.Y == koordinat.Y - 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X && k.Koordinat.Y == koordinat.Y - 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X - 1 && k.Koordinat.Y == koordinat.Y - 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X - 1 && k.Koordinat.Y == koordinat.Y).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X - 1 && k.Koordinat.Y == koordinat.Y + 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            kare = kareler.Where(k => k.Koordinat.X == koordinat.X && k.Koordinat.Y == koordinat.Y + 1).FirstOrDefault();
            KareyiEkle(_kareler, kare);

            return _kareler;
        }

        public static void Yerlestir(List<Kare> kareler, bool webmi = false)
        {
            foreach (Kare kare in kareler)
            {
                if ((kare.Koordinat.X == 4 && kare.Koordinat.Y == 1))
                {
                    if (webmi)
                    {
                        kare.Tas = new Sah { Renk = Renk.Beyaz, Resim = $"{TasResimleri.WEB_BEYAZ_SAH}", Isim = nameof(Sah) };
                        kare.Resim = $"{TasResimleri.WEB_BEYAZ_SAH}";
                    }
                    else
                    {
                        kare.Tas = new Sah { Renk = Renk.Beyaz, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_SAH}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_SAH}";
                    }
                   
                    kare.Durum = KareDurum.Dolu;
                }

                if((kare.Koordinat.X == 4 && kare.Koordinat.Y == 8))
                {
                    if (webmi)
                    {
                        kare.Tas = new Sah { Renk = Renk.Siyah, Resim = $"{TasResimleri.WEB_SIYAH_SAH}", Isim = nameof(Sah) };
                        kare.Resim = $"{TasResimleri.WEB_SIYAH_SAH}";
                    }
                    else
                    {
                        kare.Tas = new Sah { Renk = Renk.Siyah, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_SAH}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_SAH}";
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
