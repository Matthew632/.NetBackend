using FinalProject.Models;
using Npgsql;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class UserRepo

    {
        public User GetUser(int id)
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            User user = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM users WHERE user_id = {id}", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        user = new User { user_id = reader.GetInt32(0), user_name = reader.GetString(1), first_name = reader.GetString(2), last_name = reader.GetString(3), restaurant_name = reader.GetString(4)};

            }
            return user;

        }
    }
}