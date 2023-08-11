namespace PayrollLite.Application.Common.Interfaces.DbContexts;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; set; }
    DbSet<GenderType> GenderTypes { get; set; }
    DbSet<MonthOfYear> MonthsOfYear { get; set; }
    DbSet<Payroll> Payrolls { get; set; }
    DbSet<PayrollItem> PayrollItems { get; set; }
    DbSet<PayrollStatusType> PayrollStatusTypes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
