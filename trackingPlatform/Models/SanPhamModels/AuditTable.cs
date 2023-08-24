using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class AuditTable
{
    public string? TableName { get; set; }

    public string? TransacttonName { get; set; }

    public string? ByUser { get; set; }

    public DateOnly? TransacttonDate { get; set; }
}
