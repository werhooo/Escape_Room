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
       
        //Item,szoba infok
        public static void nappaliInfo()
        {
         string[] temp = new string[] { "A nappaliban vagy, a falakra az égtájak nagy kezdőbetűi vannak felfestve. ", "Tőled jobbra észak, előre nyugat, balra dél és a hátad mögött kelet. ", "(hogy körülnézz, használd az észak, dél, kelet, nyugat parancsokat!)" };
         Program.writeFancy(temp);   
        }
        public static void furdoszobaInfo()
        {
            string[] temp = new string[] { "A fürdőszobában vagy, körbenézel és undorodva látod, hogy az egész", "fürdőszobában csak egyetlen rozsdásodó háromlábú kád van.", "A csapot valaki korábban nyitva hagyta, a lefolyó teljesen el van dugulva.", "A kád hiányzó lába helyén kiömlő vöröses víz kezdi ellepni a szobát. " };
            Program.writeFancy(temp);
        }
        public static void szekrenyInfo()
        {
            Program.writeFancy("A fal mellett egy rozoga tölgyfa szekrény."); 
        }
        public static void dobozInfo()
        {
            Program.writeFancy("A szekrényben egyetlen polc maradt, amin egy ázott, rongyos dobozt találsz."); 
        }
        public static void kulcsInfo()
        {
            Program.writeFancy("A doboz aljába süppedve látsz egy fekete kulcsot."); 
        }
        public static void ajtoInfo()
        {
            if (ajto.lattad == false)
            {
                Program.writeFancy("Ez egy ajtó.");
                Program.writeFancy("Egy ronda, padlizsán színű ajtó.");
            }
            else
            {
                Program.writeFancy("Ez ugyanaz az ajtó, csak nyitva");
                Program.writeFancy("Mit vártál?");
            }
        }
        public static void ablakInfo()
        {
            string[] temp = new string[] { "Az elhúzott szekrény mögött egy piszkos ablak látványa fogad.", "Az ablaküvegre olyan vastag porréteg telepedett, ", "hogy a beszűrődő fény nem elég ahhoz, hogy el tudd dönteni ", "milyen napszak van." };
            Program.writeFancy(temp);
        }
        public static void feszitovasInfo()
        {
            Program.writeFancy("Ez egy rozsdás feszítővas.");
        }
        public static void agyInfo()
        {
            Program.writeFancy("Az ágyból húgyszag árad.");
            Program.writeFancy("Az ocsmány, kárómintás ágyneműt itt-ott megtörik a penészvirágok.");
        }
        public static void kadinfo()
        {
            if (kad.megnezve == false)
            {
                Program.writeFancy("A vöröslő víz mélyén egy feszítővas körvonalazódik ki.");
            }
            else
            {
                Program.writeFancy("Ez ugyanaz a ronda kád, csak már kivetted belőle a ronda feszítővasat.");
                Program.writeFancy("Mit vártál?");
                
            }
           
        }

    }  

    //Fő class
    class Program
    {
        
        static void Main(string[] args)
        {
            
            welcomeScreen();
            
            intro();
            

            //parancs bekérése, kiértékelése
            //ha a felhasználó véletlenül entert nyom, vagy rosszul ütni be a parancsot, hibaüzenetet kap. és megy tovább a loop
           
            do
            {
                string UI = Console.ReadLine();
               
                    string[] temp = new string[3]; // max 3 tagú lehet a parancs
                    int szokozszam = 0; //0 szóköz = 1 tagú stb.

                    //Split
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

                    //Parancsok meghívása
                    if (szokozszam == 0)
                    {
                        switch (temp[0])
                        {
                            case "menj":
                                {
                                   writeFancy("Nem adtad meg hová szeretnél menni.");

                                    break;
                                }
                            case "nézd":
                                {
                                    nézd();
                                    break;

                                }

                            case "nyisd":
                                {
                                    writeFancy("Nem adtad meg mit szeretnél kinyitni.");

                                    break;
                                }

                            case "húzd":
                                {
                                    writeFancy("Nem adtad meg mit szeretnél húzni.");

                                    break;
                                }

                            case "törd":
                                {
                                    writeFancy("Nem adtad meg mit szeretnél törni.");

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
                                    writeFancy("Helytelen parancsot adtál meg.");

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
                                {
                                    writeFancy("Helytelen parancsot adtál meg.");
                                    break;
                                }
                                
                        }
                    }

                    if (szokozszam == 2)
                    {
                        if (temp[0] == "vedd" && temp[1] == "fel")
                        {
                            veddfel(temp[2]);
                        }
                        else if (temp[0] == "tedd" && temp[1] == "le")
                        {
                            teddle(temp[2]);
                        }
                        else
                        {
                            writeFancy("Helytelen parancsot adtál meg.");
                        }
                    }



                
            } while (true);
        }

       
      
        //Basic parancsok
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
                feszitovas.megnez();
                kad.megnez();
            }
            else if (item == "ajtó")
            {
                global.ajtoInfo();
                ajto.megnez();
            }
            else if (item == "ablak" && global.currentPlace == 1 && szekreny.eltolva == true)
            {
                global.ablakInfo();
            }
            else if (item == "doboz" && global.currentPlace == 1 && szekreny.nyitva == true)
            {
                global.dobozInfo();
               
               
            }

            else
            {
                writeFancy("Ezt nem tudod nézni.");
            }


        }
        public static void nyisd(string item)
        {

            if (item == "ajtó" && ajto.nyitva == false && kulcs.nalad == true )
            {
                ajto.nyisd();
                writeFancy("Kinyitottad az ajtót, a fürdőszobát látod.");
            }
            else if (item == "ablak" && szekreny.eltolva == true)
            {
                writeFancy("Az ablak zárva van.");
            }
            else if (item == "ajtó" && kulcs.nalad == false)
            {
                writeFancy("Az ajtó zárva van.");
            }
            else if (item == "ajtó" && ajto.nyitva == true)
            {
                writeFancy("Az ajtó már nyitva van.");
            }
            else if (item == "doboz" && szekreny.nyitva == true )
            {
                
                kulcs.megnez();
                global.kulcsInfo();
                
            }
            else if (item == "szekrény" && global.currentPlace == 1 && szekreny.nyitva == false)
            {
                szekreny.nyisd();
                doboz.megnez();
                global.dobozInfo();


            }
            
            else
            {
                writeFancy("Ezt nem tudod nyitni.");
            }
        }
        public static void menj(string item)


        {
            
            

            if (item == "szekrény")
            {
                
                global.currentPlace = 1;
                writeFancy("A szekrénynél vagy.");
            }
            else if (item == "ágy" )
            {
                global.currentPlace = 1;
                writeFancy("Az ágynál vagy.");
            }
            else if (item == "kád" && ajto.nyitva == true)
            {
               
                global.currentPlace = -1;
                writeFancy("A kádnál vagy");
            }
            else if (item == "ajtó")
            {
                writeFancy("Az ajtónál vagy.");   
            }
            else if (item == "ablak" && ajto.nyitva == true && szekreny.eltolva == true)
            {
            
                global.currentPlace = 1;
                writeFancy("Az ablaknál vagy.");
            }
            else if (item == "nappali")
            {
                global.currentPlace = 1;
                writeFancy("A nappaliban vagy.");
            }
            else if (item == "fürdőszoba" && ajto.nyitva == true)
            {
                global.currentPlace = -1;
                writeFancy("A fürdőszobában vagy.");
            }
            else
            {
                writeFancy("Ehhez nem tudsz menni.");
            }
        
        }
        public static void húzd(string item)
        {
            if (item == "szekrény" && global.currentPlace == 1)
            {
                szekreny.huzd();
                global.ablakInfo();
               
            }
            else if (item != "szekrény")
            {
                writeFancy("Ezt nem tudod elhúzni.");
            }
            else
            {
                writeFancy("Ezt nem tudod húzni.");
            }
           

           
        }
        public static void törd(string item)
        {
            if (item == "ablak" && global.currentPlace == 1 && feszitovas.nalad == true && szekreny.eltolva == true)
            {
                ablak.törd();
                string[] temp = new string[] { "Betörted az ablakot, a lehulló szilánkok mögött megpillantod a felkelő nap fényét.", "Óvatosan kilököd a keretben maradt üveg darabkákat és kimászol a hajnali homályba.", "Gratulálunk, nyertél!" };
                writeFancy(temp);
                Thread.Sleep(2000);
                win();
            }
            else if (item != "ablak")
            {
                writeFancy("Ezt nem tudod betörni.");
            }
            else if (item == "ablak" && feszitovas.nalad == false && szekreny.eltolva == true)
            {
                writeFancy("Az ablakot nem tudod betörni kézzel.");
            }
            else
            {
                writeFancy("Ezt nem tudod törni.");
            }


        }
        public static void veddfel(string item)
        {
            if (item == "kulcs" && doboz.lattad == true)
            {
                kulcs.vedd_fel();
                writeFancy("Felvetted a kulcsot, így a leltáradba került.");
            }
            else if (item == "feszítővas" && feszitovas.lattad == true)
            {
                feszitovas.vedd_fel();
                writeFancy("Felvetted a feszítővasat, így a leltáradba került.");
            }
            else
            {
                writeFancy("Ezt nem tudod felvenni");
            }
        }
        public static void teddle(string item)
        {
            if (item == "kulcs" && kulcs.nalad == true)
            {
                kulcs.tedd_le();
                writeFancy("Letetted a kulcsot, így kikerült a leltáradból.");
            }
            else if (item == "feszítővas" && feszitovas.nalad == true)
            {
                feszitovas.tedd_le();
                writeFancy("Letetted a feszítővasat, így kikerült a leltáradból.");
            }
            else
            {
                writeFancy("Ezt nem tudod lerakni.");
            }
        }
        
        //Speciális parancsok
        public static void help()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Parancsok: ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("---észak, dél, kelet, nyugat----");
            Console.WriteLine("---nézd----");
            Console.WriteLine("---nézd-------- *tárgy neve*");
            Console.WriteLine("---menj-------- *tárgy, helység neve*");
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
            writeFancy("Leltár: ");
            if (kulcs.nalad == true)
            {
                writeFancy(" -kulcs");
            }
            if (feszitovas.nalad == true)
            {
                writeFancy(" -feszítővas");
            }
            else if (feszitovas.nalad == false && kulcs.nalad == false)
            {
                writeFancy("Nincs semmi a leltáradban.");
            }
            
               

            

           


        }
        public static void mentes(string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename + ".sav");
                sw.WriteLine(global.currentPlace );
                sw.WriteLine(szekreny.nyitva);
                sw.WriteLine(szekreny.eltolva);
                sw.WriteLine(doboz.nyitva);
                sw.WriteLine(doboz.ures);
                sw.WriteLine(doboz.lattad);
                sw.WriteLine(kulcs.hely);
                sw.WriteLine(kulcs.nalad);
                sw.WriteLine(kulcs.lattad);
                sw.WriteLine(ajto.nyitva);
                sw.WriteLine(ajto.lattad);
                sw.WriteLine(ablak.betorve);
                sw.WriteLine(feszitovas.nalad);
                sw.WriteLine(feszitovas.hely);
                sw.WriteLine(feszitovas.kivetted);
                sw.WriteLine(feszitovas.lattad);
                sw.WriteLine(kad.megnezve);

                writeFancy("A játékot sikeresen elmentetted a "+ filename +" nevű fileba, ezt a későbbieken a 'betöltés " + filename +"' paranccal éred el.");
                sw.Close();
            }
            catch
            {
                writeFancy("Valami nem sikerült a mentéssel :(, talán helytelen karaktert adtál meg, vagy több tagú filenevet.");
                
            }
            
            
        
        }
        public static void betoltes(string filename)
        {
            string[] lines = File.ReadAllLines(filename + ".sav");

            global.currentPlace = Convert.ToInt16(lines[0]);
            szekreny.nyitva = Convert.ToBoolean(lines[1]);
            szekreny.eltolva = Convert.ToBoolean(lines[2]);
            doboz.nyitva = Convert.ToBoolean(lines[3]);
            doboz.ures = Convert.ToBoolean(lines[4]);
            doboz.lattad = Convert.ToBoolean(lines[5]);
            kulcs.hely = Convert.ToInt16(lines[6]);
            kulcs.nalad = Convert.ToBoolean(lines[7]);
            kulcs.lattad = Convert.ToBoolean(lines[8]);
            ajto.nyitva = Convert.ToBoolean(lines[9]);
            ajto.lattad = Convert.ToBoolean(lines[10]);
            ablak.betorve = Convert.ToBoolean(lines[11]);
            feszitovas.nalad = Convert.ToBoolean(lines[12]);
            feszitovas.hely = Convert.ToInt16(lines[13]);
            feszitovas.kivetted = Convert.ToBoolean(lines[14]);
            feszitovas.lattad = Convert.ToBoolean(lines[15]);
            kad.megnezve = Convert.ToBoolean(lines[16]);




            writeFancy("A játék betöltése sikeres a "+ filename +" nevű mentésből.");

        }
       
        //Körbenéző parancsok
        public static void észak()
        {
           
            if (global.currentPlace == 1)
            {
                if (szekreny.eltolva == true)
                {
                    writeFancy("Északra egy ablak és egy szekrény található.");
                }
                else
                {
                    writeFancy("Északra egy szekrényt látsz");
                }

                
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
                writeFancy("Délre nincs semmi.");
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
                writeFancy("Keletre egy ágyat látsz");
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
                writeFancy("Nyugatra egy ajtót látsz");
            }
            else if (global.currentPlace == -1)
            {
                writeFancy("Nyugatra egy kád található.");
            }
        }

        //Kinézet
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

            String[] introData = new string[] { "Üdvözöllek az Escape Room című kalandjátékban.", "A játék célja magától értetődő.", "Juss ki a szobából.", "A játékban használható parancsok: ", "---észak, dél, kelet, nyugat----", "---nézd--------", "---nézd-------- *tárgy neve*", "---menj-------- *tárgy, helység neve*", "---vedd fel---- *tárgy neve*", "---tedd le----- *tárgy neve*", "---nyisd------- *tárgy neve*", "---húzd-------- *tárgy neve*", "---törd-------- *tárgy neve*", "---leltár------", "---mentés------ *file neve*", "---betöltés---- *file neve*", "---help--------", "A 'nézd' paranccsal egy leírást kapsz a körülötted lévő dolgokról, ajánlott minden új helyen használni.", "A menj parancsot használhatod tárgyakra, illetve helységekre", "A nézd parancsot tárgyakra is tudod használni (pl. nézd ágy), így hasznos információt szerezhetsz róluk." , "Különböző irányokba nézelődhetsz, ezekhez használd a 'észak,dél,kelet,nyugat' parancsokat.", "Hogy megtekintsd a leltáradban lévő dolgaid, használd a 'leltár' parancsot.", "A játékot a 'mentés *fájlnév*' paranccsal tudod elmenteni.", "A játékot betölteni korábbi mentésről a 'betöltés *fájlnév*' paranccsal éred el.", "'help' paranccsal tudod megnézni a parancsokat.", "Meg is vagyunk, kezdhetjük?", "A játék indításához nyomj 'ENTER'-t." };

            writeFancy(introData);
            Console.ReadKey();
            Console.Clear();
            string[] baseStory = new string[] { "Kinyitod a szemed, érzed, hogy minden tagod sajog.", "Nincs túl sok fény a szobában. ", "Alig látsz valamit.", "Egyetlen pici lámpa fénye pislákol a sarokban.", "Alattad nyirkos ágynemű, feletted penészes, ázott plafon.", "Fázol.", "Felülsz, úgy érzed forog veled a világ.", "Nem tudod, hogy hol vagy, fogalmad sincs, hogy kerültél ide.", "Az utolsó emléked, hogy egy pohár scotch társaságában Bukowskit olvasol a konyhában.", "Kezdesz kétségbe esni.", "Mit teszel...?" };
            writeFancy(baseStory);

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
        public static void win()  
        {
            while (true)
            {
                Console.Clear();
               
                Console.WriteLine(@"






                 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄ 
                ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌
                ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌       ▐░▌ ▀▀▀▀█░█▀▀▀▀ ▐░▌░▌     ▐░▌
                ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░▌▐░▌    ▐░▌
                ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌   ▄   ▐░▌     ▐░▌     ▐░▌ ▐░▌   ▐░▌
                ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌  ▐░▌  ▐░▌     ▐░▌     ▐░▌  ▐░▌  ▐░▌
                 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌ ▐░▌░▌ ▐░▌     ▐░▌     ▐░▌   ▐░▌ ▐░▌
                     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌▐░▌ ▐░▌▐░▌     ▐░▌     ▐░▌    ▐░▌▐░▌
                     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌░▌   ▐░▐░▌ ▄▄▄▄█░█▄▄▄▄ ▐░▌     ▐░▐░▌
                     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌
                      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀       ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀ ");


                Thread.Sleep(900);
                Console.Clear();
                Thread.Sleep(600);

               
            }
        }
        


    }

    //Item Classok
    public static class szekreny
    {
       
        public static bool nyitva = false;
        public static bool eltolva = false;
       


        public static void nyisd()
        {
            nyitva = true;
        }
        public static void huzd()
        {
            eltolva = true;
        }
       
        
    }
    public static class doboz
    {
        
        public static bool nyitva = false;
        public static bool ures = false;
        public static bool lattad = false;

        public static void nyisd()
        {
            nyitva = true;
        }
        public static void megnez()
        {
            lattad = true;
        }
        public static void kulcskivesz()
        {
            ures = true;
        }
    }
    public static class kulcs
    {
        public static int hely = 1;
        public static bool nalad = false;
        public static bool lattad = false;
       

        public static void vedd_fel()
        {
            
            doboz.kulcskivesz();
            nalad = true;
            
        }
        public static void tedd_le()
        {
            nalad = false;
            hely = global.currentPlace;
        }
        public static void megnez()
        {
            lattad = true;
        }
    }
    public static class ajto
    {
        public static bool nyitva = false;
        public static bool lattad = false;
       

        public static void nyisd()
        {
            nyitva = true;
        }
        public static void megnez()
        {
            lattad = true;
        }
       
    }
    public static class ablak
    {
        public static bool betorve = false;
        
        public static void törd()
        {
            betorve = true;
        }
       
    }
    public static class feszitovas
    {
        public static bool nalad = false;
        public static int hely = -1;
        public static bool kivetted = false;
        public static bool lattad = false;
        public static void vedd_fel()
        {
            nalad = true;
            kivetted = true;
        }
        public static void tedd_le()
        {
            hely = global.currentPlace;
            nalad = false;
        }
        public static void megnez()
        {
            lattad = true;
        }
    }
    public static class kad
    {
        
        public static bool megnezve = false;

        
        public static void megnez()
        {
            megnezve = true;
        }

    }
   

}










