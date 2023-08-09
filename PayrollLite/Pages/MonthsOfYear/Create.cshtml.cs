namespace PayrollLite.Pages.MonthsOfYear;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty]
    public MonthOfYear Vm { get; set; }

    public CreateModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            var model = new MonthOfYear()
            {
                Name = Vm.Name,
                Abbreviation = Vm.Abbreviation,
                Number = Vm.Number,
                RecordedBy = Vm.RecordedBy,
                DateRecorded = DateTime.Now
            };

            _dbContext.MonthsOfYear.Add(model);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        return Page();
    }
}
