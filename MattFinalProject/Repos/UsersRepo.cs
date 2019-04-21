using FinalProject.Models;
using Npgsql;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class UsersRepo

    {
        public UsersList GetUsers()
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            User user = null;
            UsersList allUsers = new UsersList();
            int counter = 0;
            using (var con = new NpgsqlConnection(conString))
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
                            restaurant_name = reader.GetStringOrDefault(4)};
                        allUsers.usersList.Insert(counter, user);
                        counter++;
                    }

            }
            return allUsers;

        }
        public User PostUser(UserPost userPost)
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=project_db";
            User user = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"INSERT INTO users (user_name,first_name,last_name,restaurant_name) VALUES (@user_name,@first_name,@last_name,@restaurant_name)", con))
                {
                    cmd.Parameters.AddWithValue("user_name", userPost.User_name);
                    cmd.Parameters.AddWithValue("first_name", userPost.First_name);
                    cmd.Parameters.AddWithValue("last_name", userPost.Last_name);
                    cmd.Parameters.AddWithValue("restaurant_name", userPost.Restaurant_name);
                    cmd.ExecuteNonQuery();
                }

                return user;
            }
        }
    }
}