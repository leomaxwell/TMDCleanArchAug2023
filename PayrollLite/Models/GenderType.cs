namespace PayrollLite.Models;

public class GenderType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime DateLastModified { get; set; }

    //Navigation Properties
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
