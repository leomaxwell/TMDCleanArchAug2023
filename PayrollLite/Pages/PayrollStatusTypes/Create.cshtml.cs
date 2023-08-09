namespace PayrollLite.Pages.PayrollStatusTypes;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty]
    public PayrollStatusType Vm { get; set; }

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
            var model = new PayrollStatusType()
            {
                Name = Vm.Name,
                Description = Vm.Description,
                RecordedBy = Vm.RecordedBy,
                DateRecorded = DateTime.Now
            };

            _dbContext.PayrollStatusTypes.Add(model);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        return Page();
    }
}
