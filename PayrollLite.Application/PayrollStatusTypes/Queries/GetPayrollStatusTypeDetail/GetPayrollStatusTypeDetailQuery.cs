using PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypes;

namespace PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypeDetail;

public class GetPayrollStatusTypeDetailQuery : IRequest<PayrollStatusTypeDto>
{
    public int Id { get; set; }
}

internal class GetPayrollStatusTypeDetailQueryHandler : IRequestHandler<GetPayrollStatusTypeDetailQuery, PayrollStatusTypeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPayrollStatusTypeDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PayrollStatusTypeDto> Handle(GetPayrollStatusTypeDetailQuery request, CancellationToken cancellationToken)
    {
        return await _context.PayrollStatusTypes
                            .Where(m => m.Id == request.Id)
                            .ProjectTo<PayrollStatusTypeDto>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();

    }
}
