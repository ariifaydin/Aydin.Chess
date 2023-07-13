using Chess.Rules;
using Chess.Rules.Taslar;
using Microsoft.AspNetCore.Mvc;
using Chess.Rules.Sabitler;
using Web.UI.Models;
using Web.UI.Services;
using Newtonsoft.Json;
using Web.UI.Entities.MongoDb;

namespace Web.UI.Controllers
{
    public class SatrancController : Controller 
    {
        public List<Kare> Kareler { get; set; }
        public string OncekiKareKoordinat { get; set; }
        public int? Sayac { get; set; }
        public string TahtaId { get; set; }

        public TahtaModel TahtaModel { get; set; }

        private readonly TahtaService _tahtaService;
        public SatrancController(TahtaService tahtaService)
        {
            Kareler = new List<Kare>();
            KareleriYarat();
            TaslarıYerlestir();

            _tahtaService = tahtaService;
        }

        [HttpGet]
        public async Task<IActionResult> Tahta()
        {
            TahtaId = HttpContext.Session.GetString("TahtaId");

            if (string.IsNullOrEmpty(TahtaId))
            {
                TahtaId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("TahtaId", TahtaId);

                TahtaModel = new TahtaModel() { Id = TahtaId, Kareler = Kareler };
            }
            else
            {
                var tahta = await _tahtaService.GetAsync(TahtaId);

                if(tahta is not null)
                {
                    Kareler = JsonConvert.DeserializeObject<List<Kare>>(tahta.Kareler);

                    CastGeriAl();

                    TahtaModel = new TahtaModel() { Id = TahtaId, Kareler = Kareler };
                }
                
            }

            TahtaModel ??= new TahtaModel() { Id = TahtaId, Kareler = Kareler };

            return View(TahtaModel);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnClick(OnClickModel onClickModel)
        {
            await TasıHareketEttir(onClickModel);

            return RedirectToAction("Tahta");
        }

        private void TaslarıYerlestir()
        {
            Kale.Yerlestir(this.Kareler, true);
            At.Yerlestir(this.Kareler, true);
            Fil.Yerlestir(this.Kareler, true);
            Piyon.Yerlestir(this.Kareler, true);
            Sah.Yerlestir(this.Kareler, true);
            Vezir.Yerlestir(this.Kareler, true);
        }

        private void KareleriYarat()
        {
            int x = 0;
            int y = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Kare kare = new Kare();
                    kare.Koordinat.X = i;
                    kare.Koordinat.Y = j;

                    if (j % 2 == 0)
                    {
                        if (i % 2 == 0)
                        {
                            kare.Renk = Renk.Beyaz;
                        }
                        else
                        {
                            kare.Renk = Renk.Siyah;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            kare.Renk = Renk.Siyah;
                        }
                        else
                        {
                            kare.Renk = Renk.Beyaz;
                        }
                    }

                    kare.Durum = KareDurum.Bos;
                    Kareler.Add(kare);

                    y += 100;
                }
                x += 100;
                y = 0;
            }
        }

