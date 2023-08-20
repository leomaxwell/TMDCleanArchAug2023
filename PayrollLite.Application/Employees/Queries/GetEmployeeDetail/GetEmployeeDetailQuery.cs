using PayrollLite.Application.Employees.Queries.GetEmployees;

namespace PayrollLite.Application.Employees.Queries.GetEmployeeDetail;

public class GetEmployeeDetailQuery : IRequest<EmployeeDto>
{
    public int Id { get; set; }
}

public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.Employees
                                .Where(m => m.Id == request.Id)
                                .Include(m => m.GenderType)
                                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync();
       
        return dto;
    }
}
