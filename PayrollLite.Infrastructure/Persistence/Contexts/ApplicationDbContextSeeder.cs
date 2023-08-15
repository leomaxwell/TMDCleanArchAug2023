namespace PayrollLite.Infrastructure.Persistence.Contexts;

public class ApplicationDbContextSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        List<PayrollStatusEnum> payrollStatusEnums = Enum.GetValues(typeof(PayrollStatusEnum)).Cast<PayrollStatusEnum>().ToList(); 

        foreach(var statusEnum in payrollStatusEnums)
        {
            var status = context.PayrollStatusTypes.Any(m => m.EnumKey == (int)statusEnum);
            if (status == false)
            {
                var model = new PayrollStatusType()
                {
                    EnumKey = (int)statusEnum,
                    Name = statusEnum.ToString(),
                    RecordedBy = "System",
                    DateRecorded = DateTime.Now,
                };

                context.PayrollStatusTypes.Add(model);
            }
        }

        context.SaveChanges();
    }
}
