namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
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
