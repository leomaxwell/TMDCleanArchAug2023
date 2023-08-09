namespace PayrollLite.Pages.PayrollStatusTypes;

public class DetailModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public PayrollStatusType Vm { get; set; }

    public DetailModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.PayrollStatusTypes.FindAsync(Id);
        return Page();
    }
}
