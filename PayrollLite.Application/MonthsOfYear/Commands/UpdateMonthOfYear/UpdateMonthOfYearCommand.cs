namespace PayrollLite.Application.MonthsOfYear.Commands.UpdateMonthOfYear;

public class UpdateMonthOfYearCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Number { get; set; }
}

public class UpdateMonthOfYearCommandHandler : IRequestHandler<UpdateMonthOfYearCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateMonthOfYearCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateMonthOfYearCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.MonthsOfYear.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        model.Name = request.Name;
        model.Abbreviation = request.Abbreviation;
        model.Number = request.Number;
        model.LastModifiedBy = "System";
        model.DateLastModified = DateTime.UtcNow;


        _context.MonthsOfYear.Update(model);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
