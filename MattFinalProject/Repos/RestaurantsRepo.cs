using FinalProject.Models;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class RestaurantsRepo : IRestaurantsRepo

    {
        public ResList GetRestaurants()
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            
            ResList allRes = new ResList();
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM restaurants", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var res = new ResSummary
                        {
                            restaurant_id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            description = reader.GetString(2),
                            rating = reader.GetIntOrDefault(3),
                            photo_url = reader.GetStringOrDefault(4),
                            address = reader.GetStringOrDefault(5),
                            link_to_360 = reader.GetStringOrDefault(6),
                            latitude = reader.GetFloatOrDefault(7),
                            longitude = reader.GetFloatOrDefault(8),
                            table_booking = reader.GetStringOrDefault(9),
                            created_at = reader.GetDateTime(10)
                        };
                        allRes.restaurants.Add(res);
                    }
            }
            return allRes;
        }

        private string GetString(NpgsqlDataReader reader, int column ) {
            return reader.IsDBNull(column) ? default : reader.GetString(column);
        }

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



        public ResSummary PostRestaurant(ResPost resPost)
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            ResSummary resSummary = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                int id = -1;
                using (var cmd = new NpgsqlCommand($"INSERT INTO restaurants (name,description,rating,photo_url,address,link_to_360,latitude,longitude,table_booking) VALUES (@name,@description,@rating,@photo_url,@address,@link_to_360,@latitude,@longitude,@table_booking) RETURNING restaurant_id", con))
                {
                    cmd.Parameters.AddWithValue("name", resPost.Name);
                    cmd.Parameters.AddWithValue("description", resPost.Description);
                    cmd.Parameters.AddWithValue("rating", resPost.Rating);
                    cmd.Parameters.AddWithValue("photo_url", resPost.Photo_url);
                    cmd.Parameters.AddWithValue("address", resPost.Address);
                    cmd.Parameters.AddWithValue("link_to_360", resPost.Link_to_360);
                    cmd.Parameters.AddWithValue("latitude", resPost.Latitude);
                    cmd.Parameters.AddWithValue("longitude", resPost.Longitude);
                    cmd.Parameters.Add(new NpgsqlParameter("table_booking", NpgsqlDbType.Jsonb)
                    { Value = resPost.TableBooking.ToString() });

                    id = int.Parse(cmd.ExecuteScalar().ToString());
                }
                using (var cmd = new NpgsqlCommand($"SELECT * FROM restaurants WHERE restaurant_id = {id} ", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        resSummary = new ResSummary { restaurant_id = reader.GetInt32(0), name = reader.GetString(1), description = reader.GetString(2), rating = reader.GetInt32(3), photo_url = reader.GetString(4), address = reader.GetString(5), link_to_360 = reader.GetString(6), latitude = reader.GetFloat(7), longitude = reader.GetFloat(8), table_booking = reader.GetValue(9), created_at = reader.GetDateTime(10) };

            }

            return resSummary;
        }


        public void TEST() { }
    }

}