using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
   
    public class LagerPlatser : IEnumerable
    {
        private List<I3DStorageObject> lagerplats = new List<I3DStorageObject>();
        internal double Höjd { get => 200; }
        internal double Bredd { get => 300; }
        internal double Djup { get => 200; }
        internal double MaxVikt { get => 1000; }
        internal double MaxVolym
        {
            get => Math.Round((Höjd /100) * (Bredd /100)* (Djup/100),2);
        }
        public LagerPlatser()
        {

        }

       
        public List<I3DStorageObject> VisaWH()
        {
            
            return lagerplats; //returnerar listan lagerplats
        }



        public void TömLagret()
        {
            lagerplats.Clear(); //tömmer lagerplats
        }

       
        public I3DStorageObject HämtaUtLåda(int id)
        {
            foreach (var item in lagerplats)
            {
                if (item.ID == id) //kollar om in parametern id matchar något av Items id
                {

                    I3DStorageObject tempPlats = item; // gör nytt object och lägger i en temporär variabel.
                    lagerplats.Remove(item); //tar bort från platsen den fanns på
                    return tempPlats; //skickar ut platsen för att sätta in den på ny plats
                }
                

            }
            return null;
        }

        public bool SökEfterLåda(int id)
        {
            foreach(var item in lagerplats)
            {
                if (item.ID == id)
                {
                    return true; //kollar om idt matchar med något i listan isåfall returnera sant.
                }
               
               
            }

           return false;
        }

        public double FörMycketVikt()
        {
            double summaVikt = 0;
            foreach (var låda in lagerplats)
            {
                summaVikt += låda.Vikt; //räknar ut totala vikten på en lagerplats

            }
            return summaVikt; 
        }

        public bool ÄrLådaÖmtålig()
        {
            foreach (var låda in lagerplats)
            {
                if(låda.Ömtåligt == true)
                {
                    return true; //kollar om lådan i lagerplats är ömtålig
                }

            }
            return false;
        }

        public double FörMycketVolym()
        {
            double summaVolym = 0;
            foreach (var låda in lagerplats)
            {
                summaVolym+= låda.Volym;

            }
            return summaVolym; //räknar ut summan av volymen i en lagerplats
        }
        public void LäggTillLåda(I3DStorageObject låda)
        {

            lagerplats.Add(låda); //lägger till ny låda på en lagerplats ifall IDt inte redan finns

        }


        public bool FinnsDetUtrymme(double vikt, double volym)
        {
            double volymÖver = MaxVolym - FörMycketVolym(); //räknar ut den volym som finns tillgänglig på lagerplatsen
            double viktÖver = MaxVikt - FörMycketVikt(); // räknar ut den vikt som finns tillgänglig på lagerplatsen

            if (volymÖver < volym || viktÖver < vikt)
            {
                return false; //finns det inte vikt eller volym plats returnera falskt
            }
            else
                return true;
                    
        }

   
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        

        
    }
}
