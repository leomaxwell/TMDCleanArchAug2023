namespace PayrollLite.Application.GenderTypes.Commands.CreateGenderType;

public class CreateGenderTypeCommandValidator : AbstractValidator<CreateGenderTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateGenderTypeCommandValidator(IApplicationDbContext context)
    {
        RuleFor(m => m.Name)
            .NotEmpty().WithMessage("Name value is required, please....")
            .MinimumLength(3).WithMessage("Name must be 3 or more characters.")
            .MaximumLength(50).WithMessage("Name must be up to 50 characters.")
            .MustAsync(BeUniqueName).WithMessage("The name provided already exists in the system"); 
        
        
        RuleFor(m =>m.Description)
            .MaximumLength(150).WithMessage("Name must be up to 150 characters.");
        _context = context;
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.GenderTypes.AllAsync(m => m.Name != name);
    }
}
