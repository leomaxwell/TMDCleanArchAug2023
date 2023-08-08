using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollLite.Models;

public class Payroll
{
    public int Id { get; set; }
    public int MonthId { get; set; }
    public int Year { get; set; }

    [Column("Decimal(19,2)")]
    public decimal ExchangeRate { get; set; }

    [MaxLength(150)]
    public string Description { get; set; }
    public int StatusId { get; set; }

    [Required]
    [MaxLength(150)]
    public string RecordedBy { get; set; }

    [Required]
    public DateTime DateRecorded { get; set; }

    [MaxLength(150)]
    public string LastModifiedBy { get; set; }

    public DateTime? DateLastModified { get; set; }

    //Navigation Properties
    public virtual MonthOfYear MonthOfYear { get; set; }
    public virtual PayrollStatusType PayrollStatusType { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();
}
