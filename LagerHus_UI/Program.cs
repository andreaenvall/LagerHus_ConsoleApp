using System;
using System.Collections.Generic;
using Warehouse;

namespace ConsoleWearHouse
{

    class Program
    {
        static Höglager WH = new Höglager();


        static void Main(string[] args)
        {
            ExData();
            
            bool menu = true;
            int choice = 0;
            do
            {
                choice = 0;

                Console.WriteLine("                 WAREHOUSE    ");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("1. Lagra ny låda    | 2. Flytta låda");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("3. Hämta ut låda    | 4. Hitta låda ");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("5. Visa alla lådor  | 6. CLEAR ");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("5. EXIT             | ");
                Console.WriteLine("__________________________________________");

                Console.Write("\nPlease enter your option:");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            LagraLåda();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }



                        break;
                    case 2:
                        Console.Clear();
                        try
                        {
                            FlyttaLåda();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }


                        break;
                    case 3:
                        Console.Clear();
                        try
                        {
                            HämtaUtLåda();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }


                        break;
                    case 4:
                        Console.Clear();
                        try
                        {
                            HittaLåda();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;

                    case 5:
                        Console.Clear();

                        VisaLagret();
                        //WH.TömLagret();

                        break;
                    case 6:
                        Console.Clear();

                        WH.TömLagret();

                        break;
                    case 7:
                        Console.Clear();

                        Console.WriteLine("Exiting program..");
                        menu = false;
                        break;
                    default:
                        break;
                }
            } while (menu == true);
        }

        static void LagraLåda()
        {
            Console.WriteLine("[1]. Lagra automatiskt");
            Console.WriteLine("[2]. Lagra på bestämd plats");
            int val = int.Parse(Console.ReadLine());
            if (val > 2 || val < 1 || val.Equals(""))
                throw new FormatException("Du måste välja ett nummer av 1 och 2");

            Console.WriteLine("Lagra ny låda:");
            Console.WriteLine("Lådans ID:");
            int id = int.Parse(Console.ReadLine());


            Console.WriteLine("Beskrivning");
            string beskrivning = Console.ReadLine();

            Console.WriteLine("Lådans vikt i kg:");
            double vikt = double.Parse(Console.ReadLine());

            Console.WriteLine("Är lådan Ömtålig?  true / false");
            string svar = Console.ReadLine();


            bool ömtålig = false;
            if (svar.Equals("true"))
            {
                ömtålig = true;
            }

            Console.WriteLine("Lådans försäkringsvärde:");
            double förs = double.Parse(Console.ReadLine());


            Console.WriteLine("Vilken typ av låda skall du lagra?");
            Console.WriteLine("{ 1 }. Kub");
            Console.WriteLine("{ 2 }. Sfär");
            Console.WriteLine("{ 3 }. Blob");
            Console.WriteLine("{ 4 }. Rätblock");
            string form = Console.ReadLine();

            if (form.Equals("1"))
            {
                Console.WriteLine("hur lång är lådans sida?");
                double sida = double.Parse(Console.ReadLine());

                if (val == 2)
                {
                    Console.WriteLine("Ange plats (1-3): ");
                    int plats = int.Parse(Console.ReadLine());
                    if (plats.Equals(""))
                    {
                        throw new FormatException("Du måste fylla i informationen");
                    }
                    Console.WriteLine("Ange hylla (1-100): ");
                    int hylla = int.Parse(Console.ReadLine());
                    if (hylla.Equals(""))
                    {
                        throw new FormatException("Du måste fylla i informationen");
                    }
                    WH.LäggTillPåPlats(WH.SkaparKub(sida, vikt, id, beskrivning, förs, ömtålig), plats - 1, hylla - 1);
                }
                else if (val == 1)
                {
                    WH.LäggTill(WH.SkaparKub(sida, vikt, id, beskrivning, förs, ömtålig));
                }


            }

            else if (form.Equals("2"))
            {
                Console.WriteLine("hur lång är lådans sida?");
                double sida = double.Parse(Console.ReadLine());

                if (val == 2)
                {
                    Console.WriteLine("Ange plats (1-3): ");
                    int plats = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ange hylla (1-100): ");
                    int hylla = int.Parse(Console.ReadLine());

                    WH.LäggTillPåPlats(WH.SkaparSfär(sida, id, beskrivning, vikt, ömtålig, förs), plats - 1, hylla - 1);
                }
                else if (val == 1)
                {
                    WH.LäggTill(WH.SkaparSfär(sida, id, beskrivning, vikt, ömtålig, förs));
                }


            }
            else if (form.Equals("3"))
            {
                Console.WriteLine("hur lång är lådans sida?");
                double sida = double.Parse(Console.ReadLine());
                //Kub kub = new Kub(sida, vikt, sida, id, beskrivning, dim, förs, ömtålig);

                if (val == 2)
                {
                    Console.WriteLine("Ange plats (1-3): ");
                    int plats = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ange hylla (1-100): ");
                    int hylla = int.Parse(Console.ReadLine());

                    WH.LäggTillPåPlats(WH.SkaparBlob(sida, id, beskrivning, vikt, ömtålig, förs), plats - 1, hylla - 1);
                }
                else if (val == 1)
                {
                    WH.LäggTill(WH.SkaparBlob(sida, id, beskrivning, vikt, ömtålig,  förs));
                }


            }

            else if (form.Equals("4"))
            {
                Console.WriteLine("hur bred är lådan?");
                double bredd = double.Parse(Console.ReadLine());

                Console.WriteLine("Hur lång är lådan?");
                double längd = double.Parse(Console.ReadLine());

                Console.WriteLine("Hur hög är lådan?");
                double höjd = double.Parse(Console.ReadLine());

                if (val == 2)
                {
                    Console.WriteLine("Ange plats (1-3): ");
                    int plats = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ange hylla (1-100): ");
                    int hylla = int.Parse(Console.ReadLine());
                    WH.LäggTillPåPlats(WH.SkaparRätblock(höjd, längd, bredd, id, beskrivning, vikt, ömtålig, förs), plats - 1, hylla - 1);
                }
                else if (val == 1)
                {
                    WH.LäggTill(WH.SkaparRätblock(höjd, längd, bredd, id, beskrivning, vikt, ömtålig, förs));
                }


            }
            else
                throw new FormatException("Du måste välja ett nummer av 1 och 4");
            Console.Clear();

        }

