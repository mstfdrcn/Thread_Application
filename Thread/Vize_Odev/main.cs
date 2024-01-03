using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize_Odev
{
    public class main
    {
        public static void Main(string[] args)
        {
            //Thread ilk senaryoda ilk iki thread asal üçüncü thread çift dördüncü thread de tek için
            /*ThreadIlkSenaryo threadIlk = new ThreadIlkSenaryo();
            threadIlk.main();*/
            
            //Bu Senaryoda bütün threadlere farklı olan listeler gönderiliyor sonra o threadler içinde hepsi tekrardan threadlere gönderiliyor
            /*ThreadIkınciSenaryo threadIkınci = new ThreadIkınciSenaryo();
            threadIkınci.main();*/

            //Bu senaryoda her bir threade ilk,ikinci,ucunucu ve dorduncu listeleri göndererek yaptım
            ThreadUcuncuSenaryo threadUcuncu = new ThreadUcuncuSenaryo();
            threadUcuncu.main();
        }

    }
}
