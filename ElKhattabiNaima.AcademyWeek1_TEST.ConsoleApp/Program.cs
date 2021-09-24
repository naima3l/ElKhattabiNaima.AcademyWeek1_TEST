using ElKhattabiNaima.AcademyWeek1_TEST.ADO;
using ElKhattabiNaima.AcademyWeek1_TEST.CORE.BusinessLayer;
using System;

namespace ElKhattabiNaima.AcademyWeek1_TEST.ConsoleApp
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositorySpeseADO(), new RepositoryDipendenteADO());
        static void Main(string[] args)
        {
            try
            {
                bl.GestisciRimborsi();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
