namespace PayrollLite.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int GenderId { get; set; }
    public DateTime BirthDate { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNo { get; set; }
    public string JobTitle { get; set; }
    public decimal GrossSalary { get; set; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var model = new Employee()
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            GenderId = request.GenderId,
            BirthDate = request.BirthDate,
            EmailAddress = request.EmailAddress,
            PhoneNo = request.PhoneNo,
            JobTitle = request.JobTitle,
            GrossSalary = request.GrossSalary,
            RecordedBy = "System",
            DateRecorded = DateTime.Now
        };

        _context.Employees.Add(model);
        await _context.SaveChangesAsync(new CancellationToken());

        return model.Id;
    }
}
