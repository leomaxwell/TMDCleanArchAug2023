namespace PayrollLite.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }

    //Auditable properties
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? DateLastModified { get; set; }
}
