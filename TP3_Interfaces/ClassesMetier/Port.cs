using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Port : IStationnable
    {
        private string nom, latitude, longitude;
        private int nbPortique, nbQuaisPassager, nbQuaisTanker, nbQuaisSuperTanker;

        public string Nom { get => nom; }
        public string Latitude { get => latitude; }
        public string Longitude { get => longitude; }
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }


        private Dictionary<String, Navire> navireAttendus = new Dictionary<string, Navire>();
        private Dictionary<String, Navire> navireArrives = new Dictionary<string, Navire>();
        private Dictionary<String, Navire> navirePartis = new Dictionary<string, Navire>();
        private Dictionary<String, Navire> navireEnAttente = new Dictionary<string, Navire>();

        public Dictionary<string,Navire> NavireAttendus { get => navireAttendus; }
        public Dictionary<string, Navire> NavireArrives { get => navireArrives; }
        public Dictionary<string, Navire> NavirePartis { get => navirePartis; }
        public Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente; }


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

        public void EnregistrerArriveePrevue(Navire navire)
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

        public void Chargement(string imo, int nbCharger)
        {
            if(navireArrives.ContainsKey(imo))
            {
                if(navireArrives[imo].TonnageActuel + nbCharger > navireArrives[imo].TonnageDWT)
                {
                    navireArrives[imo].TonnageActuel += nbCharger;
                }
                else
                {
                    throw new Exception("Ce navire n'a pas assez de capacité de stockage");
                }
            } 
            else
            {
                throw new Exception("Ce navire n'est pas dans navireArrivee");
            }
        }
        public void DeChargement(string imo, int nbDecharger)
        {
            if (navireArrives.ContainsKey(imo))
            {
                if (navireArrives[imo].TonnageActuel - nbDecharger >= 0)
                {
                    navireArrives[imo].TonnageActuel -= nbDecharger;
                }
                else
                {
                    throw new Exception("La capacité d'un navire ne peut pas atteindre 0");
                }
            }
            else
            {
                throw new Exception("Ce navire n'est pas dans navireArrivee");
            }
        }

        public Navire GetUnAttendu (string id )
        {
            if(navireArrives.ContainsKey(id))
            {
                return navireArrives[id];
            }
            else
            {
                throw new Exception("Il n'y a pas ce navire dans navireArrives");
            }
        }

        public Navire GetUnArrive(string id)
        {
            if (navireArrives.ContainsKey(id))
            {
                return navireArrives[id];
            }
            else
            {
                throw new Exception("Il n'y a pas ce navire dans navireArrives");
            }
        }

        public Navire GetUnParti(string id)
        {
            if (navirePartis.ContainsKey(id))
            {
                return navireArrives[id];
            }
            else
            {
                throw new Exception("Il n'y a pas ce navire dans navireArrives");
            }
        }

        public int GetNbTankerArrives()
        {
            int nb = 0;

            foreach(Navire n in navireArrives.Values)
            {
                if(n.TonnageGT <= 130000)
                {
                    nb++;
                }
            }

            return nb;
        }

        public int GetNbSuperTankerArrives()
        {
            int nb = 0;

            foreach (Navire n in navireArrives.Values)
            {
                if (n.TonnageGT > 130000)
                {
                    nb++;
                }
            }

            return nb;
        }

        public int GetNbCargoArrives()
        {
            int nb = 0;

            foreach (Navire n in navireArrives.Values)
            {
                if (n is Cargo)
                {
                    nb++;
                }
            }

            return nb;
        }

        public void EnregistrerArriveePrevue(object obj)
        {
            throw new NotImplementedException();
        }

        public void EnregistrerDepart(string str)
        {
            throw new NotImplementedException();
        }

        public bool EstParti(string id)
        {
            throw new NotImplementedException();
        }

        object IStationnable.GetUnAttendu(string id)
        {
            throw new NotImplementedException();
        }

        object IStationnable.GetUnArrive(string id)
        {
            throw new NotImplementedException();
        }

        object IStationnable.GetUnParti(string id)
        {
            throw new NotImplementedException();
        }
    }
}
