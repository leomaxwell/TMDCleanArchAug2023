namespace PayrollLite.Application.MonthsOfYear.Commands.DeleteMonthOfYear;

public class DeleteMonthOfYearCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteMonthOfYearCommandHandler : IRequestHandler<DeleteMonthOfYearCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteMonthOfYearCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMonthOfYearCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.MonthsOfYear.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        _context.MonthsOfYear.Remove(model);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