        static void HittaLåda()
        {
            int hylla;
            int plats;
            Console.WriteLine("skriv in id");
            int id = int.Parse(Console.ReadLine());
            bool svar = WH.HittaID(id, out plats, out hylla);
            if (svar == true)
            {
                Console.WriteLine("Lådan finns på plats {0} hylla {1}", plats + 1, hylla + 1);
            }
            else
                throw new KeyNotFoundException("Lådan kunde tyvärr inte hittas");

        }

        static void FlyttaLåda()
        {
            Console.WriteLine("ID:");

            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Till vilken plats vill du flytta lådan?");
            int plats = int.Parse(Console.ReadLine());
            Console.WriteLine("Vilken hylla på plats {0} vill du flytta lådan?", plats);
            int hylla = int.Parse(Console.ReadLine());

            WH.FlyttaLåda(id, hylla - 1, plats - 1);
            Console.Clear();
            Console.WriteLine("Hyllan är nu flyttad till plats {0} hylla {1} ", plats, hylla);



        }

        static void HämtaUtLåda()
        {
            Console.WriteLine("Vilken låda vill du hämta ut?");
            Console.WriteLine("ID:");
            int id = int.Parse(Console.ReadLine());
            int plats;
            int hylla;
            WH.HämtaUt(id, out plats, out hylla);
            Console.WriteLine("Lådan på plats {0} hylla {1}, är nu uthämtad.", plats + 1, hylla + 1);

        }

        static void VisaLagret()
        {


            for (int j = 0; j <= 2; j++)
            {
                for (int k = 0; k <= 99; k++)
                {
                   
                    if(WH.VisaWHA(k, j).Count != 0)  //om listan inte räknas till 0
                    {
                       Console.WriteLine("Plats {0}, Hylla {1}", j + 1, k + 1);

                        foreach (var låda in WH.VisaWHA(k, j)) //för varje låda skriver den ut innehållet
                        {
                            Console.WriteLine("ID: {0} Beskrivning: {1}", låda.ID, låda.Beskrivning);
                        }
                    }

                   
                }
                
            }


        }

        static void ExData()
        {
            {
                WH.LäggTill(WH.SkaparBlob(50, 1, "En låda", 20, false, 12000)); // skapar nya lådor med bestämda värden för att ha data
                WH.LäggTill(WH.SkaparBlob(50, 2, "En låda", 600, false, 12000));
                WH.LäggTill(WH.SkaparKub(20, 50, 3, "en kub", 12000, true));
                WH.LäggTill(WH.SkaparKub(20, 50,  4, "en kub",  22000, false));
                WH.LäggTill(WH.SkaparKub(10, 50, 5, "en kub", 2000, true));
                WH.LäggTill(WH.SkaparSfär(10, 6,"en sfär", 100, false, 2000 ));
                WH.LäggTill(WH.SkaparSfär(10, 7, "en sfär", 88, true, 2000));
                WH.LäggTill(WH.SkaparSfär(10, 8, "en sfär", 1000, false, 2000));
                WH.LäggTill(WH.SkaparRätblock(10, 12, 13, 9, "ett rätblock", 500, false, 2000));
                WH.LäggTill(WH.SkaparRätblock(10, 12, 13, 10, "ett rätblock", 500, false, 2000));
            }
        }
    }
}
   
    

