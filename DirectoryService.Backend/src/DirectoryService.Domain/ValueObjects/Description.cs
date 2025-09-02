using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Description
{
    private Description(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Description, string> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length >= Constants.Text.MAX_HIGH_TEXT_LENGTH)
            return "Description can not be empty or upper than length";
        
        return new Description(value);
    }
}