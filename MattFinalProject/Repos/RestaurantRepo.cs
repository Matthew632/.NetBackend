using MattFinalProject.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MattFinalProject.Repos
{
    public class RestaurantRepo

    {
        public ResSummary GetRestaurants()
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=final_project";
            ResSummary res = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM restaurants WHERE restaurant_id = 1", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        res = new ResSummary { restaurant_id = reader.GetInt32(0), restaurant_name = reader.GetString(1), restaurant_address = reader.GetString(2) };
                return res;

            }
        }
    }
}
