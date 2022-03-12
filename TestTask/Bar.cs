using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Bar
    {
        public string Symbol { get; set; }

        public string Description { get; set; }

        public DateTime DateTime 
        {
            get => Date.Add(Time);
        }
        public DateTime Date { get; set; } 

        public TimeSpan Time { get; set; }

        public decimal Open { get; set; }
        
        public decimal High{ get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal TotalVolume { get; set; }
    }

    public class MaxMinDay
    {
        public DateTime Date { get; set; }
        public Bar MinValue { get; set; }
        public Bar MaxValue { get; set; }
    }
}
