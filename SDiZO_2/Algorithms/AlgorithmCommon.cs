using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDiZO_2.Algorithms
{
    // Interfejs który upraszcza proces wypisywania danych do pliku standaryzując potrzebne metody.
    interface AlgorithmCommon
    {
        
        void Work();
        string Type();
        string Filename();
        bool ListMode { get; set; }

    }
}
