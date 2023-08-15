namespace PayrollLite.Application.PayrollStatusTypes.Commands.UpdatePayrollStatusType;

public class UpdatePayrollStatusTypeCommandValidator : AbstractValidator<UpdatePayrollStatusTypeCommand>
{
    public UpdatePayrollStatusTypeCommandValidator()
    {
        RuleFor(m => m.Description)
            .MaximumLength(150).WithMessage("Name must be up to 150 characters.");
    }
}
