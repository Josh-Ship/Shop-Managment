using Microsoft.Data.Sqlite;

namespace Shop_Sales.Database;

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
                                    "date DATE NOT NULL, " +
                                    "sales_id INTEGER, " +
                                    "FOREIGN KEY (sales_id) REFERENCES Sales(sale_id) )";
            
            string createTableSalesSQL = "CREATE TABLE IF NOT EXISTS Sales (" +
                                    "sale_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "amount DECIMAL(10, 2), " +
                                    "revenue_type_id INTEGER, " +
                                    "FOREIGN KEY (revenue_type_id) REFERENCES RevenueType(revenue_type_id) )";

            string createTableRevenueTypeSQL = "CREATE TABLE IF NOT EXISTS RevenueType (" +
                                    "revenue_type_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "amount DECIMAL(10, 2) )";
            
            runSQLNonQuery(createTableRevenueTypeSQL);
            runSQLNonQuery(createTableSalesSQL);
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