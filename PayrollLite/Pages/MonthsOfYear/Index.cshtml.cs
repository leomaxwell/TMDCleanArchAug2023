namespace PayrollLite.Pages.MonthsOfYear;

public class IndexModel : PageModel
{
    private readonly IApplicationDbContext _dbContext;

    public IList<MonthOfYear> Vm { get; set; }

    public IndexModel(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.MonthsOfYear.OrderBy(m => m.Number).ToListAsync();
        return Page();
    }
}
