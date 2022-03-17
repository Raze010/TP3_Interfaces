using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavireHeritage.classesMetier;
using NavireHeritage.Exceptions;

namespace NavireHeritage.Exceptions
{
    public abstract class Test
    {
        public static void ChargementInitial (Port port)
        {
            try
            {
                // cargos
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859","CMA CGM A. LINCOLN","43.43279 N","134.76258 W",140872,148992,123000,"marchandises diverses"));

            } 
            catch(GestionPortException ex)
            {
                Console.WriteLine("exception : " + ex.Message);
            }
        }
    }
}
