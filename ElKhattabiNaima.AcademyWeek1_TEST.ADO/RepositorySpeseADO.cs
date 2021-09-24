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
    public class RepositorySpeseADO : ISpeseRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                    "Integrated Security = true;";

        public List<Spese> GetSpeseByDipendente(int id)
        {
            List<Spese> spese = new List<Spese>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Spese WHERE Approvata IS NOT NULL AND Dipendente = @id";
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Spese spesa = new Spese();
                        spesa.Id = (int)reader["Id"];
                        spesa.Categoria = (EnumCategoria)reader["Categoria"];
                        spesa.Data = (DateTime)reader["Data"];
                        spesa.Descrizione = (string)reader["Descrizione"];
                        spesa.Spesa = (double)reader["Spesa"];
                        spesa.Dipendente = (int)reader["Dipendente"];
                        spesa.Rimborso = (double)reader["Rimborso"];
                        spesa.Approvata = (bool)reader["Approvata"];


                        spese.Add(spesa);
                    }

                    return spese;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Spese> GetSpeseNullApproved()
        {
            List<Spese> spese = new List<Spese>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Spese WHERE Approvata IS NULL";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Spese spesa = new Spese();
                        spesa.Id = (int)reader["Id"];
                        spesa.Categoria = (EnumCategoria)reader["Categoria"];
                        spesa.Data = (DateTime)reader["Data"];
                        spesa.Descrizione = (string)reader["Descrizione"];
                        spesa.Spesa = (double)reader["Spesa"];
                        spesa.Dipendente = (int)reader["Dipendente"];


                        spese.Add(spesa);
                    }

                    return spese;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Update(Spese spesa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "update Spese set Approvata = @approvata, Rimborso = @rimborso, Approvatore = @approvatore where Id=@id";
                    command.Parameters.AddWithValue("@id", spesa.Id);
                    command.Parameters.AddWithValue("@approvata", spesa.Approvata);
                    if(spesa.Approvatore == null)
                    {
                        command.Parameters.AddWithValue("@approvatore", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@approvatore", spesa.Approvatore);
                    }
                    command.Parameters.AddWithValue("@rimborso", spesa.Rimborso);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
