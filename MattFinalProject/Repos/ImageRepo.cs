﻿using FinalProject.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repos
{
    public class ImageRepo
    {
        public ImageRepo()
        {
            // here I can put code I want to run every time a new instance is created, could declare variables
            // and it can take arguements that I use
        }

        public ImageRepo(int i)
        {
            //this would get called if an integer was passed
        }

        public ImageSummary GetImage(int id)
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=final_project";
            ImageSummary image = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT image_path FROM images WHERE {id} = restaurant_id ", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        image = new ImageSummary { UrlPath = reader.GetString(0) };
                return image;

            }
        }
        public Image PostImage(PostImage postImage)
        {
            string conString = "Host=localhost;username=postgres;password=password;Database=final_project";
            Image image = null;
            using (var con = new NpgsqlConnection(conString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"INSERT INTO images (image_path,restaurant_id) VALUES (@path,@id)", con))
                {
                    cmd.Parameters.AddWithValue("path", postImage.UrlPath);
                    cmd.Parameters.AddWithValue("id", postImage.ResId);
                    cmd.ExecuteNonQuery();
                }

                return image;
            }
        }
    }
}
