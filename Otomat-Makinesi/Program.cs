using System.Globalization;
namespace Otomat_Makinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] ürünler = { "Kola", "Cips", "Kraker" };
                double[] fiyatlar = { 10, 20, 30 };
                string[] apanel = { "Ürün ekle", "Ürün güncelle", "Ürün sil", "Ürün listele", "Ana menü" };
                double para = 0;
                int secim, hak = 3;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("------------------Otomat Makinesi------------------");
                    for (int i = 0; i < ürünler.Length; i++)
                    {
                        Console.WriteLine($"{i}-{ürünler[i]} Fiyat: {fiyatlar[i]}");
                    }
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("-Lütfen satın almak istediğiniz ürünün numarasını giriniz.\n-Admin girişi yapmak için ('99') yazınız.\n-Programdan çıkış yapmak için ('100') yazınız.");
                    secim = Convert.ToInt32(Console.ReadLine());
                    if (secim == 99)
                    {
                        while (true)
                        {
                            while (true)
                            {
                                if (hak == 0)
                                {
                                    break;
                                }
                                Console.Clear();
                                Console.WriteLine("Admin paneline erişmek için kullanıcı adınızı ve şifrenizi girmeniz gerekiyor.\nGiriş işlemi için aktarılıyorsunuz lütfen bekleyiniz.");
                                Thread.Sleep(3000);
                                Console.Clear();
                                Console.WriteLine("Kullanıcı adınızı giriniz.");
                                string kad = Console.ReadLine().ToLower();
                                Console.WriteLine("Şifrenizi giriniz.");
                                int sifre = Convert.ToInt32(Console.ReadLine());
                                if (kad == "admin" && sifre == 1234)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Admin paneline başarıyla giriş yaptınız. Lütfen bekleyiniz.");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("------------------Admin Panel------------------");
                                        for (int i = 0; i < apanel.Length; i++)
                                        {
                                            Console.WriteLine($"{i}-{apanel[i]}");
                                        }
                                        Console.WriteLine("-----------------------------------------------");
                                        Console.WriteLine("Yapmak istediğiniz işlemin numarasını tuşlayınız.");
                                        int secimb = Convert.ToInt32(Console.ReadLine());
                                        if (secimb == 4)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ana menüye aktarılıyorsunuz lütfen bekleyiniz.");
                                            Thread.Sleep(3000);
                                            break;
                                        }
                                        else if (secimb >= 0 && secimb < apanel.Length)
                                        {
                                            switch (secimb)
                                            {
                                                case 0:
                                                    Console.Clear();
                                                    Console.WriteLine("Eklemek istediğiniz ürünün adını giriniz.");
                                                    string ürünekleme = Console.ReadLine().ToLower();
                                                    ürünekleme = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ürünekleme);
                                                    int index = Array.IndexOf(ürünler, ürünekleme);
                                                    if (index >= 0)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("HATA!\nEklemek istediğiniz ürün mevcut. Tekrar deneyiniz\n");
                                                        Thread.Sleep(3000);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("{0} ürünün fiyatını giriniz", ürünekleme);
                                                        double ürünfiyatekle = Convert.ToDouble(Console.ReadLine());
                                                        while (ürünfiyatekle < 0)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Hatalı değer girdiniz lütfen tekrar deneyiniz.");
                                                            Thread.Sleep(3000);
                                                            Console.Clear();
                                                            Console.WriteLine("{0} ürünün fiyatını giriniz", ürünekleme);
                                                            double ürünfiyatekle2 = Convert.ToDouble(Console.ReadLine());
                                                            ürünfiyatekle = ürünfiyatekle2;
                                                        }
                                                        string[] geçiciürünler = new string[ürünler.Length + 1];
                                                        double[] geçicifiyatlar = new double[fiyatlar.Length + 1];
                                                        for (int z = 0; z < ürünler.Length; z++)
                                                        {
                                                            geçiciürünler[z] = ürünler[z];
                                                            geçicifiyatlar[z] = fiyatlar[z];
                                                        }
                                                        geçiciürünler[geçiciürünler.Length - 1] = ürünekleme;
                                                        geçicifiyatlar[geçicifiyatlar.Length - 1] = ürünfiyatekle;
                                                        ürünler = geçiciürünler;
                                                        fiyatlar = geçicifiyatlar;
                                                        Console.Clear();
                                                        Console.WriteLine("Ürün başarıyla eklendi.\nAdmin paneline tekrardan aktarılıyorsunuz");
                                                        Thread.Sleep(3000);
                                                        break;
                                                    }
                                                case 1:
                                                    Console.Clear();
                                                    for (int f = 0; f < ürünler.Length; f++)
                                                    {
                                                        Console.WriteLine($"{f}-{ürünler[f]} Fiyat: {fiyatlar[f]}");
                                                    }
                                                    Console.WriteLine("Güncellemek istediğiniz ürünün numarasını tuşlayınız.");
                                                    int güncellenecekindeksno = Convert.ToInt32(Console.ReadLine());
                                                    if (güncellenecekindeksno >= 0 && güncellenecekindeksno < ürünler.Length)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Ürünün yeni adını giriniz.");
                                                        string ürünyeniad = Console.ReadLine().ToLower();
                                                        ürünyeniad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ürünyeniad);
                                                        Console.WriteLine("{0} ürünün yeni fiyatını giriniz", ürünyeniad);
                                                        double ürünyenifiyat = Convert.ToDouble(Console.ReadLine());
                                                        while (ürünyenifiyat < 0)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Hatalı değer girdiniz lütfen tekrar deneyiniz.");
                                                            Thread.Sleep(3000);
                                                            Console.Clear();
                                                            Console.WriteLine("{0} ürünün yeni fiyatını giriniz", ürünyeniad);
                                                            double ürünyenifiyat2 = Convert.ToDouble(Console.ReadLine());
                                                            ürünyenifiyat = ürünyenifiyat2;
                                                        }
                                                        ürünler[güncellenecekindeksno] = ürünyeniad;
                                                        fiyatlar[güncellenecekindeksno] = ürünyenifiyat;
                                                        Console.Clear();
                                                        Console.WriteLine("Ürün bilgileri başarıyla güncellendi.\nTekrar admin panele aktarılıyorsunuz lütfen bekleyiniz.");
                                                        Thread.Sleep(3000);
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("HATA!\nYanlış tuşlama yaptığınız için admin panele tekrardan aktarılıyorsunuz lütfen bekleyiniz.");
                                                        Thread.Sleep(4000);
                                                        break;
                                                    }
                                                case 2:
                                                    Console.Clear();
                                                    for (int n = 0; n < ürünler.Length; n++)
                                                    {
                                                        Console.WriteLine($"{n}-{ürünler[n]} Fiyat: {fiyatlar[n]}");
                                                    }
                                                    Console.WriteLine("Hangi ürünü silmek istersiniz numarasını tuşlayınız.");
                                                    int silinecekNo = Convert.ToInt32(Console.ReadLine());
                                                    if (silinecekNo >= 0 && silinecekNo < ürünler.Length)
                                                    {
                                                        Console.Clear();
                                                        string gürünadı = ürünler[silinecekNo];
                                                        Console.WriteLine("{0} ürününü silmek istediğinize eminmisiniz?\nCevabınız evet ise ('0') hayır ise ('1') tuşlayınız.", gürünadı);
                                                        int secimg = Convert.ToInt32(Console.ReadLine());
                                                        if (secimg == 0)
                                                        {
                                                            for (int j = silinecekNo; j < ürünler.Length - 1; j++)
                                                            {
                                                                ürünler[j] = ürünler[j + 1];
                                                                fiyatlar[j] = fiyatlar[j + 1];
                                                            }
                                                            Array.Resize(ref ürünler, ürünler.Length - 1);
                                                            Array.Resize(ref fiyatlar, fiyatlar.Length - 1);
                                                            Console.Clear();
                                                            Console.WriteLine("Ürün başarıyla silindi.\nTekrar admin panele aktarılıyorsunuz lütfen bekleyiniz.");
                                                            Thread.Sleep(3000);
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Tekrar admin panele aktarılıyorsunuz lütfen bekleyiniz.");
                                                            Thread.Sleep(3000);
                                                            Console.Clear();
                                                            break;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("HATA!\nYanlış tuşlama yaptığınız için admin panele tekrardan aktarılıyorsunuz lütfen bekleyiniz.");
                                                        Thread.Sleep(4000);
                                                        break;
                                                    }
                                                case 3:
                                                    Console.Clear();
                                                    for (int a = 0; a < ürünler.Length; a++)
                                                    {
                                                        Console.WriteLine($"{a}-{ürünler[a]} Fiyat: {fiyatlar[a]}");
                                                    }
                                                    Console.WriteLine("Admin panele dönmek için bir tuşa basınız.");
                                                    Console.ReadKey();
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Hatalı tuşlama yaptınız\nAdmin panele aktarılıyorsunuz lütfen bekleyiniz.");
                                            Thread.Sleep(3000);
                                            continue;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    hak--;
                                    Console.Clear();
                                    Console.WriteLine("Kullanıcı adı veya şifre yanlış lütfen bekleyiniz.\nKalan hakkınız: {0}", hak);
                                    Thread.Sleep(3000);
                                    continue;
                                }
                            }
                            if (hak == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Üst üste üç kere hatalı giriş yaptınız hesabınız kilitlendi.\nHesap kilidi on saniye sonra açılacaktır lütfen bekleyiniz.");
                                Thread.Sleep(10000);
                                Console.Clear();
                                Console.WriteLine("Hesap kilidi açılmıştır sabrınız için teşekkürler\nAna menüye dönmek için (0) tekrar admin girişi yapmak için (1) tuşuna basınız.");
                                int secimb = Convert.ToInt32(Console.ReadLine());
                                if (secimb == 0)
                                {
                                    hak = 3;
                                    break;
                                }
                                else
                                {
                                    hak = 3;
                                    continue;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (secim == 100)
                    {
                        Console.Clear();
                        Console.WriteLine("Programdan çıkış yapıyorsunuz lütfen bekleyiniz.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                    else if (secim >= 0 && secim < ürünler.Length)
                    {
                        double ürünfiyat = fiyatlar[secim];
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Girdiğiniz bilgiler kontrol ediliyor lütfen bekleyiniz.");
                            Thread.Sleep(3000);
                            if (para < ürünfiyat)
                            {
                                Console.Clear();
                                Console.WriteLine("Bakiyeniz yetersiz. Lütfen bakiye yüklemesi yapın.\nAna menüye dönmek için (0) bakiye yüklemesi yapmak için (1) tuşuna basınız.");
                                int secima = Convert.ToInt32(Console.ReadLine());
                                if (secima == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Kalan bakiyeniz: {0}\nAna menüye aktarılıyorsunuz lütfen bekleyiniz.", para);
                                    Thread.Sleep(3000);
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Bakiye yükleme ekranına aktarılıyorsunuz lütfen bekleyiniz.");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    Console.WriteLine("Bakiyeniz: {0}\nYüklemek istediğiniz bakiyeyi tuşlayınız.", para);
                                    double secimbakiye = Convert.ToDouble(Console.ReadLine());
                                    while (secimbakiye <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Hatalı değer girdiniz lütfen tekrar deneyiniz.");
                                        Thread.Sleep(3000);
                                        Console.Clear();
                                        Console.WriteLine("Bakiyeniz: {0}\nYüklemek istediğiniz bakiyeyi tuşlayınız.", para);
                                        secimbakiye = Convert.ToDouble(Console.ReadLine());
                                    }
                                    para += secimbakiye;
                                    continue;
                                }
                            }
                            else
                            {
                                for (int i = 0; i < ürünler.Length; i++)
                                {
                                    if (secim == i)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"{ürünler[i]} seçtiğiniz ürünü başarıyla aldınız");
                                        Thread.Sleep(4000);
                                    }
                                }
                                for (int j = secim; j < ürünler.Length - 1; j++)
                                {
                                    ürünler[j] = ürünler[j + 1];
                                    fiyatlar[j] = fiyatlar[j + 1];
                                }
                                Array.Resize(ref ürünler, ürünler.Length - 1);
                                Array.Resize(ref fiyatlar, fiyatlar.Length - 1);
                                Console.Clear();
                                Console.WriteLine("Stok eksiltildi\nAna menüye dönmek için (0) programı sonlandırmak için (1) tuşuna basınız.");
                                Thread.Sleep(3000);
                                secim = Convert.ToInt32(Console.ReadLine());
                                if (secim == 0)
                                {
                                    para -= ürünfiyat;
                                    Console.Clear();
                                    Console.WriteLine("Kalan bakiyeniz: {0}\nAna menüye aktarılıyorsunuz lütfen bekleyiniz.", para);
                                    Thread.Sleep(5000);
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("İyi günler tekrar bekleriz.");
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Hatalı tuşlama yaptınız tekrar deneyiniz.\nAna menüye aktarılıyorsunuz lütfen bekleyiniz.");
                        Thread.Sleep(3000);
                        continue;
                    }
                }
            }
            catch (FormatException hata)
            {
                Console.WriteLine("Hata oluştu! " + hata.Message);
            }
            catch (Exception hata)
            {
                Console.WriteLine("Hata oluştu! " + hata.Message);
            }
            finally
            {
                Console.WriteLine("İyi günler.");
            }
            Console.ReadKey();
        }
    }
}
