using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.ValueObjects;
using TimeZone = DirectoryService.Domain.ValueObjects.TimeZone;

namespace DirectoryService.Domain.Locations;

public class Location : Shared.Entity<LocationId>
{
    private Location(LocationId id) 
        : base(id)
    {
    }

    public Location(LocationId id, Name name, Address address, TimeZone timeZone, IEnumerable<DepartmentLocation> departments) 
        : base(id)
    {
        Name = name;
        Address = address;
        TimeZone = timeZone;
        Departments = departments.ToList();
    }
    
    public Name Name { get; private set; }
    
    public Address Address { get; private set; }
    
    public TimeZone TimeZone { get; private set; }

    public bool IsActive { get; private set; } = true;
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    
    public IReadOnlyList<DepartmentLocation> Departments { get; private set; }

    public static Result<Location, string> Create(
        Name name, 
        Address address, 
        TimeZone timeZone, 
        IEnumerable<DepartmentLocation>? departments)
    {
        if (departments is null || !departments.Any())
            return "departments cannot be null or empty";
        
        return new Location(
            LocationId.NewLocationId(),
            name,
            address,
            timeZone,
            departments);
    }
}