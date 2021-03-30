using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{

    // lagras, hämtas, hittas, flyttas
    public class Höglager : IEnumerable
    {
        public LagerPlatser[,] lagret = new LagerPlatser[3, 100];  //varuhuset

        public Höglager()
        {
            InitieraArray();  
        }

        public List<I3DStorageObject> VisaWHA(int hylla, int plats)
        {
            return lagret[plats, hylla].VisaWH();
        }
        public void InitieraArray()
        {
            for (int j = 0; j <= 2; j++)
            {
                for (int k = 0; k <= 99; k++)
                {
                    lagret[j, k] = new LagerPlatser();   //lägger in lagerplatser på varje plats i lagerhuset
                }
            }

        }

        public bool HittaID(int id, out int plats, out int hylla)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                   if (lagret[j, k].SökEfterLåda(id) == true) //om man hittar lådan i lagerplatser reurnerar den sant.
                    { 
                        plats = j;
                        hylla = k;
                        return true;
                    }

                }
            }
            plats = -1;  // om den inte hittar ett id så returnerar den false ocg sätter plats och hylla till värden som inte finns
            hylla = -1;
            return false;
        }

        public void TömLagret()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                    lagret[j, k].TömLagret(); //för varje plats i lagret kallar på en metod i lagerplatser som tömmer alla lagerplatserna
                }
            } 
        }
        public bool LäggTill(I3DStorageObject låda)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                    if (lagret[j, k].SökEfterLåda(låda.ID) == true)
                    {
                        throw new FormatException("Det finns redan en låda med detta ID");

                    } 
                }
            }
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 100; k++)
                {

                    if (låda.Ömtåligt == true) //om lådan är ömtålig, fortsätt
                    {
                        if (lagret[j, k].ÄrLådaÖmtålig() == true) //finns det redan en låda som är ömtålig i den här lagerplatsen ska den frtsätta leta plats.
                        {
                            continue;
                        }
                        else if (lagret[j, k].FörMycketVikt() == 0) //är vikten i lagerplatsen 0 så kan man lägga till en ömtålig
                        {
                            lagret[j, k].LäggTillLåda(låda);
                            return true;
                        }
                        else
                            continue;
                    }



                    else if (låda.Ömtåligt == false)
                    {
                        if (lagret[j, k].ÄrLådaÖmtålig() == true)
                        {
                            continue;
                        }
                        else if (lagret[j, k].FinnsDetUtrymme(låda.Vikt, låda.Volym) == true) // överstiger vikten och volymen max??
                        {
                            lagret[j, k].LäggTillLåda(låda); //annars lägg till en ny låda
                            return true;
                        }
                        else if (lagret[j, k].FinnsDetUtrymme(låda.Vikt, låda.Volym) == false) // överstiger vikten och volymen max??
                        {
                            continue; //om, fortsätt leta plats
                        }


                    }


                }
            }
             return false;
        }

        public bool LäggTillPåPlats(I3DStorageObject låda, int plats, int hylla)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                    if (lagret[j, k].SökEfterLåda(låda.ID) == true)
                    {
                        throw new FormatException("Det finns redan en låda med detta ID");

                    }
                }
            }
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                    
                     if (låda.Ömtåligt == true) // ömtålig ja!
                        {
                            if (lagret[plats, hylla].ÄrLådaÖmtålig() == true) //om lådan i är ömtålig kan man inte ställa en låda till.
                            {
                                throw new ArgumentException("Här får du inte ställa lådan");
                            }
                            else if (lagret[plats, hylla].FörMycketVikt() == 0) //är lagret tomt kan man ställa en ömtålig
                            {
                                lagret[plats, hylla].LäggTillLåda(låda);
                                return true;
                            }


                        }


                        else if (låda.Ömtåligt == false) //ömtålig nej!
                        {
                            if (lagret[plats, hylla].ÄrLådaÖmtålig() == true) //om lådan i är ömtålig kan man inte ställa en låda till.
                            {
                                throw new ArgumentException("Här får du inte ställa lådan");
                            }
                            else if (lagret[plats, hylla].FinnsDetUtrymme(låda.Vikt, låda.Volym) == true) //kollar volym och vikt
                            {
                                lagret[plats, hylla].LäggTillLåda(låda);
                                return true;
                            }
                            else if (lagret[plats, hylla].FinnsDetUtrymme(låda.Vikt, låda.Volym) == false)
                            {
                                throw new ArgumentException("Lådan får inte plats");
                            }


                        }
                    }
                
            }
            return false;
        }


        public bool FlyttaLåda(int id, int hylla, int plats)
        {
            
            for (int j = 0; j <= 2; j++)
            {
                for (int k = 0; k <= 99; k++)
                {
                    if (lagret[j, k].ÄrLådaÖmtålig() == true) 
                    {
                        throw new ArgumentException("Här får du inte ställa lådan");
                    }

                    else if (lagret[j, k].SökEfterLåda(id) == true)
                    {
                        var item = lagret[j,k].HämtaUtLåda(id);
                        LäggTillPåPlats(item, plats, hylla); //kollar alla vikt och volym regler.


                        return true;
                    }
                }
            }
            return false;
        }

        public I3DStorageObject HämtaUt(int id, out int plats, out int hylla)
        {
            
            for (int j = 0; j <= 2; j++)
            {
                for (int k = 0; k <= 99; k++)
                {
                    
                    if (lagret[j, k].SökEfterLåda(id) == true) //söker efter ID, sätter värde på hylla och plats
                    {
                        hylla = k;
                        plats = j;

                        return lagret[j, k].HämtaUtLåda(id);  // tar bort låda från varulagret

                    }
                    else if (lagret[j, k].SökEfterLåda(id) == false)
                    {
                        continue;
                    }
                    else 
                        throw new KeyNotFoundException("Lådan kunde tyvärr inte hittas");




                }

            }
            hylla = -1;
            plats = -1;
            return null;
        }

        //skapar Former med in parametrar.

        public Kub SkaparKub(double Sida, double Vikt, int ID, string Beskrivning, double FörsäkringsVärde, bool Ömtåligt)
        {
            Kub kub = new Kub(Sida, Vikt, Sida, ID, Beskrivning, FörsäkringsVärde, Ömtåligt);
            kub.ToString();
            return kub;
        }

        public Sfär SkaparSfär(double radie, int id, string beskrivning, double vikt, bool ömtålig, double försäkringsVärde)
        {
            Sfär sfär = new Sfär(radie, id, beskrivning, vikt, ömtålig, försäkringsVärde);
            sfär.ToString();
            return sfär;
        }
        public Blob SkaparBlob(double sida, int id, string beskrivning, double vikt, bool ömtålig, double försäkringsVärde)
        {
            Blob blob = new Blob(sida, id, beskrivning, vikt, ömtålig, försäkringsVärde);
            blob.ToString();
            return blob;
        }
        public RätBlock SkaparRätblock(double Höjd, double Längd, double Djup, int ID, string Beskrivning, double Vikt, bool Ömtålig, double FörsäkringsVärde)
        {
            RätBlock rätblock = new RätBlock(Höjd, Längd, Djup, ID, Beskrivning, Vikt, Ömtålig, FörsäkringsVärde);
            rätblock.ToString();
            return rätblock;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

