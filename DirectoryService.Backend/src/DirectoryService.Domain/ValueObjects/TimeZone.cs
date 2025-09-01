using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.ValueObjects;

public record TimeZone
{
    private TimeZone(string value)
    {
        Value = value; 
    }

    public string Value { get; }

    public static Result<TimeZone, string> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return "time zone cannot be empty";
        
        bool isValid = TimeZoneInfo.GetSystemTimeZones()
            .Any(z => z.Id.Equals(value, StringComparison.OrdinalIgnoreCase));
        
        if (!isValid)
            return $"invalid IANA TimeZone: {value}";
        
        return new TimeZone(value);
    }
}