using APBDWebApplication.Model;
using APBDWebApplication.Repository;

namespace APBDWebApplication.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalsRepository;

    public AnimalService(IAnimalRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAllAnimals(string orderBy = "Name")
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public Animal GetAnimalById(int idAnimal)
    {
        return _animalsRepository.GetAnimal(idAnimal);
    }

    public bool CreateAnimal(Animal animal)
    {
        int result = _animalsRepository.CreateAnimal(animal);
        return result > 0;
    }

    public bool UpdateAnimal(Animal animal)
    {
        int result = _animalsRepository.UpdateAnimal(animal);
        return result > 0;
    }

    public bool DeleteAnimal(int idAnimal)
    {
        int result = _animalsRepository.DeleteAnimal(idAnimal);
        return result > 0;
    }
    
}