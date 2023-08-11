namespace PayrollLite.Pages.MonthsOfYear;

public class EditModel : PageModel
{
    private readonly IApplicationDbContext _dbContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public MonthOfYear Vm { get; set; }

    public EditModel(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnGet()
    {
        Vm = await _dbContext.MonthsOfYear.FindAsync(Id);
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            var model = await _dbContext.MonthsOfYear.FindAsync(Vm.Id);
            model.Name = Vm.Name;
            model.Abbreviation = Vm.Abbreviation;
            model.Number = Vm.Number;
            model.LastModifiedBy = "System";
            model.DateLastModified = DateTime.Now;
                        
            await _dbContext.SaveChangesAsync(new CancellationToken());

            return RedirectToPage("Index");
        }

        return Page();
    }
}
