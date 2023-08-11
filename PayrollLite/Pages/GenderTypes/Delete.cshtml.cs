using PayrollLite.Application.GenderTypes.Commands.DeleteGenderType;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypeDetail;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;

namespace PayrollLite.Pages.GenderTypes;

public class DeleteModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public GenderTypeDto Dto { get; set; }

    public DeleteModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetGenderTypeDetailQuery() { Id = Id });
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {        
        await _mediator.Send(new DeleteGenderTypeCommand() { Id = Id });

        return RedirectToPage("Index");
    }
}
