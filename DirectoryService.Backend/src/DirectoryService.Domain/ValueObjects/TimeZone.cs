using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record TimeZone
{
    private TimeZone(string value)
    {
        Value = value; 
    }

    public string Value { get; }

    public static Result<TimeZone, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("timeZone");
        
        bool isValid = TimeZoneInfo.GetSystemTimeZones()
            .Any(z => z.Id.Equals(value, StringComparison.OrdinalIgnoreCase));
        
        if (!isValid)
            return Errors.General.ValueIsInvalid("timeZone");
        
        return new TimeZone(value);
    }
}