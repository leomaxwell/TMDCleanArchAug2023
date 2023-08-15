namespace PayrollLite.Application.Employees.Queries.GetEmployees;

public class GetEmployeesQuery : IRequest<EmployeesVm> { }

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeesVm>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeesVm> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var Employees = new List<EmployeeDto>();

        var models = await _context.Employees.ToListAsync();



        foreach (var item in models)
        {
            var dto = new EmployeeDto()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                GenderId = item.GenderId,
                BirthDate = item.BirthDate,
                EmailAddress = item.EmailAddress,
                PhoneNo = item.PhoneNo,
                JobTitle = item.JobTitle,
                GrossSalary = item.GrossSalary,
                GenderType = item.GenderType
            };

            Employees.Add(dto);
        }

        var vm = new EmployeesVm() { Employees = Employees };
        return vm;
    }
}
