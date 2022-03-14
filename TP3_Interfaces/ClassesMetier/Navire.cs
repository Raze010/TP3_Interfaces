using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    abstract class Navire
    {
        private string imo, nom;
        private string latitude, longitude;
        private int tonnageActuel, tonnageGT, tonnageDWT;

        public string Imo { get => imo; }
        public string Nom { get => nom; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int TonnageActuel { get => TonnageActuel; set => tonnageActuel = value; }
        public int TonnageGT { get => tonnageGT; }
        public int TonnageDWT { get => tonnageDWT; }

        public Navire(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageActuel = tonnageActuel;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
        }
    }
}
