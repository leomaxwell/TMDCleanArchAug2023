namespace PayrollLite.Domain.Common;

public class ReferenceBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? DateLastModified { get; set; }
}
