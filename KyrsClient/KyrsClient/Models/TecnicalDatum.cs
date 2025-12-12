using KyrsClient.Models;
using System;
using System.Collections.Generic;

namespace KyrsClient.Models;

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

}
