using PayrollLite.Application.PayrollStatusTypes.Commands.UpdatePayrollStatusType;
using PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypeDetail;
using PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypes;

namespace PayrollLite.Pages.PayrollStatusTypes;

public class EditModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public PayrollStatusTypeDto Dto { get; set; }

    [BindProperty]
    public UpdatePayrollStatusTypeCommand Command { get; set; }

    public EditModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetPayrollStatusTypeDetailQuery() { Id = Id });
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
