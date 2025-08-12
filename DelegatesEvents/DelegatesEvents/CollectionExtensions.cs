using System;
using System.Collections.Generic;
using System.Linq;

public static class CollectionExtensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null || !collection.Any())
            return null;

        T maxItem = collection.First();
        float maxValue = convertToNumber(maxItem);

        foreach (var item in collection.Skip(1))
        {
            float currentValue = convertToNumber(item);
            if (currentValue > maxValue)
            {
                maxValue = currentValue;
                maxItem = item;
            }
        }

        return maxItem;
    }
}