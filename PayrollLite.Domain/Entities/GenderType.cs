namespace PayrollLite.Domain.Entities;

public class GenderType : ReferenceBaseEntity
{
    //Navigation Properties
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
