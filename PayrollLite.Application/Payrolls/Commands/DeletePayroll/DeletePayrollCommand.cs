namespace PayrollLite.Application.Payrolls.Commands.DeletePayroll;

public class DeletePayrollCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeletePayrollCommandHandler : IRequestHandler<DeletePayrollCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePayrollCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePayrollCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Payrolls.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        _context.Payrolls.Remove(model);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
