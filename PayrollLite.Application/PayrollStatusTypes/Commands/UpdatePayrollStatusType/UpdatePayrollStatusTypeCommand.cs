namespace PayrollLite.Application.PayrollStatusTypes.Commands.UpdatePayrollStatusType;

public class UpdatePayrollStatusTypeCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Description { get; set; }
}

public class UpdatePayrollStatusTypeCommandHandler : IRequestHandler<UpdatePayrollStatusTypeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePayrollStatusTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePayrollStatusTypeCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.PayrollStatusTypes.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        model.Description = request.Description;
        model.LastModifiedBy = "System";
        model.DateLastModified = DateTime.UtcNow;


        _context.PayrollStatusTypes.Update(model);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
