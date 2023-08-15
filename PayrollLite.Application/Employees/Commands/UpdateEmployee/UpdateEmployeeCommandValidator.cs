namespace PayrollLite.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandValidator(IApplicationDbContext context)
    {
        RuleFor(m => m.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.MiddleName).MaximumLength(50);

        RuleFor(m => m.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(m => m.GenderId)
            .NotEmpty().WithMessage("Gender value is required.");

        RuleFor(m => m.BirthDate)
            .NotEmpty().WithMessage("Birthdate value is required.")
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Date of birth must be in the past.");

        RuleFor(m => m.EmailAddress)
            .MaximumLength(150)
            .EmailAddress().WithMessage("Email address provided is invalid.")
            .MustAsync(BeUniqueEmailAddress).WithMessage("Email address provided already exists.");

        RuleFor(m => m.PhoneNo)
            .MaximumLength(20)
            .MustAsync(BeUniquePhoneNo).WithMessage("Phone no. provided already exists. Please provide a different no.");

        RuleFor(m => m.JobTitle)
            .NotEmpty().WithMessage("Job Title is required.")
            .MaximumLength(50);

        RuleFor(m => m.GrossSalary)
            .GreaterThan(0).WithMessage("Gross salary must be greater than 0.")
            .NotEmpty().WithMessage("Gross Salary is required.");

        _context = context;
    }

    public async Task<bool> BeUniqueEmailAddress(UpdateEmployeeCommand command, string emailAddress, CancellationToken cancellationToken)
    {
        
        var model = await _context.Employees
                                .Where(m => m.EmailAddress.ToLower() == emailAddress.ToLower())
                                .SingleOrDefaultAsync();

        return (model == null) || (model.Id == command.Id);
    }

    public async Task<bool> BeUniquePhoneNo(UpdateEmployeeCommand command, string phoneNo, CancellationToken cancellationToken)
    {

        var model = await _context.Employees
                                .Where(m => m.PhoneNo.ToLower() == phoneNo.ToLower())
                                .SingleOrDefaultAsync();

        return (model == null) || (model.Id == command.Id);
    }
}
