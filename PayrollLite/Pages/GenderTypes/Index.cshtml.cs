using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

namespace PayrollLite.Pages.GenderTypes;

public class IndexModel : PageModel
{
    private readonly IMediator _mediator;

    public GenderTypesVm Vm { get; set; }

    public IndexModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await  _mediator.Send(new GetGenderTypesQuery());        
        return Page();
    }
}
