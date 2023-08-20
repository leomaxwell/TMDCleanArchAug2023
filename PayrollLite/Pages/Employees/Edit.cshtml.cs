using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollLite.Application.Employees.Commands.UpdateEmployee;
using PayrollLite.Application.Employees.Queries.GetEmployeeDetail;
using PayrollLite.Application.Employees.Queries.GetEmployees;
using PayrollLite.Application.GenderTypes.Queries.GetGenderTypeSelectList;

namespace PayrollLite.Pages.Employees;

public class EditModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public EmployeeDto Dto { get; set; }

    [BindProperty]
    public UpdateEmployeeCommand Command { get; set; }

    public List<SelectListItem> GenderList { get; set; }

    public EditModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        GenderList = await _mediator.Send(new GetGenderTypeSelectListQuery());

        Dto = await _mediator.Send(new GetEmployeeDetailQuery() { Id = Id });
        Command = new UpdateEmployeeCommand() { GenderId = Dto.GenderId };
        

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
