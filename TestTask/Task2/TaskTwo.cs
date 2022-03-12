using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.MyLinq;

namespace TestTask.Task2
{
    class TaskTwo
    {
        private WorkFile _workFile;

        // сократить в 60 раз
        // берем записи за час
        // Open open с час:00:00
        // High  - max за час
        // Low  - min за час
        // Close close с час:59:00
        // TotalVolume - сумма за час
        // Time час:00:00


        public TaskTwo()
        {
            _workFile = new WorkFile();
        }

        public void Task2Main()
        {
            var data = _workFile.GetDataFromFile(Environment.CurrentDirectory + @"\AAPL-IQFeed-SMART-Stocks-Minute-Trade.txt");
            var dataHours = data.GroupByHourOfPeriod();
            var text = dataHours.JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task2.txt", text);
        }
    }
}
