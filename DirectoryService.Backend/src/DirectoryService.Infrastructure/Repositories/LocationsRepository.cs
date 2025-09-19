using DirectoryService.Application.Locations;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Infrastructure.Repositories;

public class LocationsRepository : ILocationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LocationsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> AddAsync(Location location, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(location, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return location.Id.Value;
    }
}