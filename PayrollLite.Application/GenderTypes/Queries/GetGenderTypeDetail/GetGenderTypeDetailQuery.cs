using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

namespace PayrollLite.Application.GenderTypes.Queries.GetGenderTypeDetail;

public class GetGenderTypeDetailQuery : IRequest<GenderTypeDto>
{
    public int Id { get; set; }
}

internal class GetGenderTypeDetailQueryHandler : IRequestHandler<GetGenderTypeDetailQuery, GenderTypeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenderTypeDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenderTypeDto> Handle(GetGenderTypeDetailQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.GenderTypes
                                .Where(m => m.Id ==  request.Id)
                                .ProjectTo<GenderTypeDto>(_mapper.ConfigurationProvider)
                                .SingleOrDefaultAsync();

        return dto;
    }
}
