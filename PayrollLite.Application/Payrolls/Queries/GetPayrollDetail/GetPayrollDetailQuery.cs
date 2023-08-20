using PayrollLite.Application.Payrolls.Queries.GetPayrolls;

namespace PayrollLite.Application.Payrolls.Queries.GetPayrollDetail;

public class GetPayrollDetailQuery : IRequest<PayrollDto>
{
    public int Id { get; set; }
}

public class GetPayrollDetailQueryHandler : IRequestHandler<GetPayrollDetailQuery, PayrollDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPayrollDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PayrollDto> Handle(GetPayrollDetailQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.Payrolls.Where(m => m.Id == request.Id)
                                        .ProjectTo<PayrollDto>(_mapper.ConfigurationProvider)
                                        .SingleOrDefaultAsync();

        return dto;
    }
}
