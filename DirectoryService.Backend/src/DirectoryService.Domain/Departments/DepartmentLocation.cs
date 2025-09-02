using DirectoryService.Domain.Models;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain.Departments;

public class DepartmentLocation
{
    public DepartmentLocation(
        DepartmentId departmentId, 
        Department department, 
        LocationId locationId, 
        Location location)
    {
        DepartmentId = departmentId;
        Department = department;
        LocationId = locationId;
        Location = location;
    }
    
    public DepartmentId DepartmentId { get; }
    
    public Department Department { get; }
    
    public LocationId LocationId { get; }
    
    public Location Location { get; }
}