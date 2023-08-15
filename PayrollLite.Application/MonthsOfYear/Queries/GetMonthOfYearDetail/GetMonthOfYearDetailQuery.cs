using PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

namespace PayrollLite.Application.MonthsOfYear.Queries.GetMonthOfYearDetail;

public class GetMonthOfYearDetailQuery : IRequest<MonthOfYearDto>
{
    public int Id { get; set; }
}

public class GetMonthOfYearDetailQueryHandler : IRequestHandler<GetMonthOfYearDetailQuery, MonthOfYearDto>
{
    private readonly IApplicationDbContext _context;

    public GetMonthOfYearDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MonthOfYearDto> Handle(GetMonthOfYearDetailQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.MonthsOfYear.FindAsync(request.Id);

        var dto = new MonthOfYearDto()
        {
            Id = model.Id,
            Name = model.Name,
            Abbreviation = model.Abbreviation,
            Number = model.Number,
        };

        return dto;
    }
}
