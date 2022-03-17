using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    interface ICroisierable
    {
        void Embarquer(List<object> objects);

        void Debarquer(List<object> objects);
    }
}
