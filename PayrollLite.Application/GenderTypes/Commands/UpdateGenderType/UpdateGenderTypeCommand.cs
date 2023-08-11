namespace PayrollLite.Application.GenderTypes.Commands.UpdateGenderType;

public class UpdateGenderTypeCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateGenderTypeCommandHandler : IRequestHandler<UpdateGenderTypeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateGenderTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateGenderTypeCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.GenderTypes.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        model.Name = request.Name;
        model.Description = request.Description;
        model.LastModifiedBy = "System";
        model.DateLastModified = DateTime.UtcNow;


        _context.GenderTypes.Update(model);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
