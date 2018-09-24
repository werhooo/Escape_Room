using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Escape_room
{
    class global
    {
        public string[] currentPlace = new string[]{"nappali","fürdőszoba" }; // 0-nappali, 1-fürdőszoba
    }

   

    class Program
    {
        
        public static void welcomeScreen()
        {

            Console.WindowWidth = 90;
            Console.WriteLine();
            Console.WriteLine(@"███████╗███████╗ ██████╗ █████╗ ██████╗ ███████╗    ██████╗  ██████╗  ██████╗ ███╗   ███╗
██╔════╝██╔════╝██╔════╝██╔══██╗██╔══██╗██╔════╝    ██╔══██╗██╔═══██╗██╔═══██╗████╗ ████║
█████╗  ███████╗██║     ███████║██████╔╝█████╗      ██████╔╝██║   ██║██║   ██║██╔████╔██║
██╔══╝  ╚════██║██║     ██╔══██║██╔═══╝ ██╔══╝      ██╔══██╗██║   ██║██║   ██║██║╚██╔╝██║
███████╗███████║╚██████╗██║  ██║██║     ███████╗    ██║  ██║╚██████╔╝╚██████╔╝██║ ╚═╝ ██║
╚══════╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝     ╚══════╝    ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝     ╚═╝
                                                                                         ");
            Console.WriteLine();
            Console.WriteLine("Nyomj 'ENTER'-t a kezdéshez");
            Console.ReadLine();
            Console.Clear();





        }



        static void Main(string[] args)
        {
            //Verhóczki Márton, I2P második kör feladat - Escape_Room
            szekreny szekreny = new szekreny();
            kulcs kulcs = new kulcs();
            global global = new global();
            doboz doboz = new doboz();
            ajto ajto = new ajto();
            ablak ablak = new ablak();


           



        }

        
    }

    class szekreny
    {
        public bool nyitva = false;
        public bool eltolva = false;

        public void kinyit()
        {
            nyitva = true;
        }
        public void eltol()
        {

        }
        
    }
    class doboz
    {
        public bool nyitva = false;
        public bool ures = false;
        public string hely = "nappali";

        public void kinyit()
        {
            nyitva = true;
        }
    }
    class kulcs
    {
        public bool nalad = false;
        public string hely = "nappali";

        public void vedd_fel()
        {
            nalad = true;
        }
        public void rakd_le()
        {
            
        }



    }
    class ajto
    {
        public bool nyitva = false;
        
    }
    class ablak
    {
        public bool betorve = false;
    }





}










