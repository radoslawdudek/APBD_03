using System.Data.SqlClient;
using APBD_03.Models;

namespace APBD_03.Repositories;

public class AnimalsRepository : IAnimalsRepository

{

    private IConfiguration _configuration;
    
    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimal(string orderBy)
    {
        var con = new SqlConnection(_configuration["ConnectionString"]);
        con.Open();

         using var cmd = new SqlCommand();
         cmd.Connection = con;
         cmd.CommandText = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY {orderBy} ASC";
         var dr = cmd.ExecuteReader();
         var animals = new List<Animal>();
         while (dr.Read())
         {
             var animal = new Animal
             {
                 IdAnimal = (int)dr["IdAnimal"],
                 Name = dr["Name"].ToString(),
                 Description = dr["Description"].ToString(),
                 Category = dr["Category"].ToString(),
                 Area = dr["Area"].ToString()
             };
             animals.Add(animal);
         }
         return animals;
    }
    
    public Animal GetAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionString"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Select IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal = @idAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        var dr = cmd.ExecuteReader();

        if (!dr.Read()) return null;

        var animal = new Animal
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString()
        };

        return animal;
    }

        public int DeleteAnimal(int idAnimal)
        {
            using var con = new SqlConnection(_configuration["ConnectionString"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
            cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
        

        

        public int UpdateAnimal(int id, Animal animal)
        {
            using var con = new SqlConnection(_configuration["ConnectionString"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Animal SET Name=@Name, Description =@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
            cmd.Parameters.AddWithValue("@IdAnimal", id);
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
        
        public int CreateAnimal(Animal animal)
        {
            using var con = new SqlConnection(_configuration["ConnectionString"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) OUTPUT INSERTED.IdAnimal VALUES(@Name, @Description, @Category, @Area)";
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var affectedCount = cmd.ExecuteScalar();
            return (int) affectedCount;
        }

    }



