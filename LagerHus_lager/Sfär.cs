using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Sfär : I3DStorageObject
    {


        public int ID { get; }
        public string Beskrivning { get; }
        public double Vikt { get; }
        public double Volym { get => RäknaVolym(Radie); }
        public double Area { get => RäknaArea(Radie); }
        public bool Ömtåligt { get; }
        public double MaxDimension { get => Radie*2; }
        public double FörsäkringsVärde { get; set; }
        internal double Radie { get; set; }


        public Sfär(double Radie, int ID, string Beskrivning, double Vikt, bool Ömtåligt, double FörsäkringsVärde)
        {
            this.Radie = Radie;
            this.ID = ID;
            this.Beskrivning = Beskrivning;
            this.Vikt = Vikt;
            this.Ömtåligt = Ömtåligt;
            this.FörsäkringsVärde = FörsäkringsVärde;
        }

        public double RäknaVolym(double sida)
        {
            return Math.Round(((sida*2)/100) * ((sida * 2)/100) * ((sida * 2)/100),2); //räknar ut volym i kubikmeter
        }
        public double RäknaArea(double sida)
        {
            return 6 * ((sida*2) * 2); //räknar area i kvadratmeter
        }

        public override string ToString()
        {
            return $"{this.ID} { this.Beskrivning} { this.Vikt} { this.Ömtåligt} { this.MaxDimension} { this.FörsäkringsVärde}";
        }
    }
}
