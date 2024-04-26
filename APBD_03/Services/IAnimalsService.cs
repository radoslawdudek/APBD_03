using APBD_03.Models;

namespace APBD_03.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimal(string orderBy);
    Animal? GetAnimal(int id);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}