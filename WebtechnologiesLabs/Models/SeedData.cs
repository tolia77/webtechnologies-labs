using Microsoft.EntityFrameworkCore;
using WebtechnologiesLabs.Data;

namespace WebtechnologiesLabs.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new DriveTrackContext(
            serviceProvider.GetRequiredService<DbContextOptions<DriveTrackContext>>());

        // the database already has data
        if (context.Vehicles.Any() || context.Drivers.Any() || context.Clients.Any() || context.Deliveries.Any())
        {
            return;
        }

        var sprinter = new Vehicle { Model = "Mercedes-Benz Sprinter", LicensePlate = "BX1234AA", Capacity = 1500 };
        var transit = new Vehicle { Model = "Ford Transit", LicensePlate = "BX5678BB", Capacity = 1200 };
        var daily = new Vehicle { Model = "Iveco Daily", LicensePlate = "BX9012CC", Capacity = 3000 };

        var petrenko = new Driver
        {
            FirstName = "Ivan", LastName = "Petrenko", Phone = "+380671234567",
            LicenseNumber = "BXA123456", Vehicle = sprinter
        };
        var kovalenko = new Driver
        {
            FirstName = "Oleh", LastName = "Kovalenko", Phone = "+380502345678",
            LicenseNumber = "BXA654321", Vehicle = transit
        };
        var melnyk = new Driver
        {
            FirstName = "Andrii", LastName = "Melnyk", Phone = "+380933456789",
            LicenseNumber = "BXA112233"
        };

        var shevchenko = new Client
        {
            FirstName = "Olena", LastName = "Shevchenko", Email = "olena.shevchenko@gmail.com",
            Phone = "+380674567890", Address = "Khmelnytskyi, Proskurivska St, 10"
        };
        var bondar = new Client
        {
            FirstName = "Mykhailo", LastName = "Bondar", Email = "m.bondar@ukr.net",
            Phone = "+380505678901", Address = "Khmelnytskyi, Kamianetska St, 25"
        };
        var tkachenko = new Client
        {
            FirstName = "Iryna", LastName = "Tkachenko", Email = "iryna.tk@gmail.com",
            Phone = "+380936789012", Address = "Vinnytsia, Soborna St, 5"
        };

        var furniture = new Delivery
        {
            PickupAddress = "Khmelnytskyi, Proskurivska St, 10", DropoffAddress = "Kyiv, Khreshchatyk St, 22",
            PackageDescription = "Furniture", Weight = 350, Status = DeliveryStatus.Delivered,
            CreatedAt = DateTime.Parse("2026-09-28 09:30"), Driver = petrenko, Client = shevchenko
        };
        var tiles = new Delivery
        {
            PickupAddress = "Khmelnytskyi, Kamianetska St, 25", DropoffAddress = "Lviv, Horodotska St, 120",
            PackageDescription = "Building materials", Weight = 1100, Status = DeliveryStatus.InTransit,
            CreatedAt = DateTime.Parse("2026-10-05 14:00"), Driver = kovalenko, Client = bondar
        };
        var laptops = new Delivery
        {
            PickupAddress = "Vinnytsia, Soborna St, 5", DropoffAddress = "Khmelnytskyi, Zarichanska St, 3",
            PackageDescription = "Laptops", Weight = 40, Status = DeliveryStatus.Pending,
            CreatedAt = DateTime.Parse("2026-10-07 11:15"), Client = tkachenko
        };
        var documents = new Delivery
        {
            PickupAddress = "Khmelnytskyi, Proskurivska St, 10", DropoffAddress = "Ternopil, Ruska St, 8",
            PackageDescription = "Documents", Weight = 2, Status = DeliveryStatus.Failed,
            CreatedAt = DateTime.Parse("2026-10-01 10:00"), Driver = melnyk, Client = shevchenko
        };

        context.AddRange(sprinter, transit, daily);
        context.AddRange(petrenko, kovalenko, melnyk);
        context.AddRange(shevchenko, bondar, tkachenko);
        context.AddRange(furniture, tiles, laptops, documents);

        context.Reviews.AddRange(
            new Review
            {
                Rating = 5, Text = "Fast delivery, everything arrived safe.",
                CreatedAt = DateTime.Parse("2026-09-29 18:00"), Delivery = furniture
            },
            new Review
            {
                Rating = 2, Text = "The driver could not find the address.",
                CreatedAt = DateTime.Parse("2026-10-02 12:30"), Delivery = documents
            }
        );

        context.SaveChanges();
    }
}
