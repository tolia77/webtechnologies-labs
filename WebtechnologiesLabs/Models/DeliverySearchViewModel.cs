namespace WebtechnologiesLabs.Models;

public class DeliverySearchViewModel
{
    public List<Delivery>? Deliveries { get; set; }
    public DeliveryStatus? Status { get; set; }
    public string? SearchString { get; set; }
}
