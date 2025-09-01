namespace DirectoryService.Domain.Locations;

public class LocationId
{
    private LocationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    
    public static LocationId NewLocationId() => new LocationId(Guid.NewGuid());
    
    public static LocationId EmptyLocationId() => new LocationId(Guid.Empty);

    public static LocationId Create(Guid id) => new(id);
}