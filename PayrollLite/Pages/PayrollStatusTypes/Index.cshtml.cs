namespace PayrollLite.Pages.PayrollStatusTypes;

public class IndexModel : PageModel
{
    private readonly IApplicationDbContext _dbContext;

    public IList<PayrollStatusType> Vm { get; set; }

    public IndexModel(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.PayrollStatusTypes.ToListAsync();
        return Page();
    }
}
