
using System;

// Base Abstract Class
abstract class ToolVehicle
{
    // Properties
    public int VehicleID { get; set; }
    public string RegNo { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; }

    // Static Properties
    public static int TotalVehicles { get; private set; } = 0;
    public static int TotalTaxPayingVehicles { get; private set; } = 0;
    public static int TotalNonTaxPayingVehicles { get; private set; } = 0;
    public static decimal TotalTaxCollected { get; private set; } = 0;

    // Constructor
    public ToolVehicle(int vehicleID, string regNo,
        string model, string brand, decimal basePrice,
        string vehicleType)
    {
        VehicleID = vehicleID;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = basePrice;
        VehicleType = vehicleType;

        TotalVehicles++;
    }

    // Abstract Method
    public abstract void PayTax();

    // Method for vehicles passing without paying tax
    public void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;

        Console.WriteLine(VehicleType +
            " passed without paying tax.");
    }

    // Common method to update tax records
    protected void CollectTax(decimal tax)
    {
        TotalTaxCollected += tax;
        TotalTaxPayingVehicles++;

        Console.WriteLine(VehicleType +
            " paid tax: $" + tax);
    }

    // Display vehicle information
    public void DisplayInfo()
    {
        Console.WriteLine("\nVehicle ID: " + VehicleID);
        Console.WriteLine("Registration: " + RegNo);
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Brand: " + Brand);
        Console.WriteLine("Base Price: $" + BasePrice);
        Console.WriteLine("Vehicle Type: " + VehicleType);
    }
}

// Derived Class: Car
class Car : ToolVehicle
{
    public Car(int id, string reg, string model,
        string brand, decimal price)
        : base(id, reg, model, brand, price, "Car")
    {
    }

    public override void PayTax()
    {
        CollectTax(2);
    }
}

// Derived Class: Bike
class Bike : ToolVehicle
{
    public Bike(int id, string reg, string model,
        string brand, decimal price)
        : base(id, reg, model, brand, price, "Bike")
    {
    }

    public override void PayTax()
    {
        CollectTax(1);
    }
}

// Derived Class: HeavyVehicle
class HeavyVehicle : ToolVehicle
{
    public HeavyVehicle(int id, string reg, string model,
        string brand, decimal price)
        : base(id, reg, model, brand, price, "Heavy Vehicle")
    {
    }

    public override void PayTax()
    {
        CollectTax(4);
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Creating Vehicles
        Car car1 = new Car(1, "ABC-123", "Civic",
            "Honda", 50000);

        Bike bike1 = new Bike(2, "XYZ-456", "CD-70",
            "Honda", 1500);

        HeavyVehicle heavy1 = new HeavyVehicle(3,
            "HT-789", "Truck", "Hino", 80000);

        Car car2 = new Car(4, "DEF-789", "Corolla",
            "Toyota", 45000);

        Bike bike2 = new Bike(5, "GHI-321", "125",
            "Yamaha", 2000);

        // Display Vehicle Information
        Console.WriteLine("===== VEHICLE DETAILS =====");

        car1.DisplayInfo();
        bike1.DisplayInfo();
        heavy1.DisplayInfo();

        // Tax Payment
        Console.WriteLine("\n===== TAX PAYMENT =====");

        car1.PayTax();       // $2
        bike1.PayTax();      // $1
        heavy1.PayTax();     // $4

        // Vehicles passing without paying
        Console.WriteLine("\n===== WITHOUT TAX =====");

        car2.PassWithoutPaying();
        bike2.PassWithoutPaying();

        // Final Report
        Console.WriteLine("\n===== FINAL TAX REPORT =====");

        Console.WriteLine("Total Vehicles: " +
            ToolVehicle.TotalVehicles);

        Console.WriteLine("Tax Paying Vehicles: " +
            ToolVehicle.TotalTaxPayingVehicles);

        Console.WriteLine("Non Tax Paying Vehicles: " +
            ToolVehicle.TotalNonTaxPayingVehicles);

        Console.WriteLine("Total Tax Collected: $" +
            ToolVehicle.TotalTaxCollected);

        Console.ReadKey();
    }
}
