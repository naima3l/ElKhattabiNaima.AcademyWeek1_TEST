using ElKhattabiNaima.AcademyWeek1_TEST.ADO;
using ElKhattabiNaima.AcademyWeek1_TEST.CORE;
using ElKhattabiNaima.AcademyWeek1_TEST.CORE.BusinessLayer;
using System;

namespace ElKhattabiNaima.AcademyWeek1_TEST.ConsoleAppDip
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositorySpeseADO(), new RepositoryDipendenteADO());
        public static int id;
        static void Main(string[] args)
        {
            try
            {
                string name = GetName();
                var result = bl.Authentication(name);
                if(result == 0)
                {
                    Console.WriteLine($"Mi dispiace {name} ma non sei registrato nel nostro sistema");
                    return;
                }

                id = result;

                //faccio partire l'evento
                Evento evento = new Evento();
                evento.MandaLaNotifica += Go;
                evento.IfAuthenticationOk();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Go(Evento evento)
        {
            try
            {
                bl.File(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GetName()
        {
            Console.WriteLine("Benvenuto!");
            Console.WriteLine("Inserisci il tuo nome");
            string nome = Console.ReadLine();
            while(string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserisci un nome valido");
            }

            return nome;
        }
    }
}
