using System.ComponentModel.DataAnnotations;

namespace PayrollLite.Models;

public class GenderType
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="This field is required.")]
    [MaxLength(50, ErrorMessage ="Name must be less than 50 characters")]
    public string Name { get; set; }

    [MaxLength(150, ErrorMessage = "Name must be less than 150 characters")]
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
