using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using TimeZone = DirectoryService.Domain.ValueObjects.TimeZone;

namespace DirectoryService.Application.Locations;

public class LocationsService
{
    private readonly ILocationRepository _locationRepository;
    private readonly ILogger<LocationsService> _logger;

    public LocationsService(ILocationRepository locationRepository, ILogger<LocationsService> logger)
    {
        _locationRepository = locationRepository;
        _logger = logger;
    }
    
    public async Task<Guid> Create(CreateLocationDto createLocationDto, CancellationToken cancellationToken)
    {
        var name = Name.Create(createLocationDto.Name).Value;

        var address = Address.Create(
            createLocationDto.City,
            createLocationDto.Street,
            createLocationDto.StreetNumber).Value;
        
        var timeZone = TimeZone.Create(createLocationDto.Timezone).Value;

        var location = Location.Create(
            name, 
            address, 
            timeZone, 
            createLocationDto.Departments).Value;
        
        await _locationRepository.AddAsync(location, cancellationToken);
        
        _logger.LogInformation("Created location with id {LocationId}", location.Id.Value);
        
        return location.Id.Value;
    }
}