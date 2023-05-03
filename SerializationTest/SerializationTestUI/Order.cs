using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

namespace SerializationTestUI;

public class Order : IEquatable<Order>
{
    public int OrderId { get; set; }
    public string Item { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int? LotNumber { get; set; }

    public static Order? Deserialize2JsonFile(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<Order>(jsonString);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Order otherOrder)
            return Equals(otherOrder);

        return false;
    }

    public bool Equals(Order? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        // Compare properties for equality
        return OrderId == other.OrderId &&
               Item == other.Item &&
               Quantity == other.Quantity &&
               LotNumber == other.LotNumber;
    }

    public override int GetHashCode() => HashCode.Combine(OrderId, Item, Quantity, LotNumber);
}