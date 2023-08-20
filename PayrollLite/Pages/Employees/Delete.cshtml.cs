using PayrollLite.Application.Employees.Commands.DeleteEmployee;
using PayrollLite.Application.Employees.Queries.GetEmployeeDetail;
using PayrollLite.Application.Employees.Queries.GetEmployees;

namespace PayrollLite.Pages.Employees;

public class DeleteModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public EmployeeDto Dto { get; set; }

    public DeleteModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetEmployeeDetailQuery() { Id = Id});

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await _mediator.Send(new DeleteEmployeeCommand() { Id = Id});
        return RedirectToPage("Index");
    }
}
