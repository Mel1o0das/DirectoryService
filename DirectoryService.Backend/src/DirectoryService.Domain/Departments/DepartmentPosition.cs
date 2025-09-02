using DirectoryService.Domain.Models;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain.Departments;

public record DepartmentPosition
{
    public DepartmentPosition(
        DepartmentId departmentId, 
        Department department, 
        PositionId positionId, 
        Position position)
    {
        DepartmentId = departmentId;
        Department = department;
        PositionId = positionId;
        Position = position;
    }
    
    public DepartmentId DepartmentId { get; }
    
    public Department Department { get; }
    
    public PositionId PositionId { get; }
    
    public Position Position { get; }
}