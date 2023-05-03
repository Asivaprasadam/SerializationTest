using Newtonsoft.Json;

namespace SerializationTestUI;

[Serializable]
public class User : IEquatable<User>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SomethingUnique { get; set; } = string.Empty;
    public string SomeGuid { get; set; }

    public string Avatar { get; set; } = string.Empty;
    public string CartId { get; set; }
    public string SSN { get; set; } = string.Empty;
    public Gender? Gender { get; set; }

    public List<Order> Orders { get; set; }

    public User() { }

    public User(int userId, string ssn)
    {
        Id = userId;
        SSN = ssn;
    }

    public void Serialize2JsonFile(string filePath)
    {
        string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);
    }

    public static User? Deserialize2JsonFile(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<User>(jsonString);
    }

    public void DoSomething() => Console.WriteLine($"{FullName}");

    public override bool Equals(object? obj)
    {
        if (obj is User otherUser)
            return Equals(otherUser);

        return false;
    }

    public bool Equals(User? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        // Compare properties for equality
        return Id == other.Id &&
               FirstName == other.FirstName &&
               LastName == other.LastName &&
               UserName == other.UserName &&
               Email == other.Email &&
               SomethingUnique == other.SomethingUnique &&
               SomeGuid == other.SomeGuid &&
               Avatar == other.Avatar &&
               CartId == other.CartId &&
               SSN == other.SSN &&
               Gender == other.Gender &&
               Orders.SequenceEqual(other.Orders);
    }

    public override int GetHashCode()
    {
        // Use a suitable hashing algorithm to combine the hash codes of all relevant properties
        int hash = HashCode.Combine(Id, FirstName, LastName, UserName, Email, SomethingUnique, SomeGuid);
        hash = HashCode.Combine(hash, Avatar, CartId, SSN, Gender);
        hash = HashCode.Combine(hash, Orders);

        return hash;
    }
}

public enum Gender
{
    male,
    female,
    other,
}