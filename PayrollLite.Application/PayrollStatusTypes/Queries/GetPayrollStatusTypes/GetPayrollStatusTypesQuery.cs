namespace PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypes;

public class GetPayrollStatusTypesQuery : IRequest<PayrollStatusTypesVm> { }

public class GetPayrollStatusTypesQueryHandler : IRequestHandler<GetPayrollStatusTypesQuery, PayrollStatusTypesVm>
{
    private readonly IApplicationDbContext _context;

    public GetPayrollStatusTypesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PayrollStatusTypesVm> Handle(GetPayrollStatusTypesQuery request, CancellationToken cancellationToken)
    {
        var PayrollStatusTypes = new List<PayrollStatusTypeDto>();

        var models = await _context.PayrollStatusTypes.ToListAsync();



        foreach (var item in models)
        {
            var dto = new PayrollStatusTypeDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            PayrollStatusTypes.Add(dto);
        }

        var vm = new PayrollStatusTypesVm() { PayrollStatusTypes = PayrollStatusTypes };
        return vm;
    }
}
