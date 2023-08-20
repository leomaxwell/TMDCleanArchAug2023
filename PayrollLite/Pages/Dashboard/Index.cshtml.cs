namespace PayrollLite.Pages.Dashboard;

[Authorize(Roles = "Employee")]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
