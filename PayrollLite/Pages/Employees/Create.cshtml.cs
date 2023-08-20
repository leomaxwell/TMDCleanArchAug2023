using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollLite.Application.Employees.Commands.CreateEmployee;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypes;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypeSelectList;

namespace PayrollLite.Pages.Employees;

public class CreateModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty]
    public CreateEmployeeCommand Command { get; set; }

    public List<SelectListItem> GenderList { get; set; }

    public CreateModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        GenderList = await _mediator.Send(new GetGenderTypeSelectListQuery());
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
