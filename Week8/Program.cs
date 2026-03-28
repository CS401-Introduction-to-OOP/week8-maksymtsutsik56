namespace Week8;

internal abstract class DeliveryItem
{
    public double Weight { get; set; }
    public string TrackingNumber { get; set; }

    protected DeliveryItem(string trakingNumber, double weight)
    {
        Weight = weight;
        TrackingNumber = trakingNumber;
    }

    public abstract double CalculateCost();

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{TrackingNumber} - {Weight}");
    }
}


internal class Letter : DeliveryItem
{
    public Letter(string trakingNmber, double weight) : base(trakingNmber, weight)
    {
    }

    public override double CalculateCost()
    {
        return 15 + Weight * 10;
    }
}

internal class Parcel : DeliveryItem
{
    public string Dimensions { get; set; }

    public Parcel(string trakingNmber, double weight, string dimensions) : base(trakingNmber, weight)
    {
        Dimensions = dimensions;
    }

    public override double CalculateCost()
    {
        return 50 + Weight * 25;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.Write($"Dimensions: {Dimensions}");
    }
}

internal class CargoContainer<T> where T : DeliveryItem
{
    private List<T> _cargoItems;

    public CargoContainer()
    {
        _cargoItems = new();
    }

    public void AddItem(T item)
    {
        _cargoItems.Add(item);
    }

    public double GetTotalCost()
    {
        double total = default;

        foreach (T item in _cargoItems)
        {
            total += item.CalculateCost();
        }

        return total;
    }
}

internal class Program
{
    static void Main()
    {
        Letter letter1 = new("H1A4", 0.150);
        Letter letter2 = new("H1A5", 0.200);

        Parcel parcel1 = new("MIG29", 12200, "2x12x15");
        Parcel parcel2 = new("SU25", 15600, "2x8x10");

        letter1.PrintInfo();
        parcel1.PrintInfo();

        CargoContainer<DeliveryItem> container = new();

        container.AddItem(letter1);
        container.AddItem(letter2);

        container.AddItem(parcel1);
        container.AddItem(parcel2);

        Console.WriteLine();
        Console.WriteLine("total cost: " + container.GetTotalCost().ToString());
    }
}