using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NavireHeritage.classesMetier
{
    class Cargo : Navire, INavCommercable
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT,string typeFret) 
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeFret = typeFret;
        }

        public void Charger(int nbCharger)
        {
            if (nbCharger > TonnageActuel)
            {
                throw new Exception("On ne peut pas charger au dessus de la quantité actuel d'un navire");
            }

            TonnageActuel -= nbCharger;
        }

        public void Decharger(int nbDecharger)
        {
            if (nbDecharger < 0)
            {
                throw new Exception("On ne peut pas décharger une valeur négative dans le navire");
            }
            else if (nbDecharger + TonnageActuel > TonnageDWT)
            {
                throw new Exception("On ne peut pas charger au dessus de la quantité maximal d'un navire");
            }

            TonnageActuel += nbDecharger;
        }

        public string getTypeFret ()
        {
            return typeFret;
        }
    }
}
