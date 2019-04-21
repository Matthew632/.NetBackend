using System;
using Xunit;
using Npgsql;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnsEmptyStringIfColumnDBNull()
        {
            var reader = NpgsqlDataReader();
        }
    }
}
