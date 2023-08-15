using PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypes;

namespace PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypeDetail;

public class GetPayrollStatusTypeDetailQuery : IRequest<PayrollStatusTypeDto>
{
    public int Id { get; set; }
}

internal class GetPayrollStatusTypeDetailQueryHandler : IRequestHandler<GetPayrollStatusTypeDetailQuery, PayrollStatusTypeDto>
{
    private readonly IApplicationDbContext _context;

    public GetPayrollStatusTypeDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PayrollStatusTypeDto> Handle(GetPayrollStatusTypeDetailQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.PayrollStatusTypes.FindAsync(request.Id);

        var dto = new PayrollStatusTypeDto()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
        };

        return dto;
    }
}
