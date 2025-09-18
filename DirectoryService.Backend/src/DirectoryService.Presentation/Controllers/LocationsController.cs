using DirectoryService.Application.Locations;
using DirectoryService.Contracts.Locations;
using DirectoryService.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateLocationsHandler createLocationsHandler,
        [FromBody] CreateLocationDto createLocationDto, 
        CancellationToken cancellationToken)
    {
        var result = await createLocationsHandler.Handle(createLocationDto, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();
        
        return Ok(result.Value);
    }
}