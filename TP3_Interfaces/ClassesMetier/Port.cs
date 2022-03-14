using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Port
    {
        private string nom, latitude, longitude;
        private int nbPortique, nbQuaisPassager, nbQuaisTanker, nbQuaisSuperTanker;

        private Dictionary<String, Navire> navireAttendus = new Dictionary<string, Navire>();
        private Dictionary<String, Navire> navireArrives = new Dictionary<string, Navire>();
        private Dictionary<String, Navire> navirePartis = new Dictionary<string, Navire>();
        private Dictionary<String, Navire> navireEnAttente = new Dictionary<string, Navire>();

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nbQuaisSuperTanker)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisPassager = nbQuaisPassager;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nbQuaisSuperTanker = nbQuaisSuperTanker;
        }

        public void enregistrerArriveePrevue (Navire navire)
        {
            navireAttendus.Add(navire.Imo, navire);
        }

        public void EnregistrerArrive (Navire navire)
        {
            if(navireAttendus.ContainsValue(navire))
            {
                navireArrives.Add(navire.Imo, navire);
                navireAttendus.Remove(navire.Imo);
                
            } else
            {
                throw new Exception("Le navire n'etait pas attendus");
            }
        }

        public void EnregistrerArrive(string navire_imo)
        {
            if (navireAttendus.ContainsKey(navire_imo))
            {
                navireArrives.Add(navire_imo, navireAttendus[navire_imo]);
                navireAttendus.Remove(navire_imo);
            }
            else
            {
                throw new Exception("Le navire n'etait pas attendus");
            }
        }

        public void EnregistrerDepart(Navire navire )
        {
            if(navireArrives.ContainsValue(navire))
            {
                navireArrives.Remove(navire.Imo);
            } else
            {
                throw new Exception("Ce navire n'est pas present sur le port");
            }
        }

        public void AjoutNavireEnAttente (Navire navire)
        {
            navireEnAttente.Add(navire.Imo, navire);
        }

        public bool EstAttendu(string imo)
        {
            return navireAttendus.ContainsKey(imo);
        }

        public bool EstPresent(string imo)
        {
            return navireArrives.ContainsKey(imo);
        }

        public bool EstEnAttente (string imo)
        {
            return navireAttendus.ContainsKey(imo);
        }

        public void Chargement(string imo, int nbDecharger)
        {
            if(navireArrives.ContainsKey(imo))
            {
                if(navireArrives[imo] is Cargo)
                {
                    //navireArrives[imo].d
                }
            }
        }
    }
}
