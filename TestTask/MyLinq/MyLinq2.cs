using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.MyLinq
{
    public static partial class MyLinq
    {
        public static List<Bar> GroupByHourOfPeriod(this IEnumerable<Bar> bars)
        {
            var result = new List<Bar>();

            var dicDate = bars.GroupByDate();

            foreach (var item in dicDate)
            {
                result.AddRange(item.Value.GroupByHoursOfDay());
            }

            return result;
        }


        private static List<Bar> GroupByHoursOfDay(this IEnumerable<Bar> bars)
        {
            var dic = new Dictionary<short, List<Bar>>();

            foreach (var item in bars)
            {
                var itemHour = (short)Math.Floor(item.Time.TotalHours);
                if (dic.ContainsKey(itemHour))
                {
                    dic[itemHour].Add(item);
                }
                else
                {
                    dic.Add(itemHour, new List<Bar> { item });
                }
            }

            var result = new List<Bar>();
            
            foreach(var item in dic.Values)
            {
                result.Add(item.CreateBarByHour());
            }

            return result;
        }

        private static Bar CreateBarByHour(this IEnumerable<Bar> bars)
        {
            var firstItem = bars.FirstItem();
            var lastItem = bars.LastItemByTime();
            var result = new Bar
            {
                Symbol = firstItem.Symbol,
                Description = firstItem.Description,
                Date = firstItem.Date,
                Time = firstItem.Time,
                Open = firstItem.Open,
                High = bars.MaxHigh().High,
                Low = bars.MinLow().Low,
                Close = lastItem.Close,
                TotalVolume = bars.SumTotalVolume(),
            };

            return result;
        }

        private static decimal SumTotalVolume(this IEnumerable<Bar> bars)
        {
            decimal result = 0;

            foreach (var item in bars)
            {
                result += item.TotalVolume;
            }

            return result;
        }

        private static Bar LastItemByTime(this IEnumerable<Bar> bars)
        {
            var index = 0;
            foreach (var item in bars)
            {
                ++index;
            }
            foreach (var item in bars)
            {
                --index;
                if (index == 0)
                    return item;
            }

            return null;
        }
        
        private static Bar FirstItem(this IEnumerable<Bar> bars)
        {
            foreach (var item in bars)
                return item;

            return null;
        }

        public static string JoinToString(this IEnumerable<Bar> bars)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in bars)
            {
                stringBuilder.AppendLine(item.BarToString());
            }

            return stringBuilder.ToString();
        }
    }
}
