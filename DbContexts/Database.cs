using Microsoft.Data.Sqlite;

namespace Shop_Manager.Database;

public class Database
{
    private SqliteConnection _connection;
    private SqliteConnection _connectionTest;

    public Database()
    {
        _connection = new SqliteConnection("Data Source=data.sqlite");
        _connectionTest = new SqliteConnection("Data Source=test_data.sqlite");
    }

    public void createTables()
    {
        string createTableRecordsSQL = "CREATE TABLE IF NOT EXISTS Records (" +
                                    "record_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "date TEXT NOT NULL, " +
                                    "name TEXT NOT NULL, " +
                                    "dollars INTEGER NOT NULL, " +
                                    "cents INTEGER NOT NULL " +                                    
                                    ")";
        using (_connection)
        {
            _connection.Open();
            runSQLNonQuery(_connection, createTableRecordsSQL);
        }
        _connection.Close();

        
    }

    public void createTestTables()
    {

        string dropAllTablesSQL = "SELECT 'DROP TABLE IF EXISTS ' || name || ';' " +
                                    "FROM sqlite_master " +
                                    "WHERE type = 'table';";

        string createTableRecordsSQL = "CREATE TABLE IF NOT EXISTS Records (" +
                                    "record_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "date TEXT NOT NULL, " +
                                    "name TEXT NOT NULL, " +
                                    "dollars INTEGER NOT NULL, " +
                                    "cents INTEGER NOT NULL " +                                    
                                    ")";
        using (_connectionTest)
        {
            _connectionTest.Open();
            runSQLNonQuery(_connectionTest, dropAllTablesSQL);
            runSQLNonQuery(_connectionTest, createTableRecordsSQL);
        }
    }
    
    private void runSQLNonQuery(SqliteConnection connection, string command)
    {
        SqliteCommand sqliteCommand = new SqliteCommand(command, connection);
        sqliteCommand.ExecuteNonQuery();
    }
}