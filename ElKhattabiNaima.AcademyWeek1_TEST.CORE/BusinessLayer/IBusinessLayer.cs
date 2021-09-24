using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.CORE.BusinessLayer
{
    public interface IBusinessLayer
    {
        void GestisciRimborsi();
        int Authentication(string name);
        void File(int id);
    }
}
