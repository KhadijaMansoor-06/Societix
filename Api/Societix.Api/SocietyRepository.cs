using Microsoft.Data.SqlClient;

namespace Societix.Api
{
    public class SocietyRepository
    {
        private readonly string _connectionString;

        public SocietyRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SocietixDb")
                ?? throw new InvalidOperationException("Connection string 'SocietixDb' not found.");
        }

        // Get all societies
        public List<Society> GetAll()
        {
            var list = new List<Society>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            const string sql = "SELECT SocietyId, Name, Category, Description, CreatedDate FROM Societies ORDER BY Name";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(Map(reader));
            }
            return list;
        }

        // Get one society by id (returns null if it does not exist)
        public Society? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            const string sql = "SELECT SocietyId, Name, Category, Description, CreatedDate FROM Societies WHERE SocietyId = @id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);   // parameter, not string concatenation
            using var reader = cmd.ExecuteReader();

            return reader.Read() ? Map(reader) : null;
        }

        // Turns one database row into a Society object
        private static Society Map(SqlDataReader r) => new Society
        {
            SocietyId = r.GetInt32(0),
            Name = r.GetString(1),
            Category = r.GetString(2),
            Description = r.GetString(3),
            CreatedDate = r.GetDateTime(4)
        };
    }
}