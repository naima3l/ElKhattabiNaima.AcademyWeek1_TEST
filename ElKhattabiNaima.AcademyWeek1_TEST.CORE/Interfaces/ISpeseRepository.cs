using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.CORE.Interfaces
{
    public interface ISpeseRepository : IRepository<Spese>
    {
        void Update(Spese spesa);
        List<Spese> GetSpeseNullApproved();
        List<Spese> GetSpeseByDipendente(int id);
    }
}
