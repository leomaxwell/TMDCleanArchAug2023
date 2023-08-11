namespace PayrollLite.Application.GenderTypes.Commands.DeleteGenderType;

public class DeleteGenderTypeCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteGenderTypeCommandHandler : IRequestHandler<DeleteGenderTypeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteGenderTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteGenderTypeCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.GenderTypes.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        _context.GenderTypes.Remove(model);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
