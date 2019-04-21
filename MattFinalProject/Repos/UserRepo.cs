using FinalProject.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class UserRepo : IUserRepo
    {
        private string connectionString;
        public UserRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("default");
        }

        public User GetUser(int id)
        {
            User user = null;


            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM users WHERE user_id = {id}", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        user = new User { user_id = reader.GetInt32(0), user_name = reader.GetString(1), first_name = reader.GetString(2), last_name = reader.GetString(3), restaurant_name = reader.GetString(4) };

            }

            return user;

        }
    }
}