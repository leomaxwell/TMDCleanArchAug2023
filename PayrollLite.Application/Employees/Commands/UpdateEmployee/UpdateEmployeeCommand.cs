namespace PayrollLite.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
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

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Employees.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        model.FirstName = request.FirstName;
        model.MiddleName = request.MiddleName;
        model.LastName = request.LastName;
        model.GenderId = request.GenderId;
        model.BirthDate = request.BirthDate;
        model.EmailAddress = request.EmailAddress;
        model.PhoneNo = request.PhoneNo;
        model.JobTitle = request.JobTitle;
        model.GrossSalary = request.GrossSalary;
        
        model.LastModifiedBy = "System";
        model.DateLastModified = DateTime.UtcNow;


        _context.Employees.Update(model);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
