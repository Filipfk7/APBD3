using APBDWebApplication.Model;

namespace APBDWebApplication.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAllAnimals(string orderBy);
    Animal GetAnimalById(int idAnimal);
    bool CreateAnimal(Animal animal);
    bool UpdateAnimal(Animal animal);
    bool DeleteAnimal(int idAnimal);
}