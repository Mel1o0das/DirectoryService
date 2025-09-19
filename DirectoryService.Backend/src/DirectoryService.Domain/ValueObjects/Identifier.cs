using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Identifier
{
    private Identifier(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Identifier, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || 
           value.Length >= Constants.Text.MAX_LOW_TEXT_LENGTH ||
           Regex.IsMatch(value, @"^[a-zA-Z]+$"))
            return Errors.General.ValueIsInvalid("identifier");
            
        return new Identifier(value);
    }
}