using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;
using TimeZone = DirectoryService.Domain.ValueObjects.TimeZone;

namespace DirectoryService.Domain.Locations;

public class Location : Shared.Entity<LocationId>
{
    private readonly List<DepartmentLocation> _departments;

    private Location(LocationId id) 
        : base(id)
    {
    }

    public Location(LocationId id, Name name, Address address, TimeZone timeZone) 
        : base(id)
    {
        Name = name;
        Address = address;
        TimeZone = timeZone;
    }
    
    public Name Name { get; private set; }
    
    public Address Address { get; private set; }
    
    public TimeZone TimeZone { get; private set; }

    public bool IsActive { get; private set; } = true;
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public IReadOnlyList<DepartmentLocation> Departments => _departments;

    public static Result<Location, Error> Create(
        Name name, 
        Address address, 
        TimeZone timeZone)
    {
        return new Location(
            LocationId.NewLocationId(),
            name,
            address,
            timeZone);
    }
}