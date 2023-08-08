namespace PayrollLite.Models;

public class PayrollStatusType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime DateLastModified { get; set; }

    //Navigation Properties
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
