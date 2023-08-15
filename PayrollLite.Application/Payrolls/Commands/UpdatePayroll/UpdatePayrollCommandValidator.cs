namespace PayrollLite.Application.Payrolls.Commands.UpdatePayroll;

public class UpdatePayrollCommandValidator : AbstractValidator<UpdatePayrollCommand>
{
    public UpdatePayrollCommandValidator()
    {
        RuleFor(m => m.ExchangeRate)
           .GreaterThan(0).WithMessage("USD->LRD Exchange rate must be greater than 0.")
           .NotEmpty().WithMessage("USD->LRD Exchange is required.");

        RuleFor(m => m.Description)
            .MaximumLength(150).WithMessage("Name must be up to 150 characters.");
    }
}
