using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollLite.Models;

public class PayrollItem
{
    public int Id { get; set; }
    public int PayrollId { get; set; }
    public int EmployeeId { get; set; }

    [Column(TypeName = "Decimal(19,2)")]
    public decimal GrossSalary { get; set; }

    [Column(TypeName = "Decimal(19,2)")]
    public decimal IncomeTax { get; set; }

    [Required]
    [MaxLength(150)]
    public string RecordedBy { get; set; }

    [Required]
    public DateTime DateRecorded { get; set; }

    [MaxLength(150)]
    public string LastModifiedBy { get; set; }

    public DateTime? DateLastModified { get; set; }

    //Navigation Properties
    public virtual Payroll Payroll { get; set; }
    public virtual Employee Employee { get; set; }
}
