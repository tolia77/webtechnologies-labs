namespace WebtechnologiesLabs.Models;

public class Review
{
    public int Id { get; set; }

    // 1-5
    public int Rating { get; set; }
    public string Text { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int DeliveryId { get; set; }
    public Delivery? Delivery { get; set; }
}
