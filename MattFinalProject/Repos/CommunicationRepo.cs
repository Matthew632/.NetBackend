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
                            patched_table_id = reader.GetIntOrDefault(2),
                            current_user_id = reader.GetIntOrDefault(3)
                        };
                return helper;
            }
        }
            public Helper HelperPatch(PatchHelper patchHelper)
            {
                Helper helper = null;
                using (var con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new NpgsqlCommand($"UPDATE helper_table SET patched_id = @patched_id, patched_table_id = @patched_table_id, current_user_id = @current_user_id", con))
                    {
                        cmd.Parameters.AddWithValue("patched_id", patchHelper.patched_id);
                        cmd.Parameters.AddWithValue("patched_table_id", patchHelper.patched_table_id);
                        cmd.Parameters.AddWithValue("current_user_id", patchHelper.current_user_id);

                    cmd.ExecuteNonQuery();
                    }
                using (var cmd = new NpgsqlCommand($"SELECT * FROM helper_table", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        helper = new Helper
                        {
                            helper_table_id = reader.GetInt32(0),
                            patched_id = reader.GetIntOrDefault(1),
                            patched_table_id = reader.GetIntOrDefault(2),
                            current_user_id = reader.GetIntOrDefault(3)
                        };
                return helper;
            }
            }
        }
    }
