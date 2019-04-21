using FinalProject.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class CommunicationRepo : ICommunicationRepo
    {
        private string connectionString;
        public CommunicationRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("default");
        }
        public Helper GetHelper()
        {
            Helper helper = null;
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM helper_table", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        helper = new Helper
                        {
                            helper_table_id = reader.GetInt32(0),
                            patched_id = reader.GetIntOrDefault(1),
                            current_user_id = reader.GetIntOrDefault(2)
                        };
                return helper;

            }
            //public User PostUser(UserPost userPost)
            //{
            //    string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            //    User user = null;
            //    using (var con = new NpgsqlConnection(conString))
            //    {
            //        con.Open();
            //        using (var cmd = new NpgsqlCommand($"INSERT INTO users (user_name,first_name,last_name,restaurant_name) VALUES (@user_name,@first_name,@last_name,@restaurant_name)", con))
            //        {
            //            cmd.Parameters.AddWithValue("user_name", userPost.User_name);
            //            cmd.Parameters.AddWithValue("first_name", userPost.First_name);
            //            cmd.Parameters.AddWithValue("last_name", userPost.Last_name);
            //            cmd.Parameters.AddWithValue("restaurant_name", userPost.Restaurant_name);
            //            cmd.ExecuteNonQuery();
            //        }

            //        return user;
            //    }
            //}
        }
    }
}