namespace PayrollLite.Pages.GenderTypes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public IList<GenderType> Vm { get; set; }

    public IndexModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.GenderTypes.ToListAsync();
        return Page();
    }
}
