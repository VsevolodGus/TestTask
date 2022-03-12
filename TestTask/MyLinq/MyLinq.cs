using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.MyLinq
{
    public static class MyLinq
    {
        public static bool ContainsMaxMinDayByDate(this IEnumerable<MaxMinDay> maxminDays, DateTime date)
        {
            foreach (var item in maxminDays)
            {
                if (item.Date == date)
                    return true;
            }

            return false;
        }

        public static Dictionary<DateTime, List<Bar>> GroupByDate(this IEnumerable<Bar> bars)
        {
            var result = new Dictionary<DateTime, List<Bar>>();

            foreach (var item in bars)
            {
                if(result.ContainsKey(item.Date))
                {
                    result[item.Date].Add(item);
                }
                else
                {
                    result.Add(item.Date, new List<Bar> { item });
                }
            }

            return result;
        }


        public static Bar MaxHigh(this IEnumerable<Bar> bars)
        {
            Bar result = new Bar()
            {
                High = decimal.MinValue
            };

            foreach (var item in bars)
            {
                if (item.High >= result.High)
                    result = item;
            }

            if (result.High == decimal.MinValue)
                return null;

            return result;
        }


        public static Bar MinLow(this IEnumerable<Bar> bars)
        {
            Bar result = new Bar()
            {
                Low = decimal.MaxValue
            };

            foreach (var item in bars)
            {
                if (item.Low <= result.Low)
                    result = item;
            }

            if (result.Low == decimal.MaxValue)
                return null;

            return result;
        }

        public static MaxMinDay SelectMaxMinDay(this IEnumerable<Bar> bars, DateTime date)
        {
            var result = new MaxMinDay
            {
                Date = date,
                MaxValue = bars.MaxHigh(),
                MinValue = bars.MinLow(),
            };
           
            return result;
        }

        private static string BarToString(this Bar bar)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(bar.Symbol + ',' + bar.Description + ',' +
                                 bar.Date.ToString("dd-mm-yyyy") + ',' + bar.Time.ToString() + ','
                                 + bar.Open + bar.High + ','
                                 + bar.Low + ',' + bar.Close + ','
                                 + bar.TotalVolume);

            return stringBuilder.ToString();
        }
        public static string JoinToString(this IEnumerable<MaxMinDay> data)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in data)
            {
                stringBuilder.AppendLine(item.MaxValue.BarToString());
                stringBuilder.AppendLine(item.MinValue.BarToString());
            }

            return stringBuilder.ToString();
        }
    }
}
