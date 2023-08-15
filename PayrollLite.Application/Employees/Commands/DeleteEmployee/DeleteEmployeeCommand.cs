namespace PayrollLite.Application.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Employees.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        _context.Employees.Remove(model);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
