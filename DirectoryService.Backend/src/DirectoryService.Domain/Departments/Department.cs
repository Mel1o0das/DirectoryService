using CSharpFunctionalExtensions;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;
using Path = DirectoryService.Domain.ValueObjects.Path;

namespace DirectoryService.Domain.Departments;

public class Department : Shared.Entity<DepartmentId>
{
    private readonly List<Department> _children = [];
    private readonly List<DepartmentLocation> _locations;
    private readonly List<DepartmentPosition> _positions;

    private Department(DepartmentId id)
        : base(id)
    {
    }

    private Department(
        DepartmentId id, 
        Name name, 
        Identifier identifier,
        DepartmentId? parentId,
        Path path,
        short depth) 
        : base(id)
    {
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
    }
    
    public Name Name { get; private set; } // 3 - 150 Символов, NOT NULL
    
    public Identifier Identifier { get; private set; } // 3 - 150 Символов, NOT NULL, только латиница
    
    public DepartmentId? ParentId { get; private set; }
    
    //public IReadOnlyList<Department> Children => _children;
    
    public Path Path { get; private set; } // Денорм. путь (sales.it.dev-team)
    
    public short Depth { get; private set; } // Глубина подразделения

    public bool IsActive { get; private set; } = true;
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    public static Result<Department, Error> Create(
        Name name, 
        Identifier identifier, 
        DepartmentId? parentId,
        Path path, 
        short depth)
    {
        return new Department(
            DepartmentId.NewDepartmentId(), 
            name, 
            identifier,
            parentId,
            path,
            depth);
    }
}