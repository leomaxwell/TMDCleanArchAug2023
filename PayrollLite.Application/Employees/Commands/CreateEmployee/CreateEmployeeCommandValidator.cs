namespace PayrollLite.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandValidator(IApplicationDbContext context)
    {
        _context = context;

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
            .NotEmpty().WithMessage("Gross Salary is required.");
    }

    public async Task<bool> BeUniqueEmailAddress(string emailAddress, CancellationToken cancellationToken)
    {
        return await _context.Employees.AllAsync(m => m.EmailAddress != emailAddress);
    }

    public async Task<bool> BeUniquePhoneNo(string phoneNo, CancellationToken cancellationToken)
    {
        return await _context.Employees.AllAsync(m => m.PhoneNo != phoneNo);
    }
}
