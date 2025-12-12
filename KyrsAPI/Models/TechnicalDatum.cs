using System;
using System.Collections.Generic;

namespace KyrsAPI.Models;

public partial class TechnicalDatum
{
    public int TechnicalDataId { get; set; }

    public int VehicleId { get; set; }

    public string ServiceType { get; set; } = null!;

    public DateTime ServiceDate { get; set; }

    public int Mileage { get; set; }

    public string? WorkDescription { get; set; }

    public string? Recommendations { get; set; }

    public DateOnly? NextServiceDate { get; set; }

    public int? NextServiceMileage { get; set; }

    public decimal? LaborHours { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
