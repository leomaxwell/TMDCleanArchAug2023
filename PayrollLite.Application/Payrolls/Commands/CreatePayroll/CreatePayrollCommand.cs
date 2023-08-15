using PayrollLite.Application.Common.Enums;

namespace PayrollLite.Application.Payrolls.Commands.CreatePayroll;

public class CreatePayrollCommand : IRequest<int>
{
    public int MonthId { get; set; }
    public decimal ExchangeRate { get; set; }
    public string Description { get; set; }
}

public class CreatePayrollCommandHandler : IRequestHandler<CreatePayrollCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePayrollCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePayrollCommand request, CancellationToken cancellationToken)
    {
        var payrollStatus = _context.PayrollStatusTypes.Where(m => m.EnumKey == (int)PayrollStatusEnum.Created).FirstOrDefaultAsync();

        var model = new Payroll()
        {
            MonthId = request.MonthId,
            Year = DateTime.Today.Year,
            ExchangeRate = request.ExchangeRate,
            Description = request.Description,
            //Set the status to default at creation
            RecordedBy = "System",
            DateRecorded = DateTime.Now
        };

        _context.Payrolls.Add(model);
        await _context.SaveChangesAsync(new CancellationToken());

        return model.Id;       
    }
}
