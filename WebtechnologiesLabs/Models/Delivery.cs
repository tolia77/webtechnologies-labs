using System.ComponentModel.DataAnnotations;

namespace WebtechnologiesLabs.Models;

public class Delivery
{
    public int Id { get; set; }
    [Display(Name = "Pickup address")]
    public string PickupAddress { get; set; } = "";
    [Display(Name = "Drop-off address")]
    public string DropoffAddress { get; set; } = "";
    [Display(Name = "Package")]
    public string PackageDescription { get; set; } = "";

    // kg
    [Display(Name = "Weight, kg")]
    public decimal Weight { get; set; }

    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
    [Display(Name = "Created")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Display(Name = "Driver")]
    public int? DriverId { get; set; }
    public Driver? Driver { get; set; }

    [Display(Name = "Client")]
    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    public Review? Review { get; set; }

    public string Title => "#" + Id + ": " + PickupAddress + " - " + DropoffAddress;
}
