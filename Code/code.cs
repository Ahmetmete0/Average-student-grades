using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Odev
{
    class Program
    {
        static int odev1, odev2, vize, final, ogrenciSayisi;
        public static void ogrenciIslemleri()
        {
            double AAyuzde, BAyuzde, BByuzde, CByuzde, CCyuzde, DCyuzde, DDyuzde, FDyuzde, FFyuzde;
            AAyuzde = BAyuzde = BByuzde = CByuzde = CCyuzde = DCyuzde = DDyuzde = FDyuzde = FFyuzde = 0;
            double AA, BA, BB, CB, CC, DC, DD, FD, FF;
            AA = BA = BB = CC = CB = DC = DD = FD = FF = 0;
            string dosyaYolu = @"OgrenciBilgileri.txt";

            FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read); //Txt yi okutmak için kullanılır
            StreamReader sw = new StreamReader(fs);

            ogrenciSayisi = 0;
            double[] notOrtalamasi = new double[100];
            string[] isim = new string[100];
            string[] soyIsim = new string[100];
            string[] no = new string[100];
            string okunan = sw.ReadLine();
            string[] harfNotu = new string[100];

            while (okunan != null)
            {
                string[] kelime = okunan.Split(' '); // Okunan her kelimeyi tek tek diziye aktararak kullanımı kolaylaştırdım

                odev1 = Convert.ToInt32(kelime[3]); //Diziden ödev 1'i aldım
                odev2 = Convert.ToInt32(kelime[4]); //Diziden ödev 2'yi aldım
                vize = Convert.ToInt32(kelime[5]); //Diziden vizeyi aldım
                final = Convert.ToInt32(kelime[6]); //Diziden finali aldım

                notOrtalamasi[ogrenciSayisi] = (odev1 * (0.1)) + odev2 * (0.1) + vize * (0.3) + final * (0.5); //Not ortalamasını hesaplayarak bunları diziye aktardım
                isim[ogrenciSayisi] = kelime[0]; //Isim yazdırmak için isimi yazıdan çektim
                soyIsim[ogrenciSayisi] = kelime[1]; //Soyisim yazdırmak için soyismi yazıdan çektim
                no[ogrenciSayisi] = kelime[2]; //Numara yazdırmak için numarayı yazıdan çektim

                okunan = sw.ReadLine(); //Cümlenin okumanması bittiğinde diğer cümleye geçerek onu okutur
                ogrenciSayisi++; // Dizide ileri gitmek için

            }

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                if (notOrtalamasi[i] >= 90) //AA alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    AA++;
                    harfNotu[i] = "AA";
                }
                else if (notOrtalamasi[i] >= 85) //BA alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    BA++;
                    harfNotu[i] = "BA";
                }
                else if (notOrtalamasi[i] >= 80) //BB alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    BB++;
                    harfNotu[i] = "BB";
                }
                else if (notOrtalamasi[i] >= 75)//CB alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    CB++;
                    harfNotu[i] = "BC";
                }
                else if (notOrtalamasi[i] >= 65) //CC alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    CC++;
                    harfNotu[i] = "CC";
                }
                else if (notOrtalamasi[i] >= 58) //DC alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    DC++;
                    harfNotu[i] = "DC";
                }
                else if (notOrtalamasi[i] >= 50) //DD alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    DD++;
                    harfNotu[i] = "DD";
                }
                else if (notOrtalamasi[i] >= 40) //FD alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    FD++;
                    harfNotu[i] = "FD";
                }
                else if (notOrtalamasi[i] >= 0) //FF alan sayısını bulmak için ve kimin aldığını bulmak için
                {
                    FF++;
                    harfNotu[i] = "FF";
                }
            }
            AAyuzde = 100 * AA / ogrenciSayisi; //Yüzdeleri bulmak için
            BAyuzde = 100 * BA / ogrenciSayisi; //Yüzdeleri bulmak için
            BByuzde = 100 * BB / ogrenciSayisi; //Yüzdeleri bulmak için
            CByuzde = 100 * CB / ogrenciSayisi; //Yüzdeleri bulmak için
            CCyuzde = 100 * CC / ogrenciSayisi; //Yüzdeleri bulmak için
            DCyuzde = 100 * DC / ogrenciSayisi; //Yüzdeleri bulmak için
            DDyuzde = 100 * DD / ogrenciSayisi; //Yüzdeleri bulmak için
            FDyuzde = 100 * FD / ogrenciSayisi; //Yüzdeleri bulmak için
            FFyuzde = 100 * FF / ogrenciSayisi; //Yüzdeleri bulmak için

            sw.Close();
            fs.Close();

            string dosyaYolu2 = @"OgrenciKayitlari.txt";
            FileStream fs2 = new FileStream(dosyaYolu2, FileMode.OpenOrCreate, FileAccess.Write); // Txt ye yazmak için kullanılır eğer txt yoksa oluşturur
            StreamWriter sw2 = new StreamWriter(fs2);

            for (int a = 0; a < ogrenciSayisi; a++)
            {

                sw2.WriteLine(isim[a] + " " + soyIsim[a] + " " + no[a] + " " + notOrtalamasi[a] + " " + harfNotu[a]); //Bilgileri txt ye yazdırmak için
                Console.WriteLine(isim[a] + "  " + soyIsim[a] + "  " + no[a] + "  " + notOrtalamasi[a] + "  " + harfNotu[a]); //Bilgileri konsola yazdırmak için
            }

            sw2.WriteLine("AA Yüzdesi: " + AAyuzde);
            sw2.WriteLine("BA Yüzdesi: " + BAyuzde);
            sw2.WriteLine("BB Yüzdesi: " + BByuzde);
            sw2.WriteLine("CB Yüzdesi: " + CByuzde);
            sw2.WriteLine("CC Yüzdesi: " + CCyuzde);
            sw2.WriteLine("DC Yüzdesi: " + DCyuzde);
            sw2.WriteLine("DD Yüzdesi: " + DDyuzde);
            sw2.WriteLine("FD Yüzdesi: " + FDyuzde);
            sw2.WriteLine("FF Yüzdesi: " + FFyuzde);
            
            sw2.WriteLine(AA + " Kişi AA notu aldı.");
            sw2.WriteLine(BA + " Kişi BA notu aldı.");
            sw2.WriteLine(BB + " Kişi BB notu aldı.");
            sw2.WriteLine(CB + " Kişi CB notu aldı.");
            sw2.WriteLine(CC + " Kişi CC notu aldı.");
            sw2.WriteLine(DC + " Kişi DC notu aldı.");
            sw2.WriteLine(DD + " Kişi DD notu aldı.");
            sw2.WriteLine(FD + " Kişi FD notu aldı.");
            sw2.WriteLine(FF + " Kişi FF notu aldı.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("AA Yüzdesi: " + AAyuzde);
            Console.WriteLine("BA Yüzdesi: " + BAyuzde);
            Console.WriteLine("BB Yüzdesi: " + BByuzde);
            Console.WriteLine("CB Yüzdesi: " + CByuzde);
            Console.WriteLine("CC Yüzdesi: " + CCyuzde);
            Console.WriteLine("DC Yüzdesi: " + DCyuzde);
            Console.WriteLine("DD Yüzdesi: " + DDyuzde);
            Console.WriteLine("FD Yüzdesi: " + FDyuzde);
            Console.WriteLine("FF Yüzdesi: " + FFyuzde);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(AA + " Kişi AA notu aldı.");
            Console.WriteLine(BA + " Kişi BA notu aldı.");
            Console.WriteLine(BB + " Kişi BB notu aldı.");
            Console.WriteLine(CB + " Kişi CB notu aldı.");
            Console.WriteLine(CC + " Kişi CC notu aldı.");
            Console.WriteLine(DC + " Kişi DC notu aldı.");
            Console.WriteLine(DD + " Kişi DD notu aldı.");
            Console.WriteLine(FD + " Kişi FD notu aldı.");
            Console.WriteLine(FF + " Kişi FF notu aldı.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Odev1 = &10");
            Console.WriteLine("Odev2 = &10");
            Console.WriteLine("Vize = &30");
            Console.WriteLine("Final = &50");
            sw2.WriteLine("Odev1=&10");
            sw2.WriteLine("Odev2=&10");
            sw2.WriteLine("Vize=&30");
            sw2.WriteLine("Final=&50");

            sw2.Flush();
            sw2.Close();
            fs2.Close();
        }


        static void Main(string[] args)
        {
            ogrenciIslemleri();
        }
    }
}
