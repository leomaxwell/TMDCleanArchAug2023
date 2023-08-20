namespace PayrollLite.Application.MonthsOfYear.Commands.UpdateMonthOfYear;

internal class UpdateMonthOfYearCommandValidator : AbstractValidator<UpdateMonthOfYearCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMonthOfYearCommandValidator(IApplicationDbContext context)
    {
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

        _context = context;
    }

    public async Task<bool> BeUniqueName(UpdateMonthOfYearCommand command, string name, CancellationToken cancellationToken)
    {
        
        var model = await _context.MonthsOfYear
                                .Where(m => m.Name.ToLower() == name.ToLower())
                                .SingleOrDefaultAsync();

        return (model == null) || (model.Id == command.Id);
    }

    public async Task<bool> BeUniqueAbbreviation(UpdateMonthOfYearCommand command, string abbreviation, CancellationToken cancellationToken)
    {

        var model = await _context.MonthsOfYear
                                .Where(m => m.Abbreviation.ToLower() == abbreviation.ToLower())
                                .SingleOrDefaultAsync();

        return (model == null) || (model.Id == command.Id);
    }

    public async Task<bool> BeUniqueNumber(UpdateMonthOfYearCommand command, string number, CancellationToken cancellationToken)
    {

        var model = await _context.MonthsOfYear
                                .Where(m => m.Number.ToLower() == number.ToLower())
                                .SingleOrDefaultAsync();

        return (model == null) || (model.Id == command.Id);
    }
}
