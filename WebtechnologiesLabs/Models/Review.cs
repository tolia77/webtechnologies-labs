using System.ComponentModel.DataAnnotations;

namespace WebtechnologiesLabs.Models;

public class Review
{
    public int Id { get; set; }

    // 1-5
    public int Rating { get; set; }
    [Display(Name = "Review")]
    public string Text { get; set; } = "";
    [Display(Name = "Date")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Display(Name = "Delivery")]
    public int DeliveryId { get; set; }
    public Delivery? Delivery { get; set; }
}
