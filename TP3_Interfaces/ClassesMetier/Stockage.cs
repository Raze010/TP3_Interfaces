using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Stockage : Navire
    {
        private int numero;
        private int capaciteMaxi,capaciteDispo;

        public int Numero { get => numero; }
        public int CapaciteMaxi { get => capaciteDispo; set => capaciteDispo = value; }
        public int CapaciteDispo { get => capaciteMaxi; set => capaciteMaxi = value; }


        public Stockage(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT,int numero,int capaciteMaxi) 
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.numero = numero;
            this.capaciteDispo = capaciteMaxi;
            this.capaciteMaxi = capaciteMaxi;
        }
    }
}
