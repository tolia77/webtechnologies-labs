using System.ComponentModel.DataAnnotations;

namespace WebtechnologiesLabs.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Model { get; set; } = "";
    [Display(Name = "Licence plate")]
    public string LicensePlate { get; set; } = "";

    // kg
    [Display(Name = "Capacity, kg")]
    public int Capacity { get; set; }

    public Driver? Driver { get; set; }
}
