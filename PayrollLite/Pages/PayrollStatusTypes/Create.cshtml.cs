namespace PayrollLite.Pages.PayrollStatusTypes;

public class CreateModel : PageModel
{
    private readonly IApplicationDbContext _dbContext;

    [BindProperty]
    public PayrollStatusType Vm { get; set; }

    public CreateModel(IApplicationDbContext dbContext)
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
            await _dbContext.SaveChangesAsync(new CancellationToken());

            return RedirectToPage("Index");
        }

        return Page();
    }
}
