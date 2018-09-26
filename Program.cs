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
        Program program = new Program();
       public int currentPlace = 1; // 1 nappali, -1 fürdőszoba
       public static void nappaliInfo()
       {
            Program.writeFancy("A nappaliban vagy, tőled jobbra van észak. Előtted (nyugatra) van egy ajtó, tőled jobbra(észak) egy szekrény, mögötted(kelet) pedig egy ágy");
            
       }
       public static void furdoszobaInfo()
       {
            Program.writeFancy("A fürdőszobában vagy, a szobában van egy kád. A nappaliba vissza tudsz menni keletre");
       }
        public static void szekrenyInfo()
        {
            Program.writeFancy("Ez egy szekrény, ???");  // csicska vagy

        }
        public static void dobozInfo()
        {
            Program.writeFancy("Ez egy doboz, ???");  // csicska vagy
        }
        public static void kulcsInfo()
        {
            Program.writeFancy("Ez egy kulcs, ???"); // csicska vagy
        }
        public static void ajtoInfo()
        {
            Program.writeFancy("Ez egy ajtó,?????"); // csicska vagy
        }
        public static void ablakInfo()
        {
            Program.writeFancy("Ez egy ablak,?????"); // csicska vagy
        }
        public static void feszitovasInfo()
        {
            Program.writeFancy("Ez egy feszítővas,?????"); // csicska vagy
        }
        public static void agyInfo()
        {
            Program.writeFancy("Ez egy ágy, ????");  // csicska vagy
        }
        public static void kadinfo()
        {
            Program.writeFancy("Ez egy kád, van benne egy feszítővas ????"); // csicska vagy
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
            //intro();
            string[] baseStory = new string[] { "Egy szobában térsz magadhoz", "Nem emlékszel semmire", "Mit teszel?" };
            
            writeFancy(baseStory);

            






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
                                    nézd();
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
                            case "help":
                                {
                                    help();
                                    break;
                                }
                            case "észak":
                                {
                                    észak();
                                    break;
                                }
                            case "dél":
                                {
                                    dél();
                                    break;
                                }
                            case "kelet":
                                {
                                    kelet();
                                    break;
                                }
                            case "nyugat":
                                {
                                    nyugat();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Helytelen parancsot adtál meg");

                                    break;
                                }

                        }
                    }

                    if (szokozszam == 1)
                    {
                        
                        //vár 
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
            String[] introData = new string[] { "Üdvözöllek az Escape Room című kalandjátékban", "A játék célja magától értetődő", "Juss ki a szobából", "A játékban használható parancsok: ","- menj", "- nézd", "- vedd fel", "- tedd le", "- nyisd", "- húzd", "- törd", "Ezek után kell írnod a tárgy vagy helyszín nevét amellyel a cselekvést végzed", "Különböző irányokba nézelődhetsz, ezekhez használd a 'észak,dél,kelet,nyugat' parancsokat", "Hogy megtekintsd a leltáradban lévő dolgaid, használd a 'leltár' parancsot", "A játékot a 'mentés *fájlnév*' paranccsal tudod elmenteni", "A játékot betölteni korábbi mentésről a 'betöltés *fájlnév*' paranccsal éred el","'help' paranccsal tudod megnézni a parancsokat", "Meg is vagyunk, kezdhetjük?", "A játék indításához nyomj 'ENTER'-t" };

            writeFancy(introData);
            Console.ReadKey();
            Console.Clear();
        }
        public static void writeFancy(string[] data)
        {

            for (int i = 0; i < data.Length; i++)
            {
                foreach (char x in data[i])
                {
                    Console.Write(x);
                    Thread.Sleep(55);

                }
                Thread.Sleep(200);
                Console.WriteLine();
            }
        }
        public static void writeFancy(string data)
        {
                foreach (char x in data)
                {
                    Console.Write(x);
                    Thread.Sleep(55);

                }
                Thread.Sleep(200);
                Console.WriteLine();
        }
        
        public static void nézd()
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
        public static void nézd(string item)
        {
            global global = new global();
            szekreny szekreny = new szekreny();
            doboz doboz = new doboz();
            kad kad = new kad();
        
            if (item == "szekrény" && global.currentPlace == 1)
            {
                global.szekrenyInfo();

            }
            else if (item == "ágy" && global.currentPlace == 1)
            {
                global.agyInfo();
            }
            else if (item == "kád" && global.currentPlace == -1)
            {
                global.kadinfo();
            }
            else if (item == "ajtó")
            {
                global.ajtoInfo();
            }
            else if (item == "ablak" && global.currentPlace == 1 && szekreny.eltolva == true )
            {
                global.ablakInfo();
            }
            else if (item == "doboz" &&  global.currentPlace == 1 && szekreny.nyitva == true)
            {
                global.dobozInfo();
            }
            else if (item == "kulcs" &&  global.currentPlace == 1 && szekreny.nyitva == true && doboz.nyitva == true && doboz.ures == false )
            {
                global.kulcsInfo();
            }
            else if (item == "feszítővas" && global.currentPlace == -1 && kad.megnezve == true)
            {
                global.feszitovasInfo();
            }
            else
            {
                Program.writeFancy("Ezt nem tudod nézni");
            }


        }

        public static void menj(string item)


        {
            global global = new global();
            szekreny szekreny = new szekreny();
            doboz doboz = new doboz();
            kad kad = new kad();
            ajto ajto = new ajto();
            ablak ablak = new ablak();
            

            if (item == "szekrény" && global.currentPlace == 1)
            {
                szekreny.ottvagy();
                

            }
            else if (item == "ágy" && global.currentPlace == 1)
            {

                Program.writeFancy("Az ágynál vagy");
            }
            else if (item == "kád" && global.currentPlace == -1)
            {
                kad.ottvagy();
                
            }
            else if (item == "ajtó")
            {
                ajto.ottvagy();
            }
            else if (item == "ablak" && global.currentPlace == 1 && szekreny.eltolva == true)
            {
                ablak.ottvagy(); /////////////////////////////////
                

            }
            else if (item == "doboz" && global.currentPlace == 1 && szekreny.nyitva == true)
            {
                doboz.ottvagy();
            }
            //else if (item == "kulcs" && global.currentPlace == 1 && szekreny.nyitva == true && doboz.nyitva == true && doboz.ures == false)
            //{
                
            //}
            //else if (item == "feszítővas" && global.currentPlace == -1 && kad.megnezve == true)
            //{
            //    global.feszitovasInfo();
            //}
            else
            {
                Program.writeFancy("Ehhez nem tudsz menni");
            }
        
        }
        public static void help()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Parancsok: ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("---észak, dél, kelet, nyugat----");
            Console.WriteLine("---nézd----");
            Console.WriteLine("---nézd-------- *tárgy neve*");
            Console.WriteLine("---vedd fel---- *tárgy neve*");
            Console.WriteLine("---tedd le----- *tárgy neve*");
            Console.WriteLine("---nyisd------- *tárgy neve*");
            Console.WriteLine("---húzd-------- *tárgy neve*");
            Console.WriteLine("---törd-------- *tárgy neve*");
            Console.WriteLine("---leltár------");
            Console.WriteLine("---mentés------ *file neve*");
            Console.WriteLine("---betöltés---- *file neve*");
            Console.WriteLine("---help--------");
            Console.ResetColor();
        }

        public static void észak()
        {
            global global = new global();
            if (global.currentPlace == 1)
            {

                writeFancy("Északra egy szekrény található.");
            }
            else if (global.currentPlace == -1)
            {
                writeFancy("Északra nincs semmi.");
            }
        }
        public static void dél()
        {
            global global = new global();
            if (global.currentPlace == 1)
            {
                writeFancy("Délre nincs semmi");
            }
            else if (global.currentPlace == -1)
            {
                writeFancy("Délre nincs semmi.");
            }

        }
        public static void kelet()
        {
            global global = new global();
            if (global.currentPlace == 1)
            {
                writeFancy("Keletre egy ágy található");
            }
            else if (global.currentPlace == -1)
            {
                writeFancy("Keletre a nappali van.");
            }
        }
        public static void nyugat()
        {
            global global = new global();
            if (global.currentPlace == 1)
            {
                writeFancy("Nyugatra egy ajtó található");
            }
            else if (global.currentPlace == -1)
            {
                writeFancy("Nyugatra egy kád található");
            }
        }


    }

    //Item Classok
    class szekreny
    {
       
        public bool nyitva = false;
        public bool eltolva = false;
        public bool ottvagye = false;


        public void nyisd()
        {
            nyitva = true;
        }
        public void huzd()
        {
            eltolva = true;
        }
        public void ottvagy()
        {
            ottvagye = true;
            Program.writeFancy("A szekrénynél vagy");
        }
        
    }
    class doboz
    {
        
        public bool nyitva = false;
        public bool ures = false;
        public bool ottvagye = false;

        public void nyisd()
        {
            nyitva = true;
        }
        public void ottvagy()
        {
            ottvagye = true;
        }
    }
    class kulcs
    {
        public string hely = "nappali";
        public bool nalad = false;

        public void vedd_fel()
        {
            doboz doboz = new doboz();
            doboz.ures = true;
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
        public bool ottvagye = false;

        public void nyisd()
        {
            nyitva = true;
        }
        public void ottvagy()
        {
            ottvagye = true;
            Program.writeFancy("Az ajtónál vagy");
        }
    }
    class ablak
    {
        public bool betorve = false;
        public bool ottvagye = false;
        public void törd()
        {
            betorve = true;
        }
        public void ottvagy()
        {
            ottvagye = true;
            Program.writeFancy("Az ablaknál vagy");
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
        }
    }
    class kad
    {
        public bool ottvagye = false;
        public bool megnezve = false;

        public void ottvagy()
        {
            ottvagye = true;
            Program.writeFancy("A kádnál vagy, van benne egy feszítővas");
        }
        public void megnez()
        {
            megnezve = true;
        }

    }

}










