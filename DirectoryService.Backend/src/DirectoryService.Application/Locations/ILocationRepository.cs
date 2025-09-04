﻿using DirectoryService.Domain.Locations;

namespace DirectoryService.Application.Locations;

public interface ILocationRepository
{
    Task<Guid> AddAsync(Location location, CancellationToken cancellationToken = default);
}