using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    interface IStationnable
    {
        void EnregistrerArriveePrevue(object obj);

        void EnregistrerArrive(string str);

        void EnregistrerDepart(string str);

        bool EstAttendu(string id);

        bool EstPresent(string id);

        bool EstParti(string id);

        object GetUnAttendu(string id);

        object GetUnArrive(string id);

        object GetUnParti(string id);
    }
}
