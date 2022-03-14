using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier 
{
    class Croisiere : Navire
    {
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;
        private Dictionary<string, Passager> passagers = new Dictionary<string, Passager>();

        public int NbPassagersMaxi { get => nbPassagersMaxi; }
        public char TypeNavireCroisiere { get => typeNavireCroisiere; }
        public Dictionary<string,Passager> Passagers { get => passagers; set => passagers = value; }

        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, char typeNavireCroisiere,int nbPassagersMaxi)
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }

        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, char typeNavireCroisiere, int nbPassagersMaxi, List<Passager> Passagers)
            : this(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT, typeNavireCroisiere, nbPassagersMaxi)
        {
           foreach(Passager p in Passagers)
            {
                this.Passagers.Add(p.NumPasseport, p);
            }
        }

        public void Embarquer (List<Passager> nouveauPassagers)
        {
            if (Passagers.Count + nouveauPassagers.Count > nbPassagersMaxi)
            {
                throw new Exception("On ne peut pas ajouter de passager au dessus du nombre maximum du navire de croisiere");
            }

            foreach (Passager p in nouveauPassagers)
            {
                this.Passagers.Add(p.NumPasseport, p);
            }
        }

        public List<Passager> Debarquer (List<Passager> Passagers)
        {
            List<Passager> passagerAbsent = new List<Passager>();

            foreach(Passager p in Passagers)
            {
                if(this.Passagers.ContainsValue(p))
                {
                    this.Passagers.Remove(p.NumPasseport);
                } else
                {
                    passagerAbsent.Add(p);
                }
            }

            return passagerAbsent;
        }
    }
}
