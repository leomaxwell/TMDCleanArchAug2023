namespace PayrollLite.Application.MonthsOfYear.Commands.CreateMonthOfYear;

public class CreateMonthOfYearCommandValidator : AbstractValidator<CreateMonthOfYearCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMonthOfYearCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(m => m.Name)
           .NotEmpty().WithMessage("Name value is required, please....")
           .MinimumLength(3).WithMessage("Name must be 3 or more characters.")
           .MaximumLength(50).WithMessage("Name must be up to 50 characters.")
           .MustAsync(BeUniqueName).WithMessage("The name provided already exists in the system");

        RuleFor(m => m.Abbreviation)
            .NotEmpty()
            .MaximumLength(3)
            .MustAsync(BeUniqueAbbreviation).WithMessage("The abbreviation provided already exists in the system");

        RuleFor(m => m.Number)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(2)
            .MustAsync(BeUniqueNumber).WithMessage("The number provided already exists in the system");
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.MonthsOfYear.AllAsync(m => m.Name != name);
    }

    public async Task<bool> BeUniqueAbbreviation(string abbreviation, CancellationToken cancellationToken)
    {
        return await _context.MonthsOfYear.AllAsync(m => m.Abbreviation != abbreviation);
    }

    public async Task<bool> BeUniqueNumber(string number, CancellationToken cancellationToken)
    {
        return await _context.MonthsOfYear.AllAsync(m => m.Number != number);
    }
}
