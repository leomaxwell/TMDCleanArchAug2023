using PayrollLite.Infrastructure.Identity.Models;

namespace PayrollLite.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<GenderType> GenderTypes { get; set; }
    public DbSet<MonthOfYear> MonthsOfYear { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<PayrollItem> PayrollItems { get; set; }
    public DbSet<PayrollStatusType> PayrollStatusTypes { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<ApplicationRole> ApplicationRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
