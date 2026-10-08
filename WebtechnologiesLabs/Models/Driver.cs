using System.ComponentModel.DataAnnotations;

namespace WebtechnologiesLabs.Models;

public class Driver
{
    public int Id { get; set; }
    [Display(Name = "First name")]
    public string FirstName { get; set; } = "";
    [Display(Name = "Last name")]
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    [Display(Name = "Licence number")]
    public string LicenseNumber { get; set; } = "";

    [Display(Name = "Vehicle")]
    public int? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    public List<Delivery> Deliveries { get; set; } = new();

    [Display(Name = "Name")]
    public string FullName => FirstName + " " + LastName;
}
