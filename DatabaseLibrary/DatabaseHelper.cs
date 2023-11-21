using DatabaseLibrary.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public static class DatabaseHelper
    {
        private static SqliteConnection connection = new SqliteConnection(@"Data Source=habit.db");

        public static void InitializeConnection()
        {
            using (connection)
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drinking_water (
	                  Id	    INTEGER NOT NULL UNIQUE,
	                  Date	    TEXT NOT NULL,
	                  Quantity	INTEGER NOT NULL,
	                  PRIMARY   KEY(Id AUTOINCREMENT)
                      );";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static List<DrinkingWaterModel> GetAllData()
        {
            List<DrinkingWaterModel> data = new();

            using (connection)
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @"SELECT * FROM drinking_water";

                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new DrinkingWaterModel
                            {
                                Id = (int)(long)reader["Id"],
                                Date = DateTime.ParseExact(reader["Date"].ToString(), "dd-MM-yy", new CultureInfo("en-US")),
                                Quantity = (int)(long)reader["Quantity"]
                            });
                    }
                }

                connection.Close();
            }

            return data;
        }

        public static void InsertRow(DrinkingWaterModel model)
        {
            using (connection)
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                (string date, int quantity) = User
            }
        }


    }
}
