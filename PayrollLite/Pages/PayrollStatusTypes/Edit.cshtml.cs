namespace PayrollLite.Pages.PayrollStatusTypes;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public PayrollStatusType Vm { get; set; }

    public EditModel(ApplicationDbContext dbContext)
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
        if (ModelState.IsValid)
        {
            var model = await _dbContext.PayrollStatusTypes.FindAsync(Vm.Id);
            model.Name = Vm.Name;
            model.Description = Vm.Description;
            model.LastModifiedBy = "System";
            model.DateLastModified = DateTime.Now;
                        
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        return Page();
    }
}
