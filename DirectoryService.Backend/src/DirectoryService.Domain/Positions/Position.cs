using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Positions;

public class Position : Shared.Entity<PositionId>
{
    private Position(PositionId id)
        : base(id)
    {
    }

    private Position(PositionId id, Name name, Description description, IEnumerable<DepartmentPosition> departments)
        : base(id)
    {
        Name = name;
        Description = description;
        Departments = departments.ToList();
    }
    
    public Name Name { get; private set; } // UNIQUE, 3–100 симв.
    
    public Description Description { get; private set; } // <= 1000 симв
    
    public bool IsActive { get; private set; } = true;
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    
    public IReadOnlyList<DepartmentPosition> Departments { get; private set; }

    public static Result<Position, string> Create(
        Name name, 
        Description description, 
        IEnumerable<DepartmentPosition>? departments)
    {
        if (departments is null || !departments.Any())
            return "Departments cannot be empty";
        
        return new Position(
            PositionId.NewPositionId(),
            name,
            description,
            departments);
    }
}