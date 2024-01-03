using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize_Odev
{
    public class ThreadIkınciSenaryo
    {
        private static object locker1 = new object();
        private static object locker2 = new object();
        private static object locker3 = new object();
        public static ArrayList BaslangicArrayList = new ArrayList();
        public static ArrayList IlkArrayList = new ArrayList();
        public static ArrayList IkinciArrayList = new ArrayList();
        public static ArrayList UcuncuArrayList = new ArrayList();
        public static ArrayList DorduncuArrayList = new ArrayList();
        public static ArrayList AsalArrayList = new ArrayList();
        public static ArrayList TekArrayList = new ArrayList();
        public static ArrayList CiftArrayList = new ArrayList();
        public void main()
        {

            BaslangicArrayList = BaslangicListDoldur(BaslangicArrayList);
            foreach (int item in BaslangicArrayList)
            {
                if (item > 0 && item <= 250000)
                {
                    IlkArrayList.Add(item);

                }
                else if (item > 250000 && item <= 500000)
                {
                    IkinciArrayList.Add(item);
                }
                else if (item > 500000 && item <= 750000)
                {
                    UcuncuArrayList.Add(item);
                }
                else if (item > 750000 && item <= 1000000)
                {
                    DorduncuArrayList.Add(item);
                }
            }
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();
            AsalArrayList.Clear();
            TekArrayList.Clear();
            CiftArrayList.Clear();
            Thread thread1 = new Thread(() =>
            {

                Thread thread1_1 = new Thread(() => { AsalListKaydet(IlkArrayList); });
                Thread thread1_2 = new Thread(() =>
                {
                    TekListKaydet(IlkArrayList);
                });
                Thread thread1_3 = new Thread(() => { CiftListKaydet(IlkArrayList); });
                thread1_1.Start();
                thread1_2.Start();
                thread1_3.Start();
                thread1_1.Join();
                thread1_2.Join();
                thread1_3.Join();
            });
            Thread thread2 = new Thread(() =>
            {
                Thread thread2_1 = new Thread(() => { AsalListKaydet(IkinciArrayList); });
                Thread thread2_2 = new Thread(() =>
                {
                    TekListKaydet(IkinciArrayList);
                });
                Thread thread2_3 = new Thread(() => { CiftListKaydet(IkinciArrayList); });
                thread2_1.Start();
                thread2_2.Start();
                thread2_3.Start();
                thread2_1.Join();
                thread2_2.Join();
                thread2_3.Join();

            });
            Thread thread3 = new Thread(() =>
            {
                Thread thread3_1 = new Thread(() => { AsalListKaydet(UcuncuArrayList); });
                Thread thread3_2 = new Thread(() =>
                {
                    TekListKaydet(UcuncuArrayList);
                });
                Thread thread3_3 = new Thread(() => { CiftListKaydet(UcuncuArrayList); });
                thread3_1.Start();
                thread3_2.Start();
                thread3_3.Start();
                thread3_1.Join();
                thread3_2.Join();
                thread3_3.Join();



            });
            Thread thread4 = new Thread(() =>
            {
                Thread thread4_1 = new Thread(() => { AsalListKaydet(DorduncuArrayList); });
                Thread thread4_2 = new Thread(() =>
                {
                    TekListKaydet(DorduncuArrayList);
                });
                Thread thread4_3 = new Thread(() => { CiftListKaydet(DorduncuArrayList); });
                thread4_1.Start();
                thread4_2.Start();
                thread4_3.Start();
                thread4_1.Join();
                thread4_2.Join();
                thread4_3.Join();


            });

            //Threadlara öncelik verdim
            /*
            thread1.Priority = ThreadPriority.AboveNormal;
            thread2.Priority = ThreadPriority.Highest;
            thread3.Priority = ThreadPriority.BelowNormal;
            thread4.Priority = ThreadPriority.BelowNormal;*/

            stopwatch1.Start();
            thread1.Start();
            stopwatch2.Start();
            thread2.Start();
            stopwatch3.Start();
            thread3.Start();
            stopwatch4.Start();
            thread4.Start();



            //Threadların Tamamlanması İçin Olması Gerekir
            thread1.Join();
            stopwatch1.Stop();
            ThreadBellekKullanımıHesaplama(thread1, "Thread1");
            Console.WriteLine($"Thread1 Geçen Süre: {stopwatch1.Elapsed.TotalSeconds} saniye");
            thread2.Join();
            ThreadBellekKullanımıHesaplama(thread2, "Thread2");
            stopwatch2.Stop();
            Console.WriteLine($"Thread2 Geçen Süre: {stopwatch2.Elapsed.TotalSeconds} saniye");
            thread3.Join();
            ThreadBellekKullanımıHesaplama(thread3, "Thread3");
            stopwatch3.Stop();
            Console.WriteLine($"Thread3 Geçen Süre: {stopwatch3.Elapsed.TotalSeconds} saniye");
            thread4.Join();
            ThreadBellekKullanımıHesaplama(thread4, "Thread4");
            stopwatch4.Stop();
            Console.WriteLine($"Thread4 Geçen Süre: {stopwatch4.Elapsed.TotalSeconds} saniye");


            //Threadların Tamamen Bitmesi İçin
            //thread1.Abort();
            //thread2.Abort();
            //thread3.Abort();
            //thread4.Abort();


            //Hafızadan Tamamen Siler Threadın Sakladığı Alanı
            //GC.Collect();


            Console.WriteLine("Asal List:");
            foreach (var item in AsalArrayList)
            {
                Console.WriteLine(item);
                Thread.Sleep(40);

            }
            Thread.Sleep(40);
            Console.WriteLine("Tek List:");
            foreach (var item in TekArrayList)
            {
                Console.WriteLine(item);
                Thread.Sleep(40);

            }
            Thread.Sleep(40);
            Console.WriteLine("Çift List:");
            foreach (var item in CiftArrayList)
            {
                Console.WriteLine(item);
                Thread.Sleep(40);
            }

        }

        public void ThreadBellekKullanımıHesaplama(Thread thread, string message)
        {
            long threadMemoryUsed = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"{message}: Thread Bellek Kullanımı: {threadMemoryUsed / 1024} KB");
        }


        public void TekListKaydet(ArrayList list)
        {
            lock (locker1)
            {
                foreach (int item in list)
                {
                    if (TekCiftMi(item) == false)
                    {
                        TekArrayList.Add(item);
                        Thread.Sleep(100);
                    }
                }

            }
        }

        public void CiftListKaydet(ArrayList list)
        {
            lock (locker2)
            {
                foreach (int item in list)
                {
                    if (TekCiftMi(item) == true)
                    {
                        CiftArrayList.Add(item);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public bool TekCiftMi(int sayi)
        {
            if (sayi % 2 == 0)
            {
                return true;//Çift
            }
            return false;//Tek
        }

        public void AsalListKaydet(ArrayList list)
        {
            lock (locker3)
            {
                foreach (int item in list)
                {
                    if (AsalMi(item) == true)
                    {
                        AsalArrayList.Add(item);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public bool AsalMi(int sayi)
        {
            if (sayi <= 1)
            {
                return false;
            }

            for (int i = 2; i <= sayi / 2; i++)
            {
                if (sayi % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public ArrayList BaslangicListDoldur(ArrayList list)
        {
            for (int i = 1; i <= 1000000; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}
