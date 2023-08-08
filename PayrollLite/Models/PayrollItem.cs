namespace PayrollLite.Models;

public class PayrollItem
{
    public int Id { get; set; }
    public int PayrollId { get; set; }
    public int EmployeeId { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal IncomeTax { get; set; }
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime DateLastModified { get; set; }

    //Navigation Properties
    public virtual Payroll Payroll { get; set; }
    public virtual Employee Employee { get; set; }
}
