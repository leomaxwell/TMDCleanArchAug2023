namespace PayrollLite.Application.Payrolls.Queries.GetPayrolls;

public class GetPayrollsQuery : IRequest<PayrollsVm> { }

public class GetPayrollsQueryHandler : IRequestHandler<GetPayrollsQuery, PayrollsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPayrollsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PayrollsVm> Handle(GetPayrollsQuery request, CancellationToken cancellationToken)
    {
        var vm = new PayrollsVm()
        {
            Payrolls = await _context.Payrolls
                                    .ProjectTo<PayrollDto>(_mapper.ConfigurationProvider)
                                    .ToListAsync()

        };

        return vm;
    }
}
