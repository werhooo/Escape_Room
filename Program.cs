using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace Escape_room
//Verhóczki Márton, I2P második kör feladat - Escape_Room
{
    //Állandók tárolása
    class global
    {
       public int currentPlace = -1; // 1 nappali, -1 fürdőszoba
       public static void nappaliInfo()
       {
            Console.WriteLine("A nappaliban vagy, tőled jobbra van észak. Előtted (nyugatra) van egy ajtó, tőled jobbra(észak) pedig egy szekrény.");
       }
       public static void furdoszobaInfo()
       {
            Console.WriteLine("A fürdőszobában vagy, a szobában van egy kád.");
       }

    }
    //Fő class
    class Program
    {
        static void Main(string[] args)
        {

            //classok megghívása
            szekreny szekreny = new szekreny();
            kulcs kulcs = new kulcs();
            global global = new global();
            doboz doboz = new doboz();
            ajto ajto = new ajto();
            ablak ablak = new ablak();

            //----------------------------------------


            welcomeScreen();
            intro();

            Console.WriteLine("Egy szobában térsz magadhoz");
            Console.ReadKey();
            Console.WriteLine("Nem emlékszel semmire");
            Console.ReadKey();
            Console.WriteLine("Mit teszel?");

            //parancs bekérése, kiértékelése
            //ha a felhasználó véletlenül entert nyom, vagy rosszul ütni be a parancsot, hibaüzenetet kap. és megy tovább a loop
            bool uiError = true;
            do
            {
                string UI = Console.ReadLine();
                if (UI == "")
                {
                   
                    uiError = true;
                }
                if (uiError)
                {
                    string[] temp = new string[3]; // max 3 tagú lehet a parancs
                    int szokozszam = 0; //0 szóköz = 1 tagú stb.
                    foreach (char x in UI)
                    {
                        if (x == ' ')
                        {
                            szokozszam++;
                        }
                    }

                    if (szokozszam == 0)
                    {
                        temp[0] = UI;

                    }
                    else if (szokozszam == 1)
                    {
                        temp[0] = UI.Split(' ')[0];
                        temp[1] = UI.Split(' ')[1];
                    }
                    else if (szokozszam == 2)
                    {
                        temp[0] = UI.Split(' ')[0];
                        temp[1] = UI.Split(' ')[1];
                        temp[2] = UI.Split(' ')[2];

                    }
                    

                    if (szokozszam == 0)
                    {
                        switch (temp[0])
                        {
                            case "menj":
                                {
                                    Console.WriteLine("Nem adtad meg hová szeretnél menni");
                                    
                                    break;
                                }
                            case "nézd":
                                {
                                    nezd();
                                    break;

                                }
                                
                            case "nyisd":
                                {
                                    Console.WriteLine("Nem adtad meg mit szeretnél kinyitni");
                                   
                                    break;
                                }

                            case "húzd":
                                {
                                    Console.WriteLine("Nem adtad meg mit szeretnél húzni");
                                    
                                    break;
                                }

                            case "törd":
                                {
                                    Console.WriteLine("Nem adtad meg mit szeretnél törni");
                                    
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Helytelen parancsot adtál meg");
                                    
                                    break;
                                }

                        }
                    }


                    
                }
            } while (uiError);





        }

        public static void welcomeScreen()
        {
            Console.WindowWidth = 120;
            Console.WriteLine();
            Console.WriteLine(@"                ███████╗███████╗ ██████╗ █████╗ ██████╗ ███████╗    ██████╗  ██████╗  ██████╗ ███╗   ███╗
                ██╔════╝██╔════╝██╔════╝██╔══██╗██╔══██╗██╔════╝    ██╔══██╗██╔═══██╗██╔═══██╗████╗ ████║
                █████╗  ███████╗██║     ███████║██████╔╝█████╗      ██████╔╝██║   ██║██║   ██║██╔████╔██║
                ██╔══╝  ╚════██║██║     ██╔══██║██╔═══╝ ██╔══╝      ██╔══██╗██║   ██║██║   ██║██║╚██╔╝██║
                ███████╗███████║╚██████╗██║  ██║██║     ███████╗    ██║  ██║╚██████╔╝╚██████╔╝██║ ╚═╝ ██║
                ╚══════╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝     ╚══════╝    ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝     ╚═╝ ");
            Console.WriteLine();
            Console.WriteLine("Made By.: Verhóczki Márton");
            Console.WriteLine();
            Console.WriteLine("Nyomj 'ENTER'-t a kezdéshez");
            Console.ReadLine();
            Console.Clear();
        }

        public static void intro()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Nyomj 'ENTER'-t hogy továbblépj");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Üdvözöllek az Escape Room című kalandjátékban");
            Console.ReadKey();
            Console.WriteLine("A játék célja magától értetődő");
            Console.ReadKey();
            Console.WriteLine("Juss ki a szobából");
            Console.ReadKey();
            Console.WriteLine("A játékban használható parancsok: ");
            Console.ReadKey();
            Console.WriteLine("menj");
            Console.WriteLine("nézd");
            Console.WriteLine("vedd fel");
            Console.WriteLine("tedd le");
            Console.WriteLine("nyisd");
            Console.WriteLine("húzd");
            Console.WriteLine("törd");
            Console.WriteLine("Ezek után kell írnod a tárgy vagy helyszín nevét amellyel a cselekvést végzed");
            Console.ReadKey();
            Console.WriteLine("Különböző irányokba mehetsz, ezekhez használd a 'menj *észak,dél,kelet,nyugat*en' parancsokat");
            Console.ReadKey();
            Console.WriteLine("Hogy megtekintsd a leltáradban lévő dolgaid, használd a 'leltár' parancsot");
            Console.ReadKey();
            Console.WriteLine("A játékot a 'mentés *fájlnév*' paranccsal tudod elmenteni");
            Console.ReadKey();
            Console.WriteLine("A játékot betölteni korábbi mentésről a 'betöltés *fájlnév*' paranccsal éred el");
            Console.ReadKey();
            Console.WriteLine("Meg is vagyunk, kezdhetjük?");
            Console.WriteLine("A játék indításához nyomj 'ENTER'-t");
            Console.ReadKey();
            Console.Clear();
        }

        public static void nezd()
        {
            global global = new global();
            if (global.currentPlace == 1)
            {
                global.nappaliInfo();
            }
            if (global.currentPlace == -1)
            {
                global.furdoszobaInfo();
            }
        }


        }
    //Item Classok
    class szekreny
    {
       
        public bool nyitva = false;
        public bool eltolva = false;
        

        public void nyisd()
        {
            nyitva = true;
        }
        public void huzd()
        {

        }
        
    }
    class doboz
    {
        
        public bool nyitva = false;
        public bool ures = false;

        public void nyisd()
        {
            nyitva = true;
        }
    }
    class kulcs
    {
        public string hely = "nappali";
        public bool nalad = false;

        public void vedd_fel()
        {
            nalad = true;
        }
        public void tedd_le(string currentPlace)
        {
            hely = currentPlace;
        }
    }
    class ajto
    {
        public bool nyitva = false;

        public void nyisd()
        {
            nyitva = true;
        }
    }
    class ablak
    {
        public bool betorve = false;
        public void törd()
        {
            betorve = true;
        }
    }
    class feszitovas
    {
        public bool nalad = false;
        public string hely = "fürdőszoba";
        public void vedd_fel()
        {
            nalad = true;
        }
        public void tedd_le(string currentPlace)
        {
            hely = currentPlace;

            //Verhóczki Márton, I2P második kör feladat - Escape_Room

        }
    }





}










