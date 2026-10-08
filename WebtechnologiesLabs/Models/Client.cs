using System.ComponentModel.DataAnnotations;

namespace WebtechnologiesLabs.Models;

public class Client
{
    public int Id { get; set; }
    [Display(Name = "First name")]
    public string FirstName { get; set; } = "";
    [Display(Name = "Last name")]
    public string LastName { get; set; } = "";
    [Display(Name = "E-mail")]
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";

    public List<Delivery> Deliveries { get; set; } = new();

    [Display(Name = "Name")]
    public string FullName => FirstName + " " + LastName;
}
