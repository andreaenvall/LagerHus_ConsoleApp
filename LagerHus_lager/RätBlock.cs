using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class RätBlock : I3DStorageObject
    {
      

        public int ID { get; }
        public string Beskrivning { get; }
        public double Vikt { get; }
        public double Volym { get => RäknaVolym(); }
        public double Area { get; }
        public bool Ömtåligt { get; }
        public double MaxDimension { get => getMaxDimension(); }
        public double FörsäkringsVärde { get; set; }
        public double Höjd { get; set; }
        public double Längd { get; set; }
        public double Djup { get; set; }

        public RätBlock(double Höjd, double Längd, double Djup, int ID, string Beskrivning, double Vikt, bool Ömtåligt, double FörsäkringsVärde)
        {
            this.Djup = Djup;
            this.Längd = Längd;
            this.Höjd = Höjd;
            this.ID = ID;
            this.Beskrivning = Beskrivning;
            this.Vikt = Vikt;
            this.Ömtåligt = Ömtåligt;
            
            this.FörsäkringsVärde = FörsäkringsVärde;
        }
        public double RäknaVolym()
        {
            return Math.Round((Längd/100) * (Höjd/100) * (Djup/100),2);
            //volym i kubikmeter
        }
        public double getMaxDimension()
        {
            double[] enArray = { Längd, Höjd, Djup };
            double maxDimension = enArray.Max();
            return maxDimension;
        }

        public override string ToString() //gör om till sträng
        {
            return $"{ this.ID} { this.Beskrivning} { this.Vikt} { this.Ömtåligt} { this.MaxDimension} { this.FörsäkringsVärde}";
        }

    }
}
