using PayrollLite.Application.Employees.Queries.GetEmployeeDetail;
using PayrollLite.Application.Employees.Queries.GetEmployees;

namespace PayrollLite.Pages.Employees;

public class DetailModel : PageModel
{
    private readonly IMediator _mediator;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public EmployeeDto Dto { get; set; }

    public DetailModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Dto = await _mediator.Send(new GetEmployeeDetailQuery() { Id = Id });
        return Page();
    }
}
