using APBD_03.Models;
using APBD_03.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_03.Controllers;

[Route("/api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{

    private readonly IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    [HttpGet]
    public IActionResult GetAnimal([FromQuery] string orderBy = "Name")
    {
        var animals = _animalsService.GetAnimal(orderBy);
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal([FromBody] Animal animal)
    {
        var affectedCount = _animalsService.CreateAnimal(animal);
        return Created("api/animals",animal);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal([FromRoute] int id, [FromBody] Animal animal)
    {
        var affectedCount = _animalsService.UpdateAnimal(id, animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal([FromRoute] int id) 
    {
        var affectedCount =  _animalsService.DeleteAnimal(id);
        return NoContent();
    }

    
}