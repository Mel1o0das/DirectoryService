using DirectoryService.Domain.Models;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain.Departments;

public class DepartmentLocation
{
    public DepartmentLocation(
        Guid id,
        DepartmentId departmentId, 
        LocationId locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
    }
    
    public Guid Id { get; }
    
    public DepartmentId DepartmentId { get; }
    
    public LocationId LocationId { get; }
    
}