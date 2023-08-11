using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

namespace PayrollLite.Application.GenderTypes.Queries.GetGenderTypeDetail;

public class GetGenderTypeDetailQuery : IRequest<GenderTypeDto>
{
    public int Id { get; set; }
}

public class GetGenderTypeDetailQueryHandler : IRequestHandler<GetGenderTypeDetailQuery, GenderTypeDto>
{
    private readonly IApplicationDbContext _context;

    public GetGenderTypeDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GenderTypeDto> Handle(GetGenderTypeDetailQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.GenderTypes.FindAsync(request.Id);

        var dto = new GenderTypeDto()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
        };

        return dto;
    }
}
