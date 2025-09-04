using DirectoryService.Application.Locations;
using DirectoryService.Contracts.Locations;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    private readonly LocationsService _locationsService;

    public LocationsController(LocationsService locationsService)
    {
        _locationsService = locationsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLocationDto createLocationDto, 
        CancellationToken cancellationToken)
    {
        var result = await _locationsService.Create(createLocationDto, cancellationToken);
        
        return Ok(result);
    }
}