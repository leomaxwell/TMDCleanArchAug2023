namespace PayrollLite.Pages.GenderTypes;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    [BindProperty]
    public GenderType Vm { get; set; }

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
            var model = new GenderType()
            {
                Name = Vm.Name,
                Description = Vm.Description,
                RecordedBy = Vm.RecordedBy,
                DateRecorded = DateTime.Now
            };

            _dbContext.GenderTypes.Add(model);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        return Page();
    }
}
