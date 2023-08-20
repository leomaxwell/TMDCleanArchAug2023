namespace PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

public class GetMonthsOfYearQuery : IRequest<MonthsOfYearVm> { }

internal class GetMonthsOfYearQueryHandler : IRequestHandler<GetMonthsOfYearQuery, MonthsOfYearVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMonthsOfYearQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MonthsOfYearVm> Handle(GetMonthsOfYearQuery request, CancellationToken cancellationToken)
    {
        var vm = new MonthsOfYearVm()
        {
            MonthsOfYear = await _context.MonthsOfYear.ProjectTo<MonthOfYearDto>(_mapper.ConfigurationProvider).ToListAsync()
        };
        
        return vm;
    }
}
