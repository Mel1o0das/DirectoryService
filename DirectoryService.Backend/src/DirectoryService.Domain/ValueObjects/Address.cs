using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Address
{
    private Address(string city, string street, int streetNumber)
    {
        City = city;
        Street = street;
        StreetNumber = streetNumber;
    }
    
    public string City { get; }
    
    public string Street { get; }
    
    public int StreetNumber { get; }

    public static Result<Address, Error> Create(string city, string street, int streetNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsRequired("city");
        
        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsRequired("street");
        
        if (streetNumber <= 0)
            return Errors.General.ValueIsRequired("streetNumber");
        
        return new Address(city, street, streetNumber);
    }
}