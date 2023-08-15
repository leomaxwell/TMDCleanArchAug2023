using PayrollLite.Application.Employees.Queries.GetEmployees;

namespace PayrollLite.Application.Employees.Queries.GetEmployeeDetail;

public class GetEmployeeDetailQuery : IRequest<EmployeeDto>
{
    public int Id { get; set; }
}

public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDto>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeeDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Employees.FindAsync(request.Id);

        var dto = new EmployeeDto()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            MiddleName = model.MiddleName,
            LastName = model.LastName,
            GenderId = model.GenderId,
            BirthDate = model.BirthDate,
            EmailAddress = model.EmailAddress,
            PhoneNo = model.PhoneNo,
            JobTitle = model.JobTitle,
            GrossSalary = model.GrossSalary,
            GenderType = model.GenderType
        };

        return dto;
    }
}
