using Microsoft.Data.Sqlite;
namespace LabManager.Database;

class DataBaseSetup
{

    public DataBaseSetup()
    {
        CreateTableComputer();
        CreateTableLab();   
    }


    private void CreateTableComputer()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Computers(
                id int not null primary key,
                ram varchar(100) not null,
                processor varchar(100) not null

            );
        " ;
        command.ExecuteNonQuery();
        connection.Close();
    }
     private void CreateTableLab()
    {
        
    }
}