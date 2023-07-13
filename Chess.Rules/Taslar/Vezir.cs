using Chess.Rules.Sabitler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Rules.Taslar
{
    public class Vezir: Tas, ITas
    {
        public List<Kare> UygunKareleriHesapla(Koordinat koordinat, List<Kare> kareler)
        {
            List<Kare> koordinatlar = new List<Kare>();

            for (int i = koordinat.Y + 1, j = koordinat.X + 1; 0 < i && i < 9 && j > 0 && j < 9; i++, j++)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == j && k.Koordinat.Y == i).FirstOrDefault();

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

            for (int i = koordinat.Y - 1, j = koordinat.X - 1; 0 < i && i < 9 && j > 0 && j < 9; i--, j--)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == j && k.Koordinat.Y == i).FirstOrDefault();

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

            for (int i = koordinat.Y + 1, j = koordinat.X - 1; 0 < i && i < 9 && j > 0 && j < 9; i++, j--)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == j && k.Koordinat.Y == i).FirstOrDefault();

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

            for (int i = koordinat.Y - 1, j = koordinat.X + 1; 0 < i && i < 9 && j > 0 && j < 9; i--, j++)
            {
                Kare kare = kareler.Where(k => k.Koordinat.X == j && k.Koordinat.Y == i).FirstOrDefault();

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
            for (int i = koordinat.Y + 1; i < 9; i++)
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

        public static void Yerlestir(List <Kare> kareler, bool webmi = false)
        {
            foreach(Kare kare in kareler)
            {
                if ((kare.Koordinat.X == 5 && kare.Koordinat.Y == 1))
                {
                    if (webmi)
                    {
                        kare.Tas = new Vezir { Renk = Renk.Beyaz, Resim = $"{TasResimleri.WEB_BEYAZ_VEZIR}", Isim = nameof(Vezir) };
                        kare.Resim = $"{TasResimleri.WEB_BEYAZ_VEZIR}";
                    }
                    else
                    {
                        kare.Tas = new Vezir { Renk = Renk.Beyaz, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_VEZIR}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_BEYAZ_VEZIR}";
                    }
                  
                    kare.Durum = KareDurum.Dolu;
                }

                if ((kare.Koordinat.X == 5 && kare.Koordinat.Y == 8))
                {
                    if (webmi)
                    {
                        kare.Tas = new Vezir { Renk = Renk.Siyah, Resim = $"{TasResimleri.WEB_SIYAH_VEZIR}", Isim = nameof(Vezir) };
                        kare.Resim = $"{TasResimleri.WEB_SIYAH_VEZIR}";
                    }
                    else
                    {
                        kare.Tas = new Vezir { Renk = Renk.Siyah, Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_VEZIR}" };
                        kare.Resim = $"{Environment.CurrentDirectory}{TasResimleri.DESKTOP_SIYAH_VEZIR}";
                    }
                   
                    kare.Durum = KareDurum.Dolu;
                }
            }
           
        }
    }
}