        private async Task TasıHareketEttir(OnClickModel onClickModel)
        {
            Sayac = HttpContext.Session.GetInt32("Sayac") is null ? 0 : HttpContext.Session.GetInt32("Sayac");

            if (Sayac == 0)
            {
                this.OncekiKareKoordinat = onClickModel.X.ToString() + onClickModel.Y.ToString();
                HttpContext.Session.SetString("OncekiKareKoordinat", OncekiKareKoordinat);

                if (Convert.ToBoolean(onClickModel.KareDolumu))
                {
                    Sayac++;
                    HttpContext.Session.SetInt32("Sayac", (int)Sayac);
                }
            }
            else if (Sayac == 1 && !string.IsNullOrEmpty(onClickModel.Id))
            {
                var tahta = await _tahtaService.GetAsync(onClickModel.Id);

                if (tahta is not null)
                {
                    Kareler = JsonConvert.DeserializeObject<List<Kare>>(tahta.Kareler);

                    CastGeriAl();
                }

                OncekiKareKoordinat = HttpContext.Session.GetString("OncekiKareKoordinat");

                Kare oncekiKare = Kareler.Where(kare => kare.Koordinat.X.ToString() + kare.Koordinat.Y.ToString() == OncekiKareKoordinat).FirstOrDefault();

                if (oncekiKare.Tas is not null && onClickModel.X.ToString() + onClickModel.Y.ToString() != OncekiKareKoordinat)
                {    
                    Kare hedefKare = Kareler.Where(kare => kare.Koordinat.X.ToString() + kare.Koordinat.Y.ToString() == onClickModel.X.ToString() + onClickModel.Y.ToString()).FirstOrDefault();

                    oncekiKare.Tas.HareketEt(oncekiKare, hedefKare, this.Kareler, oncekiKare.Tas.UygunKareleriHesapla);

                    CastYap();

                    var tahtaKoleksiyon = new TahtaEntity
                    {
                        Id = onClickModel.Id,
                        Kareler = JsonConvert.SerializeObject(Kareler)
                    };

                    if(tahta is not null)
                    {
                        await _tahtaService.UpdateAsync(tahtaKoleksiyon.Id, tahtaKoleksiyon);
                    }
                    else
                    {
                        await _tahtaService.CreateAsync(tahtaKoleksiyon);
                    }   
                }

                Sayac--;
                HttpContext.Session.SetInt32("Sayac", (int)Sayac);
            }
        }

        private void CastYap()
        {

            List<Kare> kareler = Kareler.Where(k => k.Durum == KareDurum.Dolu).ToList();

            foreach (var kare in kareler)
            {
                switch (kare.Tas.Isim)
                {
                    case "Fil":
                        kare.TasTipleri.Fil = (Fil)kare.Tas;

                        break;
                    case "Sah":
                        kare.TasTipleri.Sah = (Sah)kare.Tas;

                        break;
                    case "At":
                        kare.TasTipleri.At = (At)kare.Tas;

                        break;
                    case "Piyon":
                        kare.TasTipleri.Piyon = (Piyon)kare.Tas;

                        break;
                    case "Vezir":
                        kare.TasTipleri.Vezir = (Vezir)kare.Tas;

                        break;
                    case "Kale":
                        kare.TasTipleri.Kale = (Kale)kare.Tas;

                        break;
                    default:
                        break;
                }

                kare.Tas = null;
            }
        }

        private void CastGeriAl()
        {
            List<Kare> kareler = Kareler.Where(t => t.TasTipleri.Fil != null || t.TasTipleri.Sah != null || t.TasTipleri.At != null || t.TasTipleri.Piyon != null || t.TasTipleri.Vezir != null || t.TasTipleri.Kale != null).ToList();

            foreach (var kare in kareler)
            {
                if (kare.TasTipleri.Fil != null)
                {
                    kare.Tas = kare.TasTipleri.Fil;
                    kare.TasTipleri.Fil = null;
                }
                else if (kare.TasTipleri.Sah != null)
                {
                    kare.Tas = kare.TasTipleri.Sah;
                    kare.TasTipleri.Sah = null;
                }
                else if (kare.TasTipleri.At != null)
                {
                    kare.Tas = kare.TasTipleri.At;
                    kare.TasTipleri.At = null;
                }
                else if (kare.TasTipleri.Piyon != null)
                {
                    kare.Tas = kare.TasTipleri.Piyon;
                    kare.TasTipleri.Piyon = null;
                }
                else if (kare.TasTipleri.Vezir != null)
                {
                    kare.Tas = kare.TasTipleri.Vezir;
                    kare.TasTipleri.Vezir = null;
                }
                else if (kare.TasTipleri.Kale!= null)
                {
                    kare.Tas = kare.TasTipleri.Kale;
                    kare.TasTipleri.Kale = null;
                }
            }
        }
    }
}
