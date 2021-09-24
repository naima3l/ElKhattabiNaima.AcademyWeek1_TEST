using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.CORE.Interfaces
{
    public interface IDipendenteRepository : IRepository<Dipendente>
    {
        Dipendente GetByName(string name);
    }
}
