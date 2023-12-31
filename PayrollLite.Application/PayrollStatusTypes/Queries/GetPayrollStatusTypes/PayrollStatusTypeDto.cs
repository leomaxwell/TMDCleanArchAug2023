﻿namespace PayrollLite.Application.PayrollStatusTypes.Queries.GetPayrollStatusTypes;

public class PayrollStatusTypeDto : IMapFrom<PayrollStatusType>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
