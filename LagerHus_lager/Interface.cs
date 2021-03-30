using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public interface I3DStorageObject
    {
        int ID { get; }
        string Beskrivning { get; }
        double Vikt { get;  }
        double Volym { get; }
        double Area { get; }
        bool Ömtåligt { get;  }
        double MaxDimension { get; }
        double FörsäkringsVärde { get; set; }

        
    }
}
