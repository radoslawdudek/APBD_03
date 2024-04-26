using APBD_03.Models;
using APBD_03.Repositories;

namespace APBD_03.Services;

public class AnimalsService : IAnimalsService
{

    private readonly IAnimalsRepository _animalsRepository;
    
    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    
    public IEnumerable<Animal> GetAnimal(string orderBy)
    {
        return _animalsRepository.GetAnimal(orderBy);
    }
    
    public Animal? GetAnimal(int id)
    {
        return _animalsRepository.GetAnimal(id);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal); ;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        return _animalsRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalsRepository.DeleteAnimal(id);
    }
}