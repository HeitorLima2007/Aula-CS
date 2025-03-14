using Npgsql;


public class DatabaseConnection
{

    private readonly string? _connectionString;

    public DatabaseConnection(IConfiguration configuration)
    {
//#pragma warning disable CS88601 //Possiblita uma referência nula
_connectionString = configuration.GetConnectionString("DefaultConnection");
//#pragma warning restore CS6801
    }

    public NpgsqlConnection GetConnection(){

        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

}