namespace PayrollLite.Application.Payrolls.Commands.CreatePayroll;

public class CreatePayrollCommandValidator : AbstractValidator<CreatePayrollCommand>
{
    private readonly IApplicationDbContext _context;

    public CreatePayrollCommandValidator(IApplicationDbContext context)
    {
        RuleFor(m => m.MonthId)
            .NotEmpty().WithMessage("Month is required.")
            .MustAsync(BeUniquePayroll).WithMessage("A payroll for the selected month already exist."); 
        
        
        RuleFor(m =>m.Description)
            .MaximumLength(150).WithMessage("Name must be up to 150 characters.");
        _context = context;
    }

    public async Task<bool> BeUniquePayroll(int monthId, CancellationToken cancellationToken)
    {
        var model = await _context.Payrolls
                            .Where(m => m.MonthId == monthId && m.Year == DateTime.Today.Year)
                            .FirstOrDefaultAsync();

        return (model == null);
    }
}
