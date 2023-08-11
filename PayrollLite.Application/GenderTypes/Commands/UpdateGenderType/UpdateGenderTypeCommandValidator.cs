namespace PayrollLite.Application.GenderTypes.Commands.UpdateGenderType;

public class UpdateGenderTypeCommandValidator : AbstractValidator<UpdateGenderTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateGenderTypeCommandValidator(IApplicationDbContext context)
    {
        RuleFor(m => m.Name)
            .NotEmpty().WithMessage("Name value is required, please....")
            .MinimumLength(3).WithMessage("Name must be 3 or more characters.")
            .MaximumLength(50).WithMessage("Name must be up to 50 characters.")
            .MustAsync(BeUniqueName).WithMessage("The name provided already exists in the system");

        RuleFor(m => m.Description)
            .MaximumLength(150).WithMessage("Name must be up to 150 characters.");
        _context = context;
    }

    public async Task<bool> BeUniqueName(UpdateGenderTypeCommand command, string name, CancellationToken cancellationToken)
    {
        
        var model = await _context.GenderTypes
                                .Where(m => m.Name.ToLower() == name.ToLower())
                                .SingleOrDefaultAsync();

        return (model == null) || (model.Id == command.Id);
    }
}
