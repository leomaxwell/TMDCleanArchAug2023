using PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

namespace PayrollLite.Application.MonthsOfYear.Queries.GetMonthOfYearDetail;

public class GetMonthOfYearDetailQuery : IRequest<MonthOfYearDto>
{
    public int Id { get; set; }
}

public class GetMonthOfYearDetailQueryHandler : IRequestHandler<GetMonthOfYearDetailQuery, MonthOfYearDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMonthOfYearDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MonthOfYearDto> Handle(GetMonthOfYearDetailQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.MonthsOfYear
                                .Where(m => m.Id == request.Id)
                                .ProjectTo<MonthOfYearDto>(_mapper.ConfigurationProvider)
                                .SingleOrDefaultAsync();
        return dto;
    }
}
