using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    { 
        builder.ToTable("department_positions");
        
        builder.HasKey(dl => dl.Id).HasName("department_position_id");

        builder.Property(dl => dl.DepartmentId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => DepartmentId.Create(value))
            .HasColumnName("department_id");
        
        builder.Property(dl => dl.PositionId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => PositionId.Create(value))
            .HasColumnName("location_id");
    }
}