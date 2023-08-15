using PayrollLite.Application.Payrolls.Queries.GetPayrolls;

namespace PayrollLite.Application.Payrolls.Queries.GetPayrollDetail;

public class GetPayrollDetailQuery : IRequest<PayrollDto>
{
    public int Id { get; set; }
}

public class GetPayrollDetailQueryHandler : IRequestHandler<GetPayrollDetailQuery, PayrollDto>
{
    private readonly IApplicationDbContext _context;

    public GetPayrollDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PayrollDto> Handle(GetPayrollDetailQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Payrolls.FindAsync(request.Id);

        var dto = new PayrollDto()
        {
            Id = model.Id,
            MonthId = model.MonthId,
            Year = model.Year,
            ExchangeRate = model.ExchangeRate,
            Description = model.Description,
            StatusId = model.StatusId,
            PayrollStatusType = model.PayrollStatusType,
            MonthOfYear = model.MonthOfYear,
            PayrollItems = model.PayrollItems,
        };

        return dto;
    }
}
