using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.CORE
{
    public class Evento
    {
        public delegate void ScriviSuFile(Evento evento); //delegato

        public event ScriviSuFile MandaLaNotifica; //evento

        public void IfAuthenticationOk()
        {
            if(MandaLaNotifica != null)
            {
                MandaLaNotifica(this);
            }
        }
    }
}
