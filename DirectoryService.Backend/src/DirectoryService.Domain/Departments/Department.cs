using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Positions;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Departments;

public class Department : Shared.Entity<DepartmentId>
{
    private List<Department> _children = [];
    
    private Department(DepartmentId id)
        : base(id)
    {
    }

    private Department(
        DepartmentId id, 
        Name name, 
        Identifier identifier,
        string path,
        short depth,
        IEnumerable<Location> locations,
        IEnumerable<Position> positions) 
        : base(id)
    {
        Name = name;
        Identifier = identifier;
        Path = path;
        Depth = depth;
        Locations = locations.ToList();
        Positions = positions.ToList();
    }
    
    public Name Name { get; private set; } // 3 - 150 Символов, NOT NULL
    
    public Identifier Identifier { get; private set; } // 3 - 150 Символов, NOT NULL, только латиница
    
    public DepartmentId? ParentId { get; private set; }
    
    public IReadOnlyList<Department> Children => _children;
    
    public string Path { get; private set; } // Денорм. путь (sales.it.dev-team)
    
    public short Depth { get; private set; } // Глубина подразделения

    public bool IsActive { get; private set; } = true;
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    
    public IReadOnlyList<Location> Locations { get; private set; }
    
    public IReadOnlyList<Position> Positions { get; private set; }

    public static Result<Department, string> Create(
        Name name, 
        Identifier identifier, 
        string path, 
        short depth,
        IEnumerable<Location>? locations,
        IEnumerable<Position>? positions)
    {
        if(locations is null || !locations.Any())
            return "locations cannot be null or empty";
        
        if(positions is null || !positions.Any())
            return "positions cannot be null or empty";
        
        return new Department(
            DepartmentId.NewDepartmentId(), 
            name, 
            identifier,
            path,
            depth,
            locations,
            positions);
    }
}