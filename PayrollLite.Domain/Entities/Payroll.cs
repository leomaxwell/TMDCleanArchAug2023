namespace PayrollLite.Domain.Entities;

public class Payroll : BaseEntity
{
    public int Id { get; set; }
    public int MonthId { get; set; }
    public int Year { get; set; }
    public decimal ExchangeRate { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }

    //Navigation Properties
    public virtual MonthOfYear MonthOfYear { get; set; }
    public virtual PayrollStatusType PayrollStatusType { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();
}
