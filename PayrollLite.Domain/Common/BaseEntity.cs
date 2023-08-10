namespace PayrollLite.Domain.Common;

public class BaseEntity
{
    public string RecordedBy { get; set; }
    public DateTime DateRecorded { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? DateLastModified { get; set; }
}
