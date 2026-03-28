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