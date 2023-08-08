using System.ComponentModel.DataAnnotations;

namespace PayrollLite.Models;

public class GenderType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(150)]
    public string Description { get; set; }

    [Required]
    [MaxLength(150)]
    public string RecordedBy { get; set; }

    [Required]
    public DateTime DateRecorded { get; set; }

    [MaxLength(150)]
    public string LastModifiedBy { get; set; }
    
    public DateTime? DateLastModified { get; set; }

    //Navigation Properties
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
