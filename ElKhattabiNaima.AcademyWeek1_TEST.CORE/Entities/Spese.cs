using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.CORE.Entities
{
    public class Spese
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Spesa { get; set; }
        public EnumCategoria Categoria { get; set; }
        public string Descrizione { get; set; }
        public int Dipendente { get; set; }
        public bool Approvata { get; set; }
        public double Rimborso { get; set; }
        public EnumApprovatore? Approvatore { get; set; }


        
    }

    public enum EnumCategoria
    {
        Vitto = 1,
        Alloggio = 2,
        Trasferta = 3,
        Altro = 4
    }

    public enum EnumApprovatore
    {
        Manager = 1,
        OperationManager = 2,
        CEO = 3
    }
}
