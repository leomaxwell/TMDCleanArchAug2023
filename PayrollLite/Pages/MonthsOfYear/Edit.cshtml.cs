using PayrollLite.Application.MonthsOfYear.Commands.UpdateMonthOfYear;
using PayrollLite.Application.MonthsOfYear.Queries.GetMonthOfYearDetail;
using PayrollLite.Application.MonthsOfYear.Queries.GetMonthsOfYear;

namespace PayrollLite.Pages.MonthsOfYear;

public class EditModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public MonthOfYearDto Dto { get; set; }

    [BindProperty]
    public UpdateMonthOfYearCommand Command { get; set; }

    public EditModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetMonthOfYearDetailQuery() { Id = Id }); 
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            await _mediator.Send(Command);
            return RedirectToPage("Index");
        }

        return Page();
    }
}
