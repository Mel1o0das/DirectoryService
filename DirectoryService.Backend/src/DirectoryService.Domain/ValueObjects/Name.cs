using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Name
{
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Name, string> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length >= Constants.Text.MAX_LOW_TEXT_LENGTH)
            return "Name can not be empty or upper than length";
        
        return new Name(value);
    }
}