using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasConversion(
                id => id.Value,
                value => LocationId.Create(value))
            .HasColumnName("location_id");

        builder.ComplexProperty(l => l.Name, lb =>
        {
            lb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.Text.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("location_name");
        });

        builder.OwnsOne(l => l.Address, lb =>
        {
            lb.ToJson("location_address");
            
            lb.Property(a => a.City)
                .IsRequired()
                .HasColumnName("city");
            
            lb.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("street");
            
            lb.Property(a => a.StreetNumber)
                .IsRequired()
                .HasColumnName("street_number");
        });

        builder.ComplexProperty(l => l.TimeZone, lb =>
        {
            lb.Property(a => a.Value)
                .IsRequired()
                .HasColumnName("location_timezone");
        });
        
        builder.Property(l => l.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("is_active");
        
        builder.Property(l => l.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(l => l.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
        
        builder.HasMany(l => l.Departments)
            .WithOne()
            .HasForeignKey(l => l.LocationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}