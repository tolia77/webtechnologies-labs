using System.ComponentModel.DataAnnotations;

namespace WebtechnologiesLabs.Models;

public enum DeliveryStatus
{
    Pending,
    [Display(Name = "In transit")]
    InTransit,
    Delivered,
    Failed
}
