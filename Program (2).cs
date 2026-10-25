namespace OtomatMakinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urunler = new string[20];   // en fazla 20 ürün
            double[] fiyatlar = new double[20];
            int urunSayisi = 5;                  // şu an kaç ürün var
            urunler[0] = "Çikolata"; fiyatlar[0] = 50;
            urunler[1] = "Bisküvi"; fiyatlar[1] = 35;
            urunler[2] = "Cips"; fiyatlar[2] = 40;
            urunler[3] = "Soda"; fiyatlar[3] = 25;
            urunler[4] = "Su"; fiyatlar[4] = 10;
            double bakiye = 0;
            while (true)
            {
                Console.WriteLine("=== Otomat Makinesine Hoşgeldiniz! ===");
                int no = 0;
                foreach (var urun in urunler) if (urun != null) Console.WriteLine($"{no}. {urun} - {fiyatlar[no++]} TL");
                Console.WriteLine("Lütfen almak istediğiniz ürünün numarasını giriniz:");
                int secim;
                if (!int.TryParse(Console.ReadLine(), out secim)) { Console.WriteLine("Geçersiz giriş!"); continue; }
                if (secim == 100)
                {
                    Console.WriteLine("Yönetici Paneline Hoşgeldiniz!");
                    bool panelAcik = true;
                    while (panelAcik)
                    {
                        Console.WriteLine("\n0-Ürün Taşıma\n1-Ürün Ekle\n2-Ürün Sil\n3-Fiyat Güncelle\n4-Çıkış\nSeçiminiz:");
                        int yoneticiSecim;
                        if (!int.TryParse(Console.ReadLine(), out yoneticiSecim)) { Console.WriteLine("Geçersiz giriş!"); continue; }
                        no = 0;
                        if (yoneticiSecim == 0 || yoneticiSecim == 2 || yoneticiSecim == 3)
                            foreach (var urun in urunler) if (urun != null) Console.WriteLine($"{no}. {urun} - {fiyatlar[no++]} TL");

                        if (yoneticiSecim == 0)
                        {
                            int eskiUrun, yeniUrun;
                            Console.WriteLine("Taşınacak ürünün numarasını giriniz:");
                            if (!int.TryParse(Console.ReadLine(), out eskiUrun)) eskiUrun = -1;
                            Console.WriteLine("Taşınacak ürünün yeni konumunu giriniz:");
                            if (!int.TryParse(Console.ReadLine(), out yeniUrun)) yeniUrun = -1;

                            if (eskiUrun >= 0 && eskiUrun < urunSayisi && yeniUrun >= 0 && yeniUrun < urunSayisi)
                            {
                                string eskiUrunAdi = urunler[eskiUrun];
                                double eskiUrunFiyati = fiyatlar[eskiUrun];
                                urunler[eskiUrun] = urunler[yeniUrun];
                                fiyatlar[eskiUrun] = fiyatlar[yeniUrun];
                                urunler[yeniUrun] = eskiUrunAdi;
                                fiyatlar[yeniUrun] = eskiUrunFiyati;
                                Console.WriteLine("Taşınma işlemi tamamlandı.");
                            }
                            else Console.WriteLine("Hatalı ürün numarası!!");
                        }
                        else if (yoneticiSecim == 1)
                        {
                            if (urunSayisi == urunler.Length) Console.WriteLine("Makine dolu, ürün eklenemez!");
                            else
                            {
                                Console.WriteLine("Eklemek istediğiniz ürünün adını giriniz:");
                                string yeniUrun = Console.ReadLine();
                                Console.WriteLine("Eklemek istediğiniz ürünün fiyatını giriniz:");
                                double yeniFiyat;
                                if (double.TryParse(Console.ReadLine(), out yeniFiyat) && yeniFiyat > 0)
                                {
                                    urunler[urunSayisi] = yeniUrun;
                                    fiyatlar[urunSayisi++] = yeniFiyat;
                                    Console.WriteLine($"{yeniUrun} ürünü eklendi.");
                                }
                                else Console.WriteLine("Geçersiz fiyat!!");
                            }
                        }
                        else if (yoneticiSecim == 2)
                        {
                            int silinecekUrun;
                            Console.WriteLine("Silmek istediğiniz ürünün numarasını giriniz:");
                            if (!int.TryParse(Console.ReadLine(), out silinecekUrun)) silinecekUrun = -1;

                            if (silinecekUrun >= 0 && silinecekUrun < urunSayisi)
                            {
                                string silinenUrun = urunler[silinecekUrun];
                                for (int i = silinecekUrun; i < urunSayisi - 1; i++) { urunler[i] = urunler[i + 1]; fiyatlar[i] = fiyatlar[i + 1]; }
                                urunSayisi--;
                                urunler[urunSayisi] = null;
                                fiyatlar[urunSayisi] = 0;
                                Console.WriteLine($"{silinenUrun} ürünü silindi.");
                            }
                            else Console.WriteLine("Hatalı ürün numarası!!");
                        }
                        else if (yoneticiSecim == 3)
                        {
                            int guncellenecekUrun;
                            double yeniFiyat;
                            Console.WriteLine("Fiyatını güncellemek istediğiniz ürünün numarasını giriniz:");
                            if (!int.TryParse(Console.ReadLine(), out guncellenecekUrun)) guncellenecekUrun = -1;

                            if (guncellenecekUrun >= 0 && guncellenecekUrun < urunSayisi)
                            {
                                Console.WriteLine($"Yeni fiyatı giriniz ({urunler[guncellenecekUrun]}):");
                                if (double.TryParse(Console.ReadLine(), out yeniFiyat) && yeniFiyat > 0)
                                {
                                    fiyatlar[guncellenecekUrun] = yeniFiyat;
                                    Console.WriteLine("Fiyat güncellendi.");
                                }
                                else Console.WriteLine("Geçersiz fiyat!!");
                            }
                            else Console.WriteLine("Hatalı ürün numarası!!");
                        }
                        else if (yoneticiSecim == 4) { Console.WriteLine("Yönetici panelinden çıkılıyor..."); panelAcik = false; }
                        else Console.WriteLine("Hatalı seçim!!");
                    }
                }
                else if (secim >= 0 && secim < urunSayisi)
                {
                    while (true)
                    {
                        Console.WriteLine($"Seçilen ürün: {urunler[secim]} - {fiyatlar[secim]} TL | Bakiye: {bakiye} TL");
                        Console.WriteLine("Para girişi yapınız:");
                        double girilenPara;
                        if (!double.TryParse(Console.ReadLine(), out girilenPara) || girilenPara <= 0) { Console.WriteLine("Geçersiz tutar!"); continue; }
                        bakiye += girilenPara;

                        if (bakiye >= fiyatlar[secim])
                        {
                            Console.WriteLine($"{urunler[secim]} aldınız. Para üstünüz: {bakiye - fiyatlar[secim]} TL");
                            bakiye = 0;
                            break;
                        }
                        Console.WriteLine("Yetersiz bakiye.\n1 - Para İade\n2 - Para Ekle");
                        int donus;
                        int.TryParse(Console.ReadLine(), out donus);
                        if (donus == 1)
                        {
                            Console.WriteLine($"Paranız iade edildi: {bakiye} TL");
                            bakiye = 0;
                            break;
                        }
                    }
                }
                else Console.WriteLine("Hatalı ürün numarası!!");

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
