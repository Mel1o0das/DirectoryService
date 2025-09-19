using DirectoryService.Domain.Departments;

namespace DirectoryService.Contracts.Locations;

public record CreateLocationDto(
    string Name,
    string City,
    string Street,
    int StreetNumber,
    string Timezone);