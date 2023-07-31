using Microsoft.Data.Sqlite;

namespace Shop_Manager.Database;

public class Database
{
    private SqliteConnection _connection;

    public Database()
    {
        _connection = new SqliteConnection("Data Source=data.sqlite");
    }

    public void createTables()
    {
        using (_connection)
        {
            _connection.Open();
            string createTableRecordsSQL = "CREATE TABLE IF NOT EXISTS Records (" +
                                    "record_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "date TEXT NOT NULL, " +
                                    "name TEXT NOT NULL, " +
                                    "dollars INTEGER NOT NULL, " +
                                    "cents INTEGER NOT NULL " +                                    
                                    ")";

            runSQLNonQuery(createTableRecordsSQL);
        }
        _connection.Close();
    }

    private void runSQLNonQuery(string command)
    {
        SqliteCommand sqliteCommand = new SqliteCommand(command, _connection);
        sqliteCommand.ExecuteNonQuery();
    }
}