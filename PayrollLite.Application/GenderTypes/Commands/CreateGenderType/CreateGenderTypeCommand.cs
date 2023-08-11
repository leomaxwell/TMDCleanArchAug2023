namespace PayrollLite.Application.GenderTypes.Commands.CreateGenderType;

public class CreateGenderTypeCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class CreateGenderTypeCommandHandler : IRequestHandler<CreateGenderTypeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGenderTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGenderTypeCommand request, CancellationToken cancellationToken)
    {
        var model = new GenderType()
        {
            Name = request.Name,
            Description = request.Description,
            RecordedBy = "System",
            DateRecorded = DateTime.Now
        };

        _context.GenderTypes.Add(model);
        await _context.SaveChangesAsync(new CancellationToken());

        return model.Id;       
    }
}
