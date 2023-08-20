using PayrollLite.Application.Employees.Queries.GetEmployees;

namespace PayrollLite.Pages.Employees;

public class IndexModel : PageModel
{
    private readonly IMediator _mediator;

    public EmployeesVm Vm { get; set; }

    public IndexModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _mediator.Send(new GetEmployeesQuery());
        return Page();
    }
}
