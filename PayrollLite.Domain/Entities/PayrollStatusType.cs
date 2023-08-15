namespace PayrollLite.Domain.Entities;

public class PayrollStatusType : ReferenceBaseEntity
{
    public int EnumKey { get; set; }

    //Navigation Properties
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
