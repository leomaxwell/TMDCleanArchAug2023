namespace PayrollLite.Pages.PayrollStatusTypes;

public class DetailModel : PageModel
{
    private readonly IApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public PayrollStatusType Vm { get; set; }

    public DetailModel(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.PayrollStatusTypes.FindAsync(Id);
        return Page();
    }
}
