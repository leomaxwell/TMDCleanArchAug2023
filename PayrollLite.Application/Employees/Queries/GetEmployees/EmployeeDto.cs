using PayrollLite.Application.Common.Helpers;

namespace PayrollLite.Application.Employees.Queries.GetEmployees;

public class EmployeeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int GenderId { get; set; }
    public DateTime BirthDate { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNo { get; set; }
    public string JobTitle { get; set; }
    public decimal GrossSalary { get; set; }
        
    public string FullName => $"{FirstName} {MiddleName} {LastName}";
        
    public int Age => AppMethods.GetAgeFromDate(BirthDate);

    //Navigation Properties
    public virtual GenderType GenderType { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();
}
