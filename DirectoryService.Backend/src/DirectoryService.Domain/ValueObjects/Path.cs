using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Path
{
    private Path(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Path, Error> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("path");

        return new Path(value);
    }
}