using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    
    public class Blob : I3DStorageObject
    {

        public int ID { get; }
        public string Beskrivning { get; }
        public double Vikt { get; }
        public double Volym { get => RäknaVolym(Sida); }
        public double Area { get; }
        public bool Ömtåligt { get; }
        public double MaxDimension { get => Sida; }
        public double FörsäkringsVärde { get; set; }
        internal double Sida { get; set; }


        public Blob(double Sida, int ID, string Beskrivning, double Vikt, bool Ömtåligt, double FörsäkringsVärde)
        {
            this.Sida = Sida;
            this.ID = ID;
            this.Beskrivning = Beskrivning;
            this.Vikt = Vikt;
            this.Ömtåligt = Ömtåligt;
            this.FörsäkringsVärde = FörsäkringsVärde;
        }

        public double RäknaVolym(double sida)
        {
            return Math.Round((sida / 100) * (sida / 100) * (sida / 100), 2); //räknar ut volym i kubikmeter
        }

        public override string ToString() //gör om till sträng
        {
            return $" { this.ID} { this.Beskrivning} { this.Vikt} { this.Ömtåligt} { this.MaxDimension} { this.FörsäkringsVärde}";
        }

        
    }
}
