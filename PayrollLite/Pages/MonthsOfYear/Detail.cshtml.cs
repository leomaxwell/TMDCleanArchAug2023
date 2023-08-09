namespace PayrollLite.Pages.MonthsOfYear;

public class DetailModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public MonthOfYear Vm { get; set; }

    public DetailModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.MonthsOfYear.FindAsync(Id);
        return Page();
    }
}