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
    public static class global
    {
      
       public static int currentPlace = 1; // 1 nappali, -1 fürdőszoba
       
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
            if (feszitovas.kivetted == false)
            {
                Program.writeFancy("Ez egy kád, van benne egy feszítővas ????"); // csicska vagy
            }
            else
            {
                Program.writeFancy("Ez egy üres kád");
            }
           
        }

    }

    //Fő class
    class Program
    {
        
        static void Main(string[] args)
        {
            
            welcomeScreen();
            //intro();
            

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
                                   Program.writeFancy("Nem adtad meg hová szeretnél menni");

                                    break;
                                }
                            case "nézd":
                                {
                                    nézd();
                                    break;

                                }

                            case "nyisd":
                                {
                                    Program.writeFancy("Nem adtad meg mit szeretnél kinyitni");

                                    break;
                                }

                            case "húzd":
                                {
                                    Program.writeFancy("Nem adtad meg mit szeretnél húzni");

                                    break;
                                }

                            case "törd":
                                {
                                    Program.writeFancy("Nem adtad meg mit szeretnél törni");

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
                            case "leltár":
                                {
                                    leltar();
                                    break;
                                }
                            default:
                                {
                                    Program.writeFancy("Helytelen parancsot adtál meg");

                                    break;
                                }

                        }
                    }

                    if (szokozszam == 1)
                    {

                      
                        switch (temp[0])
                        {
                            case "nézd":
                                {
                                    nézd(temp[1]);
                                    break;
                                }
                            case "menj":
                                {
                                    menj(temp[1]);
                                    break;
                                }
                            case "nyisd":
                                {
                                    nyisd(temp[1]);
                                    break;
                                }
                            case "mentés":
                                {
                                    mentes(temp[1]);
                                    break;
                                }
                            case "betöltés":
                                {
                                    betoltes(temp[1]);
                                    break;
                                }
                            case "húzd":
                                {
                                    húzd(temp[1]);
                                    break;

                                }
                            case "törd":
                                {
                                    törd(temp[1]);
                                    break;
                                }
                                
                               
                            default:
                                break;
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
            
            String[] introData = new string[] { "Üdvözöllek az Escape Room című kalandjátékban", "A játék célja magától értetődő", "Juss ki a szobából", "A játékban használható parancsok: ","- menj", "- nézd", "- vedd fel", "- tedd le", "- nyisd", "- húzd", "- törd", "Ezek után kell írnod a tárgy vagy helyszín nevét amellyel a cselekvést végzed", "Különböző irányokba nézelődhetsz, ezekhez használd a 'észak,dél,kelet,nyugat' parancsokat", "Hogy megtekintsd a leltáradban lévő dolgaid, használd a 'leltár' parancsot", "A játékot a 'mentés *fájlnév*' paranccsal tudod elmenteni", "A játékot betölteni korábbi mentésről a 'betöltés *fájlnév*' paranccsal éred el","'help' paranccsal tudod megnézni a parancsokat", "Meg is vagyunk, kezdhetjük?", "A játék indításához nyomj 'ENTER'-t" };

            writeFancy(introData);
            Console.ReadKey();
            Console.Clear();
            string[] baseStory = new string[] { "Egy szobában térsz magadhoz", "Nem emlékszel semmire", "Mit teszel?" };
            writeFancy(baseStory);
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
        public static void seholNemvagy()
        {
            
            szekreny.ottvagye = false;
            doboz.ottvagye = false;
            ajto.ottvagye = false;
            ablak.ottvagye = false;
            kad.ottvagye = false;
        }

        public static void nézd()
        {
           
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
            else if (item == "ablak" && global.currentPlace == 1 && szekreny.eltolva == true)
            {
                global.ablakInfo();
            }
            else if (item == "doboz" && global.currentPlace == 1 && szekreny.nyitva == true)
            {
                global.dobozInfo();
            }
            else if (item == "kulcs" && szekreny.nyitva == true && doboz.nyitva == true && doboz.ures == false /*&& kulcs.hely ==*/  )
            {
                global.kulcsInfo();
            }
            else if (item == "feszítővas" &&  kad.megnezve == true)
            {
                global.feszitovasInfo();
            }
            else
            {
                Program.writeFancy("Ezt nem tudod nézni");
            }


        }

        public static void nyisd(string item)
        {
            
            if (item == "ajtó" && ajto.nyitva == false && kulcs.nalad == true && ajto.ottvagye == true) 
            {
                ajto.nyisd();
                Program.writeFancy("Kinyitottad az ajtót, a fürdőszobát látod.");
            }
            else if (item == "ablak" && szekreny.eltolva == true)
            {
                Program.writeFancy("Az ablak zárva van");
            }
            else if (item == "ajtó" && kulcs.nalad == false)
            {
                Program.writeFancy("Az ajtó zárva van");
            }
            else
            {
                Program.writeFancy("Ezt nem tudod nyitni........ vagy még nem?");
            }
        }

        public static void menj(string item)


        {
            
            

            if (item == "szekrény" && global.currentPlace == 1)
            {
                seholNemvagy();
                szekreny.ottvagy();
                ablak.ottvagy();
            }
            else if (item == "ágy" && global.currentPlace == 1)
            {

                Program.writeFancy("Az ágynál vagy");
            }
            else if (item == "kád" && global.currentPlace == -1)
            {
                seholNemvagy();
                kad.ottvagy();
                
            }
            else if (item == "ajtó")
            {
                Program.writeFancy("Az ajtónál vagy");
                seholNemvagy();
                ajto.ottvagy();
                ajto.ottvagye = true;
                
                
            }
            else if (item == "ablak" && global.currentPlace == 1 && szekreny.eltolva == true)
            {
                seholNemvagy();
                ablak.ottvagy(); /////////////////////////////////
                Program.writeFancy("Az ablaknál vagy");
                

            }
            else if (item == "doboz" && global.currentPlace == 1 && szekreny.nyitva == true)
            {
                seholNemvagy();
                doboz.ottvagy();
            }
            else if (item == "kulcs" && global.currentPlace == kulcs.hely && kulcs.nalad == false && doboz.ures == true)
            {
                Program.writeFancy("A kulcsnál vagy");

            }
            else if (item == "feszítővas" && global.currentPlace == feszitovas.hely && kad.megnezve == true)
            {
                Program.writeFancy("A feszítővasnál vagy");
            }
            else if (item == "nappali")
            {
                global.currentPlace = 1;
                Program.writeFancy("A nappaliban vagy");
            }
            else if (item == "fürdőszoba" && ajto.nyitva == true)
            {
                global.currentPlace = -1;
                Program.writeFancy("A fürdőszobában vagy");
            }
            else
            {
                Program.writeFancy("Ehhez nem tudsz menni");
            }
        
        }

        public static void húzd(string item)
        {
            if (item == "szekrény" && szekreny.ottvagye == true )
            {
                szekreny.huzd();
                Program.writeFancy("Elhúztad a szekrényt, egy ablakot találsz mögötte.");
            }
            else if (item != "szekrény")
            {
                Program.writeFancy("Ezt nem tudod elhúzni.");
            }
            else if (item == "szekrény" && szekreny.ottvagye == false)
            {
                Program.writeFancy("Előbb menj a szekrényhez, hogy elhúzhasd.");
            }

           
        }
        public static void törd(string item)
        {
            if (item == "ablak" && ablak.ottvagye == true && feszitovas.nalad == true && szekreny.eltolva == true)
            {
                ablak.törd();
                Program.writeFancy("Betörted az ablakot és kijutsz a szobából, gratulálunk, nyertél");
                win();
            }
            else if (item != "ablak")
            {
                Program.writeFancy("Ezt nem tudod betörni");
            }
            else if (item == "ablak" && feszitovas.nalad == false)
            {
                Program.writeFancy("Az ablakot nem tudod betörni kézzel");
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
        public static void leltar()
        {
            Program.writeFancy("Leltár: ");
            if (kulcs.nalad == true)
            {
                Program.writeFancy(" -kulcs");
            }
            if (feszitovas.nalad == true)
            {
                Program.writeFancy(" -feszítővas");
            }
            else if (feszitovas.nalad == false && kulcs.nalad == false)
            {
                Program.writeFancy("Nincs semmi a leltáradban");
            }
            
               

            

           


        }
        public static void mentes(string filename)
        {
            /*
             Mentendő elemek
             currentPlace

             */
            StreamWriter sw = new StreamWriter(filename);

        
        }

        public static void betoltes(string filename)
        {

        }
        public static void észak()
        {
           
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
            
            if (global.currentPlace == 1)
            {
                writeFancy("Nyugatra egy ajtó található");
            }
            else if (global.currentPlace == -1)
            {
                writeFancy("Nyugatra egy kád található");
            }
        }

        public static void win()  //vár
        {

        }

        


    }

    //Item Classok
    public static class szekreny
    {
       
        public static bool nyitva = false;
        public static bool eltolva = false;
        public static bool ottvagye = false;


        public static void nyisd()
        {
            nyitva = true;
        }
        public static void huzd()
        {
            eltolva = true;
        }
        public static void ottvagy()
        {
            ottvagye = true;
            Program.writeFancy("A szekrénynél vagy");
        }
        
    }
    public static class doboz
    {
        
        public static bool nyitva = false;
        public static bool ures = false;
        public static bool ottvagye = false;

        public static void nyisd()
        {
            nyitva = true;
        }
        public static void ottvagy()
        {
            ottvagye = true;
        }
    }
    public static class kulcs
    {
        public static int hely = 1;
        public static bool nalad = true;

        public static void vedd_fel()
        {
            
            doboz.ures = true;
            nalad = true;
            
        }
        public static void tedd_le()
        {

            hely = global.currentPlace;
        }
    }
    public static class ajto
    {
        public static bool nyitva = false;
        public static bool ottvagye = false;

        public static void nyisd()
        {
            nyitva = true;
        }
        public static void ottvagy()
        {
  
            ottvagye = true;
        }
    }
    public static class ablak
    {
        public static bool betorve = false;
        public static bool ottvagye = false;
        public static void törd()
        {
            betorve = true;
        }
        public static void ottvagy()
        {
            ottvagye = true;
            
        }
    }
    public static class feszitovas
    {
        public static bool nalad = true;
        public static int hely = -1;
        public static bool kivetted = false;
        public static void vedd_fel()
        {
            nalad = true;
        }
        public static void tedd_le()
        {
            hely = global.currentPlace;
        }
    }
    public static class kad
    {
        public static bool ottvagye = false;
        public static bool megnezve = false;

        public static void ottvagy()
        {
            ottvagye = true;
            Program.writeFancy("A kádnál vagy, van benne egy feszítővas");
        }
        public static void megnez()
        {
            megnezve = true;
        }

    }
   

}










