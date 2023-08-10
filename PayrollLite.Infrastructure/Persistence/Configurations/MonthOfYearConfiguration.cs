namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class MonthOfYearConfiguration : IEntityTypeConfiguration<MonthOfYear>
{
    public void Configure(EntityTypeBuilder<MonthOfYear> builder)
    {
        builder.Property(m => m.Name)
             .IsRequired()
             .HasMaxLength(50);

        builder.Property(m => m.Abbreviation)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(m => m.Number)
            .IsRequired()
            .HasMaxLength(2);

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
    }
}

