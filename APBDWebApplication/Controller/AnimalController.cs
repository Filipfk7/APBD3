using APBDWebApplication.Model;
using APBDWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalService _animalsService;

    public AnimalsController(IAnimalService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        var animals = _animalsService.GetAllAnimals(orderBy);
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalsService.GetAnimalById(id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] Animal animal)
    {
        var created = _animalsService.CreateAnimal(animal);
        if (!created)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.IdAnimal }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal animal)
    {
        if (id != animal.IdAnimal)
        {
            return BadRequest("ID mismatch");
        }
        var updated = _animalsService.UpdateAnimal(animal);
        if (!updated)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var deleted = _animalsService.DeleteAnimal(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}