using Microsoft.AspNetCore.Mvc.Rendering;

namespace PayrollLite.Application.GenderTypes.Queries.GetGenderTypeSelectList
{
    public class GetGenderTypeSelectListQuery : IRequest<List<SelectListItem>> { }

    internal class GetGenderTypeSelectListQueryHandler : IRequestHandler<GetGenderTypeSelectListQuery, List<SelectListItem>>
    {
        private readonly IApplicationDbContext _context;

        public GetGenderTypeSelectListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> Handle(GetGenderTypeSelectListQuery request, CancellationToken cancellationToken)
        {
            return await _context.GenderTypes.Select(m => new SelectListItem()
                                                    {
                                                        Value = m.Id.ToString(),
                                                        Text = m.Name,
                                                    }).ToListAsync();
        }
    }

}
