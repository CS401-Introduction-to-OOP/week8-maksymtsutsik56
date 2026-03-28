Logistics;

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