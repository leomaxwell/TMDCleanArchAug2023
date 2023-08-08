using System.ComponentModel.DataAnnotations;

namespace PayrollLite.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    public int GenderId{ get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [MaxLength (50)]
    public string EmailAddress { get; set; }

    [MaxLength(20)]
    public string PhoneNo { get; set; }

    [Required]
    [MaxLength(50)]
    public string JobTitle { get; set; }

    [Required]
    public decimal GrossSalary { get; set; }

    [Required]
    [MaxLength(150)]
    public string RecordedBy { get; set; }

    [Required]
    public DateTime DateRecorded { get; set; }

    [MaxLength(150)]
    public string LastModifiedBy { get; set; }

    public DateTime? DateLastModified { get; set; }

    //Navigation Properties
    public virtual GenderType GenderType { get; set; }
}
