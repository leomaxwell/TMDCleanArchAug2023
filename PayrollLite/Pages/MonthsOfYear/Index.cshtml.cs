using PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

namespace PayrollLite.Pages.MonthsOfYear;

public class IndexModel : PageModel
{
    private readonly IMediator _mediator;

    public MonthsOfYearVm Vm { get; set; }

    public IndexModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _mediator.Send(new GetMonthsOfYearQuery());
        return Page();
    }
}
