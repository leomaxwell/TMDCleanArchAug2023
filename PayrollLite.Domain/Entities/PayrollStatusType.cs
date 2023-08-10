namespace PayrollLite.Domain.Entities;

public class PayrollStatusType : ReferenceBaseEntity
{
    //Navigation Properties
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
