namespace PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

public class GetGenderTypesQuery : IRequest<GenderTypesVm> { }

public class GetGenderTypesQueryHandler : IRequestHandler<GetGenderTypesQuery, GenderTypesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenderTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenderTypesVm> Handle(GetGenderTypesQuery request, CancellationToken cancellationToken)
    {
        var vm = new GenderTypesVm()
        {
            GenderTypes = await _context.GenderTypes.ProjectTo<GenderTypeDto>(_mapper.ConfigurationProvider).ToListAsync()
        };
        
        return vm;
    }
}
