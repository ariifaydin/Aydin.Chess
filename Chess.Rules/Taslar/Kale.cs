using Chess.Rules.Sabitler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess.Rules.Taslar
{
    public class Kale : Tas, ITas
    {
        public List<Kare> UygunKareleriHesapla(Koordinat koordinat, List<Kare> kareler)
        {
            List<Kare> koordinatlar = new List<Kare>();

            for (int i = koordinat.Y + 1; i < 9; i++)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == koordinat.X && k.Koordinat.Y == i).FirstOrDefault();

                if(kare.Tas is null)
                {
                    koordinatlar.Add(kare);
                }
                else if(kare.Tas != null && kare.Tas.Renk != this.Renk)
                {
                    koordinatlar.Add(kare);
                    break;
                }
                else if (kare.Tas != null && kare.Tas.Renk == this.Renk)
                {
                    break;
                }

            }

            for (int i = koordinat.Y - 1; i > 0; i--)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == koordinat.X && k.Koordinat.Y == i).FirstOrDefault();

                if (kare.Tas is null)
                {
                    koordinatlar.Add(kare);
                }
                else if (kare.Tas != null && kare.Tas.Renk != this.Renk)
                {
                    koordinatlar.Add(kare);
                    break;
                }
                else if (kare.Tas != null && kare.Tas.Renk == this.Renk)
                {
                    break;
                } 
            }

            for (int i = koordinat.X + 1; i < 9; i++)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == i && k.Koordinat.Y == koordinat.Y).FirstOrDefault();

                if (kare.Tas is null)
                {
                    koordinatlar.Add(kare);
                }
                else if (kare.Tas != null && kare.Tas.Renk != this.Renk)
                {
                    koordinatlar.Add(kare);
                    break;
                }
                else if (kare.Tas != null && kare.Tas.Renk == this.Renk)
                {
                    break;
                }             
            }

            for (int i = koordinat.X - 1; i > 0; i--)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == i && k.Koordinat.Y == koordinat.Y).FirstOrDefault();

                if (kare.Tas is null)
                {
                    koordinatlar.Add(kare);
                }
                else if (kare.Tas != null && kare.Tas.Renk != this.Renk)
                {
                    koordinatlar.Add(kare);
                    break;
                }
                else if (kare.Tas != null && kare.Tas.Renk == this.Renk)
                {
                    break;
                }
            }

            return koordinatlar; 
        }

        public static void Yerlestir(List<Kare> kareler, bool webmi = false)
        {
            foreach (Kare kare in kareler)
            {
                if((kare.Koordinat.X == 1 && kare.Koordinat.Y == 1) || (kare.Koordinat.X == 8 && kare.Koordinat.Y == 1))
                {
                    if (webmi)
                    {
                        kare.Tas = new Kale { Renk = Renk.Beyaz, Resim = $"{TasResimleri.WEB_BEYAZ_KALE}", Isim = nameof(Kale) };
                        kare.Resim = $"{TasResimleri.WEB_BEYAZ_KALE}";
                    }
                    else
                    {
                        kare.Tas = new Kale { Renk = Renk.Beyaz, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_KALE}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_KALE}";
                    }
                   
                    kare.Durum = KareDurum.Dolu;
                }

                if ((kare.Koordinat.X == 1 && kare.Koordinat.Y == 8) || (kare.Koordinat.X == 8 && kare.Koordinat.Y == 8))
                {
                    if (webmi)
                    {
                        kare.Tas = new Kale { Renk = Renk.Siyah, Resim = $"{TasResimleri.WEB_SIYAH_KALE}", Isim = nameof(Kale) };
                        kare.Resim = $"{TasResimleri.WEB_SIYAH_KALE}";
                    }
                    else
                    {
                        kare.Tas = new Kale { Renk = Renk.Siyah, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_KALE}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_KALE}";
                    }
                   
                    kare.Durum = KareDurum.Dolu;
                }
            }
        }
    }
}
