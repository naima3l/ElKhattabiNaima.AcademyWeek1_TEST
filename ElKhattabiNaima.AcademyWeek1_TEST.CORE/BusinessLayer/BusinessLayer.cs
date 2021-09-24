using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Entities;
using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.CORE.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly ISpeseRepository speseRepo;
        private readonly IDipendenteRepository dipendenteRepo;

        public BusinessLayer(ISpeseRepository speseRepository, IDipendenteRepository dipendenteRepository)
        {
            speseRepo = speseRepository;
            dipendenteRepo = dipendenteRepository;
        }

        public int Authentication(string name)
        {
            var dipendenteEsistente = dipendenteRepo.GetByName(name);
            if(dipendenteEsistente == null)
            {
                return 0;
            }
            return dipendenteEsistente.Id;
        }

        public void File(int id)
        {
            List<Spese> spese = new List<Spese>();
            try
            {
                spese = speseRepo.GetSpeseByDipendente(id);

                if (spese.Count() > 0)
                {
                    foreach(var spesa in spese)
                    {
                        ScriviSuFile(spesa);
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void ScriviSuFile(Spese spesa)
        {
            //cosa farà alla creazione dell'evento => scrittura su file

            string path = @"C:\Users\naima.el.khattabi\Desktop\Spese.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"Data : {spesa.Data} - Categoria : {spesa.Categoria}" +
                        $" - Spesa sostenuta : {spesa.Spesa} - Approvata : {spesa.Approvata} - Rimborso : {(float)spesa.Rimborso}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GestisciRimborsi()
        {
            List<Spese> spese = new List<Spese>();
            try
            {
                spese = speseRepo.GetSpeseNullApproved();

                if(spese.Count() > 0)
                {
                    foreach(var spesa in spese)
                    {
                        switch(spesa.Spesa)
                        {
                            case <=400: //approvate => MANAGER
                                spesa.Approvata = true;
                                spesa.Approvatore = (EnumApprovatore)1;
                                spesa.Rimborso = CalcolaRimborso((float)spesa.Spesa, spesa.Categoria);
                                break;
                            case <= 1000: //approvate => OPERATION MANAGER
                                spesa.Approvata = true;
                                spesa.Approvatore = (EnumApprovatore)2;
                                spesa.Rimborso = CalcolaRimborso((float)spesa.Spesa, spesa.Categoria);
                                break;
                            case <= 2500: //approvate => CEO
                                spesa.Approvata = true;
                                spesa.Approvatore = (EnumApprovatore)3;
                                spesa.Rimborso = CalcolaRimborso((float)spesa.Spesa, spesa.Categoria);
                                break;
                            case > 2500: //NOT APPROVED
                                spesa.Approvata = false;
                                spesa.Rimborso = 0;
                                break;
                        }
                        speseRepo.Update(spesa);

                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private float CalcolaRimborso(float spesa, EnumCategoria categoria)
        {
            float rimborso = 0;

            switch((int)categoria)
            {
                case 1: //vitto
                    rimborso = spesa - ((spesa * 70) / 100);
                    break;
                case 2: //alloggio
                    rimborso = spesa;
                    break;
                case 3: //trasferta
                    rimborso = (spesa/2)+50;
                    break;
                case 4: //altro
                    rimborso = spesa - ((spesa * 10) / 100);
                    break;
            }

            return rimborso;
        }
    }
}
