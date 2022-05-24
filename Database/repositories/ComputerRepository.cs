using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.repositories; 

class ComputerRepository
{
   private DatabaseConfig databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig) => this.databaseConfig = databaseConfig;


    public List<Computer> All
    {
        get
        {
            var Computers = new List<Computer>();

            var connection = new SqliteConnection(databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Computers;";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var computer = new Computer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                );

                Computers.Add(computer);
            }
            connection.Close();

            return Computers;

        }
    }

 
public Computer Save(Computer computer)
{
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
       connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor);"; 
        command.Parameters.AddWithValue("$id",computer.Id);
        command.Parameters.AddWithValue("$ram",computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();
        connection.Close();
        return computer;
}
}