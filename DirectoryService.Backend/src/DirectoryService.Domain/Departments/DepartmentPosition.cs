using DirectoryService.Domain.Models;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain.Departments;

public record DepartmentPosition
{
    public DepartmentPosition(
        Guid id,
        DepartmentId departmentId, 
        PositionId positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }
    
    public Guid Id { get; }
    
    public DepartmentId DepartmentId { get; }
    
    public PositionId PositionId { get; }
}