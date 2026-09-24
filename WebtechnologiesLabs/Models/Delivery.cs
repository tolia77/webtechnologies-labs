namespace WebtechnologiesLabs.Models;

public class Delivery
{
    public int Id { get; set; }
    public string PickupAddress { get; set; } = "";
    public string DropoffAddress { get; set; } = "";
    public string PackageDescription { get; set; } = "";

    // kg
    public decimal Weight { get; set; }

    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int? DriverId { get; set; }
    public Driver? Driver { get; set; }

    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    public Review? Review { get; set; }
}
