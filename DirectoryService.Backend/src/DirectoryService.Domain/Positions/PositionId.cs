namespace DirectoryService.Domain.Positions;

public class PositionId
{
    private PositionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    
    public static PositionId NewPositionId() => new PositionId(Guid.NewGuid());
    
    public static PositionId EmptyPositionId() => new PositionId(Guid.Empty);

    public static PositionId Create(Guid id) => new(id);
}