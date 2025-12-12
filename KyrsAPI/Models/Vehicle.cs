using System;
using System.Collections.Generic;

namespace KyrsAPI.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int ClientId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string? Vin { get; set; }

    public string LicensePlate { get; set; } = null!;

    public string? EngineType { get; set; }

    public decimal? EngineCapacity { get; set; }

    public string? Color { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<TechnicalDatum> TechnicalData { get; set; } = new List<TechnicalDatum>();
}
