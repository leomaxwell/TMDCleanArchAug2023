namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class PayrollItemConfiguration : IEntityTypeConfiguration<PayrollItem>
{
    public void Configure(EntityTypeBuilder<PayrollItem> builder)
    {
        builder.Property(m => m.GrossSalary)
             .IsRequired()
             .HasColumnType(SqlDataType.Decimal104);

        builder.Property(m => m.IncomeTax)
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
        builder.HasOne(m => m.Payroll)
            .WithMany(m => m.PayrollItems)
            .HasForeignKey(m => m.PayrollId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.Employee)
           .WithMany(m => m.PayrollItems)
           .HasForeignKey(m => m.EmployeeId)
           .OnDelete(DeleteBehavior.NoAction);
    }
}
