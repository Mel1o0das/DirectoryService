namespace DirectoryService.Domain.Models;

public class DepartmentId
{
    private DepartmentId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    
    public static DepartmentId NewDepartmentId() => new DepartmentId(Guid.NewGuid());
    
    public static DepartmentId EmptyDepartmentId() => new DepartmentId(Guid.Empty);

    public static DepartmentId Create(Guid id) => new(id);
}