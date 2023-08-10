namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
{
    public void Configure(EntityTypeBuilder<Payroll> builder)
    {
        builder.Property(m => m.ExchangeRate)
             .IsRequired()
             .HasColumnType(SqlDataType.Decimal104);

        builder.Property(m => m.Description)
            .HasMaxLength(150);

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
        builder.HasOne(m => m.MonthOfYear)
           .WithMany(m => m.Payrolls)
           .HasForeignKey(m => m.MonthId)
           .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.PayrollStatusType)
            .WithMany(m => m.Payrolls)
            .HasForeignKey(m => m.StatusId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
