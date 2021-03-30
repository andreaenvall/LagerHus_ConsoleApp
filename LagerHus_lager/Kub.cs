using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Kub : I3DStorageObject
    {
        

        internal double Sida { get; set; }
        public int ID { get; }
        public string Beskrivning { get; }
        public double Vikt{ get; }
        public double Volym { get => RäknaVolym(Sida); }
        public double Area { get => RäknaArea(Sida); }
    
        public bool Ömtåligt { get; }
        public double MaxDimension { get => Sida; }
        public double FörsäkringsVärde { get; set; }

        //double sida, double vikt, double volym, int id, string beskrivning, bool ömtålig, string maxDimension, double försäkringsVärde
        public Kub(double Sida, double Vikt, double Volym, int ID, string Beskrivning,double FörsäkringsVärde, bool Ömtåligt)
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
            return Math.Round((sida/100) * (sida/100) * (sida/100), 2);
        } //volym i kubikmeter

        public double RäknaArea(double sida)
        {
            return 6 * (Sida * 2);
        }
        //area i kvadratmeter

        public override string ToString() // gör om till sträng
        {
            return $"ID:{ this.ID}\nSidans längd: {this.Sida}cm \nBeskrivning: { this.Beskrivning} \nVikt: { this.Vikt}kg  \nMaxDimension:{ this.MaxDimension} \nFörsäkringsvärde: { this.FörsäkringsVärde}kr"; //{ this.ömtåligt}
        }


        //public Form AddKub()
        //{

        //}
    }

    
}
