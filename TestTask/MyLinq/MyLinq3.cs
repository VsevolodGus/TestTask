using System;
using System.Collections.Generic;
using System.Linq; // только для ToArray в MyContains

namespace TestTask.MyLinq
{
    public static partial class MyLinq
    {

        // делаю бинарник т.к файл отсортирован
        public static bool MyContains(this IEnumerable<Bar> bars, Bar searchElement)
        {
            #region Бинарный
            var mainBars = bars.ToArray();
            var beginIndex = 0;
            var endIndex = mainBars.Length - 1;



            while (beginIndex <= endIndex)
            {
                var middleIndex = (beginIndex + endIndex) / 2;

                if (mainBars[middleIndex].Symbol == searchElement.Symbol
                        && mainBars[middleIndex].Description == searchElement.Description
                        && mainBars[middleIndex].DateTime == searchElement.DateTime)
                    return true;

                if (middleIndex == 0 || middleIndex == mainBars.Length - 1)
                    return false;

                if (mainBars[middleIndex].DateTime <= searchElement.DateTime)
                {
                    beginIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex;
                }
            }
            #endregion

            #region Перебор
            //foreach (var item in bars)
            //{
            //    if (item.Symbol == searchElement.Symbol
            //            && item.Description == searchElement.Description
            //            && item.DateTime == searchElement.DateTime)
            //    {
            //        return true;
            //    }
            //}
            #endregion

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
            var result = new List<Bar>();

           

            foreach (var item in thisBars)
            {
                if (item.Time == Convert.ToDateTime("02.01.2020 08:30:00").TimeOfDay)
                { }

                if (otherBars.MyContains(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
