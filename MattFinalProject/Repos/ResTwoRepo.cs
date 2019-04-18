using MattFinalProject.Models;
using Npgsql;
using System.Collections.Generic;

namespace MattFinalProject.Repos
{
    public class ResTwoRepo

    {
        public ResList GetRestaurants()
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=final_project";
            ResSummary res = null;
            ResList allRes = new ResList();
            int counter = 0;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM restaurants", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        res = new ResSummary { restaurant_id = reader.GetInt32(0), restaurant_name = reader.GetString(1), restaurant_address = reader.GetString(2) };
                        allRes.resList.Insert(counter, res);
                        counter++;
                    }
                    
            }
                return allRes;

            }
        }
    }
