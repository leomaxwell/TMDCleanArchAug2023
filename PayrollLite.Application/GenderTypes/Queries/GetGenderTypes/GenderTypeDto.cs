namespace PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

public class GenderTypeDto : IMapFrom<GenderType>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
