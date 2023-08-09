namespace PayrollLite.Pages.GenderTypes;

public class DetailModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public GenderType Vm { get; set; }

    public DetailModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.GenderTypes.FindAsync(Id);
        return Page();
    }
}
