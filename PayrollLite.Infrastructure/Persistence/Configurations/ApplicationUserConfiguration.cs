namespace PayrollLite.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(m => m.Name)
           .IsRequired()
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
