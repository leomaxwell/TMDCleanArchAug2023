using PayrollLite.Application.GenderTypes.Commands.UpdateGenderType;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypeDetail;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

namespace PayrollLite.Pages.GenderTypes;

public class EditModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public UpdateGenderTypeCommand Command { get; set; }

    public GenderTypeDto Dto { get; set; }

    public EditModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetGenderTypeDetailQuery() { Id = Id});
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            await _mediator.Send(Command);
            return RedirectToPage("Index");
        }
        else
        {
            Dto = await _mediator.Send(new GetGenderTypeDetailQuery() { Id = Id });
        }

        return Page();
    }
}
