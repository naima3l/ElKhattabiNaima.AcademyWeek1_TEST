using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Entities;
using ElKhattabiNaima.AcademyWeek1_TEST.CORE.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElKhattabiNaima.AcademyWeek1_TEST.ADO
{
    public class RepositoryDipendenteADO : IDipendenteRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                    "Integrated Security = true;";
        public Dipendente GetByName(string name)
        {
            Dipendente dipendente = new Dipendente();
            //try
            //{
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Dipendenti WHERE Nome = @nome";
                    command.Parameters.AddWithValue("@nome", name);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dipendente.Id = (int)reader["Id"];
                        dipendente.Nome = (string)reader["Nome"];
                    }

                    return dipendente;
                }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
    }
}
