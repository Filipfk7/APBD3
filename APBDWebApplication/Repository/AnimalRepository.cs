using System.Data.SqlClient;
using APBDWebApplication.Model;

namespace APBDWebApplication.Repository;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        List<Animal> animals = new List<Animal>();
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var command = new SqlCommand($"SELECT * FROM Animals ORDER BY {orderBy}", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString(),
                Area = reader["Area"].ToString()
            });
        }
        return animals;
    }

    public Animal GetAnimal(int idAnimal)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var command = new SqlCommand("SELECT * FROM Animals WHERE IdAnimal = @IdAnimal", connection);
        command.Parameters.AddWithValue("@IdAnimal", idAnimal);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Animal
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString(),
                Area = reader["Area"].ToString()
            };
        }
        return null;
    }

    public int CreateAnimal(Animal animal)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var command = new SqlCommand("INSERT INTO Animals (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)", connection);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        return command.ExecuteNonQuery();
    }

    public int UpdateAnimal(Animal animal)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var command = new SqlCommand("UPDATE Animals SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal", connection);
        command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        return command.ExecuteNonQuery();
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var command = new SqlCommand("DELETE FROM Animals WHERE IdAnimal = @IdAnimal", connection);
        command.Parameters.AddWithValue("@IdAnimal", idAnimal);
        return command.ExecuteNonQuery();
    }
}