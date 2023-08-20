using PayrollLite.Application.MonthsOfYear.Queries.GetMonthOfYearDetail;
using PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

namespace PayrollLite.Pages.MonthsOfYear;

public class DetailModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public MonthOfYearDto Dto { get; set; }

    public DetailModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetMonthOfYearDetailQuery() { Id = Id });
        return Page();
    }
}
