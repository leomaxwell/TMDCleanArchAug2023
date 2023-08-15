namespace PayrollLite.Application.Payrolls.Queries.GetPayrolls;

public class GetPayrollsQuery : IRequest<PayrollsVm> { }

public class GetPayrollsQueryHandler : IRequestHandler<GetPayrollsQuery, PayrollsVm>
{
    private readonly IApplicationDbContext _context;

    public GetPayrollsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PayrollsVm> Handle(GetPayrollsQuery request, CancellationToken cancellationToken)
    {
        var Payrolls = new List<PayrollDto>();

        var models = await _context.Payrolls.ToListAsync();



        foreach (var item in models)
        {
            var dto = new PayrollDto()
            {
                Id = item.Id,
                MonthId = item.MonthId,
                Year = item.Year,
                ExchangeRate = item.ExchangeRate,
                Description = item.Description,
                StatusId = item.StatusId,
                PayrollStatusType = item.PayrollStatusType,
                MonthOfYear = item.MonthOfYear,
                PayrollItems = item.PayrollItems,
            };

            Payrolls.Add(dto);
        }

        var vm = new PayrollsVm() { Payrolls = Payrolls };
        return vm;
    }
}
