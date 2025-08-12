using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.Extensions
{
    public static class CollectionExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (!collection.Any())
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
}
