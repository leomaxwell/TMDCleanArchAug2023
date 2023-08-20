namespace PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypes;

public class GetPayrollStatusTypesQuery : IRequest<PayrollStatusTypesVm> { }

public class GetPayrollStatusTypesQueryHandler : IRequestHandler<GetPayrollStatusTypesQuery, PayrollStatusTypesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPayrollStatusTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PayrollStatusTypesVm> Handle(GetPayrollStatusTypesQuery request, CancellationToken cancellationToken)
    {
        var vm = new PayrollStatusTypesVm
        {
            PayrollStatusTypes = await _context.PayrollStatusTypes
                                            .ProjectTo<PayrollStatusTypeDto>(_mapper.ConfigurationProvider)
                                            .ToListAsync()
        };
       
        return vm;
    }
}
