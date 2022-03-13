using System.Collections.Generic;
using System.Linq;
//using System.Linq; // только для ToArray в MyContains

namespace TestTask.MyLinq
{
    public static partial class MyLinq
    {

        //TODO: если отсортировано по датам - бинарный поиск
        public static bool MyContains(this IEnumerable<Bar> bars, Bar searchElement)
        {
            #region 
            //var mainBars = bars.ToArray();
            //var beginIndex = 0;
            //var endIndex = mainBars.Length - 1;

            //while (beginIndex < endIndex)
            //{
            //    var middleIndex = (beginIndex + endIndex) / 2;

            //    if (mainBars[middleIndex].Symbol == searchElement.Symbol
            //            && mainBars[middleIndex].Description == searchElement.Description
            //            && mainBars[middleIndex].DateTime == searchElement.DateTime)
            //        return true;

            //    if (middleIndex == 0 || middleIndex == mainBars.Length - 1)
            //        return false;

            //    if (mainBars[middleIndex].DateTime <= searchElement.DateTime)
            //    {
            //        beginIndex = middleIndex + 1;
            //    }
            //    else
            //    {
            //        endIndex = middleIndex;
            //    }
            //}
            #endregion

            foreach (var item in bars)
            {
                if (item.Symbol == searchElement.Symbol
                        && item.Description == searchElement.Description
                        && item.DateTime == searchElement.DateTime)
                {
                    return true;
                }
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

            foreach (var item in thisBars)
            {
                if (!otherBars.MyContains(item))
                    result.Add(item);
            }

            return result;
        }

        public static List<Bar> Intersection(this IEnumerable<Bar> thisBars, IEnumerable<Bar> otherBars)
        {
            thisBars = thisBars.ToArray();
            var result = new List<Bar>();

            foreach (var item in thisBars)
            {
                if (otherBars.MyContains(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
