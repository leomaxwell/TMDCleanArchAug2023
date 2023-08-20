using PayrollLite.Application.MonthsOfYear.Commands.DeleteMonthOfYear;
using PayrollLite.Application.MonthsOfYear.Queries.GetMonthOfYearDetail;
using PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

namespace PayrollLite.Pages.MonthsOfYear;

public class DeleteModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public MonthOfYearDto Dto { get; set; }

    public DeleteModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetMonthOfYearDetailQuery() { Id = Id});

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await _mediator.Send(new DeleteMonthOfYearCommand() { Id = Id});
        return RedirectToPage("Index");
    }
}
