using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.ValueObjects;

public record Path
{
    private Path(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Path, string> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return "value cannot be null or empty";

        return new Path(value);
    }
}