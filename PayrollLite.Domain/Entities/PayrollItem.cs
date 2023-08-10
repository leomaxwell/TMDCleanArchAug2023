namespace PayrollLite.Domain.Entities;

public class PayrollItem : BaseEntity
{
    public int Id { get; set; }
    public int PayrollId { get; set; }
    public int EmployeeId { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal IncomeTax { get; set; }

    //Navigation Properties
    public virtual Payroll Payroll { get; set; }
    public virtual Employee Employee { get; set; }
}
