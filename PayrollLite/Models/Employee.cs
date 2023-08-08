namespace PayrollLite.Models;

public class Employee
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
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime DateLastModified { get; set; }

    //Navigation Properties
    public virtual GenderType GenderType { get; set; }
}
