namespace PayrollLite.Pages.PayrollStatusTypes;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public PayrollStatusType Vm { get; set; }

    public DeleteModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.PayrollStatusTypes.FindAsync(Id);
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var model = await _dbContext.PayrollStatusTypes.FindAsync(Vm.Id);

        if(model is null)
        {
            return Page();
        }

        _dbContext.PayrollStatusTypes.Remove(model);
        await _dbContext.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}