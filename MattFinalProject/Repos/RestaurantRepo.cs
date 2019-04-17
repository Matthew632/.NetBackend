//using MattFinalProject.Models;
//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MattFinalProject.Repos
//{
//    public class RestaurantRepo

//    {
//        public ResList GetRestaurants()
//        {
//            string conString = "Host=localhost;username=postgres;password=password;Database=final_project";
//            //ResSummary res = null;
//            var resAll = new ResList();
//            using (var con = new NpgsqlConnection(conString))
//            {
//                con.Open();
//                using (var cmd = new NpgsqlCommand($"SELECT * FROM restaurants", con))
//                using (var reader = cmd.ExecuteReader())
//                    while (reader.Read())
//                        resAll.resList.Add(reader.GetInt32(0));
//                return resAll;

//            }
//        }
//    }
//}
