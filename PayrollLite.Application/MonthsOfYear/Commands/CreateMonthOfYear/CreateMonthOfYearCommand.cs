namespace PayrollLite.Application.MonthsOfYear.Commands.CreateMonthOfYear;

public class CreateMonthOfYearCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Number { get; set; }
}

public class CreateMonthOfYearCommandHandler : IRequestHandler<CreateMonthOfYearCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMonthOfYearCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMonthOfYearCommand request, CancellationToken cancellationToken)
    {
        var model = new MonthOfYear()
        {
            Name = request.Name,
            Abbreviation = request.Abbreviation,
            Number = request.Number,
            RecordedBy = "System",
            DateRecorded = DateTime.Now
        };

        _context.MonthsOfYear.Add(model);
        await _context.SaveChangesAsync(new CancellationToken());

        return model.Id;       
    }
}
