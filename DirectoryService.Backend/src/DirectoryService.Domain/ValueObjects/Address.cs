using CSharpFunctionalExtensions;

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

    public static Result<Address, string> Create(string city, string street, int streetNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            return "city can not be empty";
        
        if (string.IsNullOrWhiteSpace(street))
            return "street can not be empty";
        
        if (streetNumber <= 0)
            return "street number can not be zero or negative";
        
        return new Address(city, street, streetNumber);
    }
}