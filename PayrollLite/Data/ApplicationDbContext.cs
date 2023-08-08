﻿namespace PayrollLite.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<GenderType> GenderTypes { get; set; }
    public DbSet<MonthOfYear> MonthsOfYear { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<PayrollItem> PayrollItems { get; set; }
    public DbSet<PayrollStatusType> PayrollStatusTypes { get; set; }
}
