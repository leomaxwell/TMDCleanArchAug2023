namespace PayrollLite.Application.Payrolls.Commands.UpdatePayroll;

public class UpdatePayrollCommand : IRequest<bool>
{
    public int Id { get; set; }
    public decimal ExchangeRate { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
}

public class UpdatePayrollCommandHandler : IRequestHandler<UpdatePayrollCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePayrollCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePayrollCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Payrolls.FindAsync(request.Id);

        if (model == null)
        {
            throw new ArgumentException($"No record exist with the id:{request.Id}");
        }

        model.ExchangeRate = request.ExchangeRate;
        model.Description = request.Description;
        model.LastModifiedBy = "System";
        model.DateLastModified = DateTime.UtcNow;


        _context.Payrolls.Update(model);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
