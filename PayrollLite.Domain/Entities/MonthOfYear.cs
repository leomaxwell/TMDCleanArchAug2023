namespace PayrollLite.Domain.Entities;

public class MonthOfYear : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Number { get; set; }

    //Navigation Properties
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
