﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    interface INavCommercable
    {
        void Decharger(int qte);

        void Charger(int qte);
    }
}
