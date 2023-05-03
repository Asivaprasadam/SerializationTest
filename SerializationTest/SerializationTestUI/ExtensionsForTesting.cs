using Newtonsoft.Json;
using System.Reflection;

namespace SerializationTestUI;
public static class ExtensionsForTesting
{
    public static void Dump(this object obj)
    {
        Console.WriteLine(obj.DumpString());
    }

    public static string DumpString(this object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }

    //public static bool DeepEquals<T>(this T obj1, T obj2)
    //{
    //    if (ReferenceEquals(obj1, obj2)) return true;
    //    if (obj1 is null || obj2 is null) return false;

    //    var type = typeof(T);

    //    foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    //    {
    //        var value1 = property.GetValue(obj1);
    //        var value2 = property.GetValue(obj2);

    //        if (property.PropertyType == typeof(string))
    //        {
    //            if (!string.Equals((string)value1, (string)value2, StringComparison.Ordinal))
    //            {
    //                return false;
    //            }
    //        }
    //        else if (property.PropertyType.IsClass)
    //        {
    //            if (!DeepEquals(value1, value2))
    //            {
    //                return false;
    //            }
    //        }
    //        else
    //        {
    //            if (!object.Equals(value1, value2))
    //            {
    //                return false;
    //            }
    //        }
    //    }

    //    return true;
    //}
}
