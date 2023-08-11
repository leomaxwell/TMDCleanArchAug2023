namespace PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

public class GetGenderTypesQuery : IRequest<GenderTypesVm> { }

public class GetGenderTypesQueryHandler : IRequestHandler<GetGenderTypesQuery, GenderTypesVm>
{
    private readonly IApplicationDbContext _context;

    public GetGenderTypesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GenderTypesVm> Handle(GetGenderTypesQuery request, CancellationToken cancellationToken)
    {
        var genderTypes = new List<GenderTypeDto>();

        var models = await _context.GenderTypes.ToListAsync();



        foreach (var item in models)
        {
            var dto = new GenderTypeDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            genderTypes.Add(dto);
        }

        var vm = new GenderTypesVm() { GenderTypes = genderTypes };
        return vm;
    }
}
