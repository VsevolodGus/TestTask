using System.Collections.Generic;

namespace TestTask.MyLinq
{
    public static partial class MyLinq
    {
        //TODO: если отсортировано по датам - бинарный поиск
        public static bool MyContains(this IEnumerable<Bar> bars, Bar searchElement)
        {
            foreach (var item in bars)
            {
                if (item.Symbol == searchElement.Symbol 
                        && item.Description == searchElement.Description 
                        && item.DateTime == searchElement.DateTime)
                    return true;
            }

            return false;
        }

        public static List<Bar> DisticntBar(this IEnumerable<Bar> bars)
        {
            var result = new List<Bar>();

            foreach (var item in bars)
            {
                if (result.MyContains(item))
                    continue;

                result.Add(item);
            }

            return result;
        }


        public static List<Bar> LostBars(this IEnumerable<Bar> thisBars, IEnumerable<Bar> otherBars)
        {
            var result = new List<Bar>();

            foreach (var item in otherBars)
            {
                if (!thisBars.MyContains(item))
                    result.Add(item);
            }

            return result;
        }

        public static List<Bar> Intersection(this IEnumerable<Bar> thisBars, IEnumerable<Bar> otherBars)
        {
            var result = new List<Bar>();

            foreach (var item in otherBars)
            {
                if (thisBars.MyContains(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
