using MattFinalProject.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MattFinalProject.Repos
{
    public class ImageRepo
    {
        public ImageRepo()
        {
            // here I can put code I want to run every time a new instance is created, could declare variables
            // and it can take arguements that I use to use
        }

        public Image GetImage(int id)
        {
            string conString = "Host=localhost:5432;username=postgres;password=password;Database=final_project";
            Image image = null;
            using (var con = new NpgsqlConnection(conString)) {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT image_path FROM images WHERE {id} = restaurant_id ", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        image = new Image { UrlPath = reader.GetString(0) };
                return image;
                    
            }
        }
    }
}
