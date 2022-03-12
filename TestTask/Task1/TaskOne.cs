using System;
using System.Collections.Generic;
using TestTask.MyLinq;

namespace TestTask.Task1
{
    public class TaskOne
    {
        public TaskOne()
        {
            _workFile = new WorkFile();
        } 
        WorkFile _workFile;

        public void Task1Main()
        {
            var data = _workFile.GetDataFromFile(Environment.CurrentDirectory + @"\AAPL-IQFeed-SMART-Stocks-Minute-Trade.txt");
            var dataDays  = FindMaxMin(data);
            var text = dataDays.JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task1.txt", text);
        }



        private static List<MaxMinDay> FindMaxMin(in List<Bar> data)
        {
            var dic = data.GroupByDate();
            var result = new List<MaxMinDay>();
            foreach (var item in dic)
            {
                result.Add(item.Value.SelectMaxMinDay(item.Key));
            }

            return result;
        }
    }
}
