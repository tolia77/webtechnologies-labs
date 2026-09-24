namespace WebtechnologiesLabs.Models;

public class Driver
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string LicenseNumber { get; set; } = "";

    public int? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    public List<Delivery> Deliveries { get; set; } = new();
}
