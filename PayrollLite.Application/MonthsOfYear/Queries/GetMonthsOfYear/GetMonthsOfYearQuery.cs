namespace PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

public class GetMonthsOfYearQuery : IRequest<MonthsOfYearVm> { }

public class GetMonthsOfYearQueryHandler : IRequestHandler<GetMonthsOfYearQuery, MonthsOfYearVm>
{
    private readonly IApplicationDbContext _context;

    public GetMonthsOfYearQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MonthsOfYearVm> Handle(GetMonthsOfYearQuery request, CancellationToken cancellationToken)
    {
        var MonthsOfYear = new List<MonthOfYearDto>();

        var models = await _context.MonthsOfYear.ToListAsync();



        foreach (var item in models)
        {
            var dto = new MonthOfYearDto()
            {
                Id = item.Id,
                Name = item.Name,
                Abbreviation = item.Abbreviation,
                Number = item.Number
            };

            MonthsOfYear.Add(dto);
        }

        var vm = new MonthsOfYearVm() { MonthsOfYear = MonthsOfYear };
        return vm;
    }
}
