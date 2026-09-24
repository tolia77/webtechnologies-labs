namespace WebtechnologiesLabs.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Model { get; set; } = "";
    public string LicensePlate { get; set; } = "";

    // kg
    public int Capacity { get; set; }

    public Driver? Driver { get; set; }
}
