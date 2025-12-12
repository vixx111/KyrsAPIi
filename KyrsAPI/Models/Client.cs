using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyrsAPI.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? IsActive { get; set; }
    [JsonIgnore]
    public string Password { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
