using FinalProject.Models;
using Npgsql;
using System.Collections.Generic;


namespace FinalProject.Repos
{
    public class RestaurantRepo

    {
        public ResSummary GetRestaurant(int id)
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            ResSummary res = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM restaurants WHERE restaurant_id = {id} ", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        res = new ResSummary { restaurant_id = reader.GetInt32(0), name = reader.GetString(1), description = reader.GetString(2), rating = reader.GetInt32(3), photo_url = reader.GetString(4), address = reader.GetString(5), link_to_360 = reader.GetString(6), latitude = reader.GetFloat(7), longitude = reader.GetFloat(8), table_booking = reader.GetValue(9), created_at = reader.GetDateTime(10) };
                return res;

            }
        }

    }
}
