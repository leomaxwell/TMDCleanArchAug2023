using PayrollLite.Application.GenderTypes.Queries.GetGenderTypeDetail;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

namespace PayrollLite.Pages.GenderTypes;

public class DetailModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public GenderTypeDto Dto { get; set; }

    public DetailModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetGenderTypeDetailQuery() { Id = Id });
        return Page();
    }
}
