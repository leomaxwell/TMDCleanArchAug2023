using PayrollLite.Application.MonthsOfYear.Commands.CreateMonthOfYear;

namespace PayrollLite.Pages.MonthsOfYear;

public class CreateModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty]
    public CreateMonthOfYearCommand Command { get; set; }

    public CreateModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult OnGet()
    {
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
