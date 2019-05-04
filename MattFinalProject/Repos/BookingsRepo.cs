using FinalProject.Controllers;
using FinalProject.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;

namespace FinalProject.Repos
{
    public class BookingsRepo : IBookingsRepo
    {
        private string connectionString;
        public BookingsRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("default");
        }
        public LocList GetTables(int id)
        {            
            LocList allLocs = new LocList();
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT table_id, x_axis, y_axis, z_axis FROM table_bookings WHERE restaurant_id = {id} AND x_axis IS NOT NULL", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var locations = new Locations
                        {
                            table_id = reader.GetInt32(0),
                            x_axis = reader.GetFloat(1),
                            y_axis = reader.GetFloatOrDefault(2),
                            z_axis = reader.GetFloatOrDefault(3)
                        };
                        allLocs.locations.Add(locations);
                    }
            }
            return allLocs;
        }

        private string GetString(NpgsqlDataReader reader, int column ) {
            return reader.IsDBNull(column) ? default : reader.GetString(column);
        }

        public BookingsList GetBookings(int id)
        {
            BookingsList allBookings = new BookingsList();
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand($"SELECT table_id, hour_booked, date_booked, user_id FROM table_bookings WHERE restaurant_id = {id} AND date_booked IS NOT NULL", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var bookings = new Bookings
                        {
                            table_id = reader.GetInt32(0),
                            hour_booked = reader.GetIntOrDefault(1),
                            date_booked = reader.GetString(2),
                            user_id = reader.GetIntOrDefault(3)
                        };
                        allBookings.bookings.Add(bookings);
                    }
            }
            return allBookings;
        }

        public BookingPost PostBooking(BookingPost bookingPost)
        {
            BookingPost postBooking = null;
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                int id = -1;
                if (bookingPost.date_booked != null)
                {
                    using (var cmd = new NpgsqlCommand($"INSERT INTO table_bookings (restaurant_id,table_id,hour_booked,date_booked,user_id) VALUES (@restaurant_id,@table_id,@hour_booked,@date_booked,@user_id) RETURNING table_booking_id", con))
                    {
                        cmd.Parameters.AddWithValue("restaurant_id", bookingPost.restaurant_id);
                        cmd.Parameters.AddWithValue("table_id", bookingPost.table_id);
                        cmd.Parameters.AddWithValue("hour_booked", bookingPost.hour_booked);
                        cmd.Parameters.AddWithValue("date_booked", bookingPost.date_booked);
                        cmd.Parameters.AddWithValue("user_id", bookingPost.user_id);
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
                else
                {
                    using (var cmd = new NpgsqlCommand($"INSERT INTO table_bookings (restaurant_id,table_id,x_axis,y_axis,z_axis) VALUES (@restaurant_id,@table_id,@x_axis,@y_axis,@z_axis) RETURNING table_booking_id", con))
                    {
                        cmd.Parameters.AddWithValue("restaurant_id", bookingPost.restaurant_id);
                        cmd.Parameters.AddWithValue("table_id", bookingPost.table_id);
                        cmd.Parameters.AddWithValue("x_axis", bookingPost.x_axis);
                        cmd.Parameters.AddWithValue("y_axis", bookingPost.y_axis);
                        cmd.Parameters.AddWithValue("z_axis", bookingPost.z_axis);
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
                using (var cmd = new NpgsqlCommand($"SELECT * FROM table_bookings WHERE table_booking_id = {id} ", con))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        postBooking = new BookingPost { restaurant_id = reader.GetIntOrDefault(1),
                            table_id = reader.GetInt32(2),
                            x_axis = reader.GetFloatOrDefault(3),
                            y_axis = reader.GetFloatOrDefault(4),
                            z_axis = reader.GetFloatOrDefault(5),
                            hour_booked = reader.GetIntOrDefault(6),
                            date_booked = reader.GetStringOrDefault(7),
                            user_id = reader.GetIntOrDefault(8)};
            }
            return postBooking;
        }
    }
}