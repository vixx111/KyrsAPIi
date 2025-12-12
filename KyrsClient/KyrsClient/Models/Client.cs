using KyrsClient.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyrsClient.Models;

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
    public string? Password { get; set; }
}
