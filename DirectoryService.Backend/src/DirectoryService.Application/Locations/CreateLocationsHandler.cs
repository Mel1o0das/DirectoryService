using CSharpFunctionalExtensions;
using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using TimeZone = DirectoryService.Domain.ValueObjects.TimeZone;

namespace DirectoryService.Application.Locations;

public class CreateLocationsHandler
{
    private readonly ILocationRepository _locationRepository;
    private readonly ILogger<CreateLocationsHandler> _logger;

    public CreateLocationsHandler(ILocationRepository locationRepository, ILogger<CreateLocationsHandler> logger)
    {
        _locationRepository = locationRepository;
        _logger = logger;
    }
    
    public async Task<Result<Guid, Error>> Handle(CreateLocationDto createLocationDto, CancellationToken cancellationToken)
    {
        var name = Name.Create(createLocationDto.Name);
        if(name.IsFailure)
            return name.Error;

        var address = Address.Create(
            createLocationDto.City,
            createLocationDto.Street,
            createLocationDto.StreetNumber);
        if(address.IsFailure)
            return address.Error;
        
        var timeZone = TimeZone.Create(createLocationDto.Timezone);
        if(timeZone.IsFailure)
            return timeZone.Error;

        var location = Location.Create(
            name.Value, 
            address.Value, 
            timeZone.Value).Value;
        
        await _locationRepository.AddAsync(location, cancellationToken);
        
        _logger.LogInformation("Created location with id {LocationId}", location.Id.Value);
        
        return location.Id.Value;
    }
}