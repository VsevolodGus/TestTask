using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Bar
    {
        public string Symbol { get; init; }

        public string Description { get; init; }

        public DateTime DateTime 
        {
            get => Date.Add(Time);
        }
        public DateTime Date { get; init; } 

        public TimeSpan Time { get; init; }

        public decimal Open { get; init; }
        
        public decimal High{ get; init; }

        public decimal Low { get; init; }

        public decimal Close { get; init; }

        public decimal TotalVolume { get; init; }
    }
}
