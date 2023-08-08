using System.ComponentModel.DataAnnotations;

namespace PayrollLite.Models;

public class MonthOfYear
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(3)]
    public string Abbreviation { get; set; }

    [Required]
    [MaxLength(2)]
    public string Number { get; set; }

    [Required]
    [MaxLength(150)]
    public string RecordedBy { get; set; }

    [Required]
    public DateTime DateRecorded { get; set; }

    [MaxLength(150)]
    public string LastModifiedBy { get; set; }

    public DateTime? DateLastModified { get; set; }

    //Navigation Properties
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
