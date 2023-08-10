namespace PayrollLite.Domain.Entities;

public class Employee : BaseEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int GenderId{ get; set; }
    public DateTime BirthDate { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNo { get; set; }
    public string JobTitle { get; set; }
    public decimal GrossSalary { get; set; }

    //Navigation Properties
    public virtual GenderType GenderType { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();
}
