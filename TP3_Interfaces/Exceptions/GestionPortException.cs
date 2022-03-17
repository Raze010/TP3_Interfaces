using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.Exceptions
{
    class GestionPortException : Exception
    {
        public override string Message => "Erreur le : "+DateTime.Today +"\n" +base.Message;
    }
}
