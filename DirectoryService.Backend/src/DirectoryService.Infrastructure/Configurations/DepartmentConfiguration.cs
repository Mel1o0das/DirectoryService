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

        builder.OwnsOne(d => d.Identifier, db =>
        {
            db.Property(i => i.Value)
                .IsRequired()
                .HasMaxLength(Constants.Text.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("department_identifier");
        });
        
        builder.Property(d => d.ParentId)
            .IsRequired(false)
            .HasConversion(
                id => id!.Value,
                value => DepartmentId.Create(value))
            .HasColumnName("parent_id");

        builder.ComplexProperty(d => d.Path, db =>
        {
            db.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("department_path");
        });

        builder.Property(d => d.Depth)
            .IsRequired()
            .HasColumnName("department_depth");
        
        builder.Property(d => d.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("is_active");
        
        builder.Property(d => d.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(d => d.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");

        builder.HasMany(d => d.Locations)
            .WithOne()
            .HasForeignKey(dl => dl.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(d => d.Positions)
            .WithOne()
            .HasForeignKey(dp => dp.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}