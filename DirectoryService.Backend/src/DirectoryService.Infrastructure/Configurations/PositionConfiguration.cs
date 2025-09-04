using DirectoryService.Domain.Positions;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    { 
        builder.ToTable("positions");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PositionId.Create(value))
            .HasColumnName("position_id");

        builder.ComplexProperty(p => p.Name, pb =>
        {
            pb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.Text.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("position_name");
        });

        builder.ComplexProperty(p => p.Description, pb =>
        {
            pb.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(Constants.Text.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("position_description");
        });
        
        builder.Property(l => l.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(l => l.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
        
        builder.HasMany(l => l.Departments)
            .WithOne()
            .HasForeignKey(l => l.PositionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}