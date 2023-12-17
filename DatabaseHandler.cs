using MySqlConnector;
public class DatabaseHandler
{
    private string ConnectionString;

    private string Server;
    private string Database;
    private string Username;
    private string Password;

    // The object constructor has the same name as the object class
    public DatabaseHandler(string server, string database, string username, string password)
    {
        Server = server;
        Database = database;
        Username = username;
        Password = password;

        ConnectionString = $"Server={Server};Database={Database};User ID={Username};Password={Password};";
        Console.WriteLine("connection string created");
    }
    public async Task<int> ExecuteNonQueryAsync(string query)
    {
        int affectedRows = 0;

        await using MySqlConnection connection = new MySqlConnection(ConnectionString);
        await connection.OpenAsync();
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            affectedRows = await cmd.ExecuteNonQueryAsync();
        }

            await connection.CloseAsync();

            return affectedRows;

    }

    public async Task<List<string>> ExecuteQueryAsync(string query)
    {
        List<string> resultData = new List<string>();
        await using MySqlConnection connection = new MySqlConnection(ConnectionString);
        await connection.OpenAsync();
        
        // Retrieve all rows
        using MySqlCommand command = new MySqlCommand(query, connection);
        using MySqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            // Assuming query returns a single column, change accordingly
            string columnValue = reader.GetString(0);
                            
            // Add the retrieved data to the result list
            resultData.Add(columnValue);
        }
       
        await connection.CloseAsync();
        return resultData;
    }
}