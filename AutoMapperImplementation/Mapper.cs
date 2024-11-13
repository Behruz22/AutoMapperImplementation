using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Mapper
{
    private Dictionary<(Type Source, Type Destination), Func<object, object>> _mappings = new();

    public void CreateMap<TSource, TDestination>(Func<TSource, TDestination> mapFunction)
    {
        _mappings.Add((typeof(TSource), typeof(TDestination)), source => mapFunction((TSource)source));
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        var key = (typeof(TSource), typeof(TDestination));
        if (_mappings.ContainsKey(key))
        {
            return (TDestination)_mappings[key](source);
        }

        throw new InvalidOperationException("No mapping exists for the specified types.");
    }

    // Custom converter method
    public static TDestination Convert<TSource, TDestination>(TSource source)
    {
        // Add type conversion logic here
        // Example: converting DateTime to string
        if (typeof(TSource) == typeof(DateTime) && typeof(TDestination) == typeof(string))
        {
            return (TDestination)(object)((DateTime)(object)source).ToString("yyyy-MM-dd");
        }

        throw new InvalidOperationException("No converter exists for the specified types.");
    }


    //public TDestination Map<TSource, TDestination>(TSource source)
    //    where TDestination : new()
    //{
    //    var destination = new TDestination();
    //    var sourceProperties = typeof(TSource).GetProperties();
    //    var destinationProperties = typeof(TDestination).GetProperties();

    //    foreach (var sourceProperty in sourceProperties)
    //    {
    //        var destinationProperty = destinationProperties
    //            .FirstOrDefault(prop => prop.Name == sourceProperty.Name && prop.PropertyType == sourceProperty.PropertyType);

    //        if (destinationProperty != null && destinationProperty.CanWrite)
    //        {
    //            var value = sourceProperty.GetValue(source);
    //            destinationProperty.SetValue(destination, value);
    //        }
    //    }

    //    if (destination != null)
    //        return destination;
    //    else
    //        throw new InvalidOperationException("Xatolik");
    //}
}
