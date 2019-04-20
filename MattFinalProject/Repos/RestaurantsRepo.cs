using FinalProject.Models;
using Npgsql;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class RestaurantsRepo

    {
        public ResList GetRestaurants()
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
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
                        res = new ResSummary { restaurant_id = reader.GetInt32(0), name = reader.GetString(1), description = reader.GetString(2), rating = reader.GetInt32(3), photo_url = reader.GetString(4), address = reader.GetString(5), link_to_360 = reader.GetString(6), latitude = reader.GetFloat(7), longitude = reader.GetFloat(8), table_booking = reader.GetValue(9), created_at = reader.GetDateTime(10) };
                        allRes.resList.Insert(counter, res);
                        counter++;
                    }

            }
            return allRes;

        }
    }
}