// Import necessary namespaces for working with ADO.NET and MySQL
using System.Data;
using MySqlConnector;

// Define a class named DatabaseHandler for interacting with a MySQL database
public class DatabaseHandler
{
    // Fields to store connection details
    private string ConnectionString;

    private string Server;
    private string Database;
    private string Username;
    private string Password;

    // The object constructor has the same name as the object class
    // Constructor to initialize connection details
    public DatabaseHandler(string server, string database, string username, string password)
    {
        Server = server;
        Database = database;
        Username = username;
        Password = password;

        // Build the connection string
        ConnectionString = $"Server={Server};Database={Database};User ID={Username};Password={Password};";
        Console.WriteLine("connection string created");
    }
    // Asynchronous method to execute a non-query SQL statement (e.g., INSERT, UPDATE, DELETE)
    public async Task<int> ExecuteNonQueryAsync(string query)
    {
        int affectedRows = 0;

        // Create a MySqlConnection object using the connection string
        await using MySqlConnection connection = new MySqlConnection(ConnectionString);
        // Open the database connection asynchronously
        await connection.OpenAsync();
        // Execute the non-query SQL statement
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            affectedRows = await cmd.ExecuteNonQueryAsync();
        }
            // Close the database connection asynchronously
            await connection.CloseAsync();
            // Return the number of affected rows
            return affectedRows;

    }

    // Asynchronous method to execute a query and return the result as a DataTable
    public async Task<DataTable> ExecuteQueryAsync(string query)
    {
        // Create a MySqlConnection object using the connection string
        await using MySqlConnection connection = new MySqlConnection(ConnectionString);
        // Open the database connection asynchronously
        await connection.OpenAsync();
        
        // Create a DataTable to store the query result
        DataTable dataTable = new DataTable();

        // Retrieve all rows
        // Retrieve data using a MySqlCommand and populate the DataTable with a MySqlDataAdapter
        using MySqlCommand command = new MySqlCommand(query, connection);
        using (MySqlDataAdapter da = new MySqlDataAdapter(command))
        {
            da.Fill(dataTable);
        }

        // Return the populated DataTable
        return dataTable;
    }
}