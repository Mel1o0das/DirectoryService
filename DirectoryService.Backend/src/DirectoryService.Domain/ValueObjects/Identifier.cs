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

    public static Result<Identifier, string> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || 
           value.Length >= Constants.Text.MAX_LOW_TEXT_LENGTH ||
           Regex.IsMatch(value, @"^[a-zA-Z]+$"))
            return "value can not be null or empty or than length or contain only alphanumeric characters";
            
        return new Identifier(value);
    }
}