namespace PayrollLite.Application.Employees.Queries.GetEmployees;

public class GetEmployeesQuery : IRequest<EmployeesVm> { }

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeesVm> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var vm = new EmployeesVm()
        {
            Employees = await _context.Employees.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).ToListAsync()
        };
       
        return vm;
    }
}
