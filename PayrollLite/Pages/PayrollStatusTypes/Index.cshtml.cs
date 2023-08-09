namespace PayrollLite.Pages.PayrollStatusTypes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public IList<PayrollStatusType> Vm { get; set; }

    public IndexModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.PayrollStatusTypes.ToListAsync();
        return Page();
    }
}
