namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(m => m.FirstName)
             .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.MiddleName)
            .HasMaxLength(50);

        builder.Property(m => m.LastName)
             .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.BirthDate)
            .IsRequired();

        builder.Property(m => m.EmailAddress)
            .HasMaxLength(50);

        builder.Property(m => m.PhoneNo)
            .HasMaxLength(50);

        builder.Property(m => m.JobTitle)
            .IsRequired()
           .HasMaxLength(50);

        builder.Property(m => m.GrossSalary)
            .IsRequired()
            .HasColumnType(SqlDataType.Decimal104);

        //Auditable Properties
        builder.Property(m => m.RecordedBy)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(m => m.DateRecorded)
            .IsRequired();

        builder.Property(m => m.LastModifiedBy)
            .IsRequired(false)
            .HasMaxLength(150);

        builder.Property(m => m.DateLastModified)
            .IsRequired(false);

        //Relationship
        builder.HasOne(m => m.GenderType)
           .WithMany(m => m.Employees)
           .HasForeignKey(m => m.GenderId)
           .OnDelete(DeleteBehavior.NoAction);
    }
}
