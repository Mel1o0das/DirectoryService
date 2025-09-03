using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");
        
        builder.HasKey(d => d.Id).HasName("department_id");
        
        builder.Property(d => d.Id)
            .HasConversion(
                id => id.Value,
                value => DepartmentId.Create(value));

        builder.OwnsOne(d => d.Name, db =>
        {
            db.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.Text.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("department_name");
        });
        
        // builder.Navigation(d => d.Name).();
    }
}