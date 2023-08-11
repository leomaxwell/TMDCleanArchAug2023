using PayrollLite.Application.GenderTypes.Commands.CreateGenderType;

namespace PayrollLite.Pages.GenderTypes;

public class CreateModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty]
    public CreateGenderTypeCommand Command { get; set; }

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
        if (ModelState.IsValid == false)
        {
            return Page();            
        }

        await _mediator.Send(Command);
        return RedirectToPage("Index");

    }
}
