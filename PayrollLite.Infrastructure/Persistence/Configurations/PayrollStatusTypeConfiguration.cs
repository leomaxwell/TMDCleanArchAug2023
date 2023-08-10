namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class PayrollStatusTypeConfiguration : IEntityTypeConfiguration<PayrollStatusType>
{
    public void Configure(EntityTypeBuilder<PayrollStatusType> builder)
    {
        builder.Property(m => m.Name)
             .IsRequired()
             .HasMaxLength(50);

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
    }
}