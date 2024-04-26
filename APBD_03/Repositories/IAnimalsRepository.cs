using APBD_03.Models;

namespace APBD_03.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimal(string orderBy);
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int idAnimal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int idAnimal);
}