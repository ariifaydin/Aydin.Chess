using Chess.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Rules.Sabitler;
using Chess.Rules.Taslar;

namespace Desktop.UI
{
    public partial class Tahta : Form
    {
        public string OncekiButtonAccessibleName { get; set; }

        public int Sayac { get; set; }

        public List<Kare> Kareler { get; set; }
        public List<Button> Butonlar { get; set; }

        public Tahta()
        {
            Kareler = new List<Kare>();
            Butonlar = new List<Button>();
            InitializeComponent();
            TahtayıYarat();
            TaslarıYerlestir();
        }
        
        private void TaslarıYerlestir()
        {
            Kale.Yerlestir(this.Kareler);
            Fil.Yerlestir(this.Kareler); 
            Vezir.Yerlestir(this.Kareler);
            Sah.Yerlestir(this.Kareler);
            At.Yerlestir(this.Kareler);
            Piyon.Yerlestir(this.Kareler);

            foreach (var kare in Kareler)
            {
                if (kare.Tas != null)
                {
                    Button button = Butonlar.Where(b => b.AccessibleName == kare.Koordinat.X.ToString() + kare.Koordinat.Y.ToString()).FirstOrDefault();
                    if (button != null)
                        button.Image = Image.FromFile(kare.Resim);
                }
            }
        }

        private void TahtayıYarat()
        {
            int x = 0;
            int y = 0; 
            for (int i = 1; i < 9; i++)
            {

                for (int j = 1; j < 9; j++)
                {
                    Button button = new Button();
                    Kare kare = new Kare();

                    button.AccessibleName = $"{i}{j}";
                    kare.Koordinat.X = i;
                    kare.Koordinat.Y = j;

                    button.Click += delegate (object sender, EventArgs e)
                    {
                        TasıHareketEttir(sender, e, button);
                    };

                    if (j % 2 == 0)
                    {
                        if (i % 2 == 0)
                        {
                            button.BackColor = SystemColors.ButtonHighlight;
                            kare.Renk = Renk.Beyaz;
                        }
                        else
                        {
                            button.BackColor = SystemColors.ActiveCaptionText;
                            kare.Renk = Renk.Siyah;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            button.BackColor = SystemColors.ActiveCaptionText;
                            kare.Renk = Renk.Siyah;
                        }
                        else
                        {
                            button.BackColor = SystemColors.ButtonHighlight;
                            kare.Renk = Renk.Beyaz;
                        }
                    }

                    button.Location = new Point(x, y);
                    button.Name = (i + j).ToString();
                    button.Size = new Size(100, 100);
                    Controls.Add(button);

                    kare.Durum = KareDurum.Bos;
                    Kareler.Add(kare);
                    Butonlar.Add(button);

                    y += 100;
                }
                x += 100;
                y = 0;
            }

        }

        private void TasıHareketEttir(object sender, EventArgs e, Button tıklananButton)
        {
            if (Sayac == 0)
            {
                this.OncekiButtonAccessibleName = tıklananButton.AccessibleName;

                if (tıklananButton.Image != null)
                {
                    Sayac++;
                }
            }
            else if (Sayac == 1)
            {
                foreach (var control in Controls)
                {
                    Button oncekiButon = (Button)control;

                    if (oncekiButon.AccessibleName == OncekiButtonAccessibleName && oncekiButon.Image != null && tıklananButton.AccessibleName != oncekiButon.AccessibleName)
                    {
                        Kare oncekiKare = Kareler.Where(kare => kare.Koordinat.X.ToString() + kare.Koordinat.Y.ToString() == oncekiButon.AccessibleName).FirstOrDefault();
                        Kare hedefKare = Kareler.Where(kare => kare.Koordinat.X.ToString() + kare.Koordinat.Y.ToString() == tıklananButton.AccessibleName).FirstOrDefault();

                        oncekiKare.Tas.HareketEt(oncekiKare, hedefKare, this.Kareler, oncekiKare.Tas.UygunKareleriHesapla);

                        oncekiButon.Image = oncekiKare.Resim is null ? null : Image.FromFile(oncekiKare.Resim);
                        tıklananButton.Image = hedefKare.Resim is null ? null : Image.FromFile(hedefKare.Resim);

                        break;
                    }
                }

                Sayac--;
            }
        }
    }
}
