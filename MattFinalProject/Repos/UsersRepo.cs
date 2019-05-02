using FinalProject.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class UsersRepo : IUsersRepo
    {
        private string connectionString;
        public UsersRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("default");
        }
        public UsersList GetUsers()
        {
            User user = null;
            UsersList allUsers = new UsersList();
            int counter = 0;
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM users", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        user = new User { user_id = reader.GetInt32(0),
                            user_name = reader.GetString(1),
                            first_name = reader.GetStringOrDefault(2),
                            last_name = reader.GetStringOrDefault(3),
                            restaurant_id = reader.GetIntOrDefault(4)};
                        allUsers.usersList.Insert(counter, user);
                        counter++;
                    }

            }
            return allUsers;

        }
        public User PostUser(UserPost userPost)
        {
            User user = null;
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"INSERT INTO users (user_name,first_name,last_name,restaurant_id) VALUES (@user_name,@first_name,@last_name,@restaurant_id)", con))
                {
                    cmd.Parameters.AddWithValue("user_name", userPost.User_name);
                    cmd.Parameters.AddWithValue("first_name", userPost.First_name);
                    cmd.Parameters.AddWithValue("last_name", userPost.Last_name);
                    cmd.Parameters.AddWithValue("restaurant_id", userPost.Restaurant_id);
                    cmd.ExecuteNonQuery();
                }

                return user;
            }
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
                        user = new User
                        {
                            user_id = reader.GetInt32(0),
                            user_name = reader.GetString(1),
                            first_name = reader.GetStringOrDefault(2),
                            last_name = reader.GetStringOrDefault(3),
                            restaurant_id = reader.GetIntOrDefault(4)
                        };

            }

            return user;

        }
    }
}