using Npgsql;
using System;

namespace FinalProject.Repos
{
    public static class ReaderExtentions
    {
        public static string GetStringOrDefault(this NpgsqlDataReader reader, int column)
        {
            return reader.IsDBNull(column) ? default : reader.GetString(column);
        }

        public static int GetIntOrDefault(this NpgsqlDataReader reader, int column)
        {
            return reader.IsDBNull(column) ? default : reader.GetInt32(column);
        }

        public static float GetFloatOrDefault(this NpgsqlDataReader reader, int column)
        {
            return reader.IsDBNull(column) ? default : reader.GetFloat(column);
        }

        public static DateTime GetDateTimeOrDefault(this NpgsqlDataReader reader, int column)
        {
            return reader.IsDBNull(column) ? default : reader.GetDateTime(column);
        }

    }
}
