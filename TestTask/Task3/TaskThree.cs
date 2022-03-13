using System;
using System.Collections.Generic;
using TestTask.MyLinq;

namespace TestTask.Task3
{
    class TaskThree
    {
        public TaskThree()
        {
            this._workFile = new WorkFile();
        }
        private WorkFile _workFile;
        public void Task3Main()
        {
            var dataFile1 = _workFile.GetDataFromFile(Environment.CurrentDirectory + @"\AAPL-IQFeed-SMART-Stocks-Minute-Trade.txt");
            var dataFile2 = _workFile.GetDataFromFile(Environment.CurrentDirectory + @"\AAPL-IQFeed-SMART-Stocks-Minute-Trade-corrupted.txt");

            
            var intersectionData = dataFile1.Intersection(dataFile2);
            WriteIntersectionData(intersectionData);


            var lostData = dataFile1.LostBars(dataFile2);
            WriteLostData(lostData);


            WriteFullData(dataFile1, dataFile2);
        }


        private void WriteFullData(IEnumerable<Bar> firstBars, IEnumerable<Bar> secondBars)
        {
            var fullData = new List<Bar>(firstBars);
            fullData.AddRange(secondBars);
            var textFullData = fullData.DisticntBar().JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task3_FullData.txt", textFullData);
        }

        private void WriteLostData(IEnumerable<Bar> bars)
        {
            var textLost = bars.JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task3_Lost.txt", textLost);
        }

        private void WriteIntersectionData(IEnumerable<Bar> bars)
        {
            var textIntersection = bars.JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task3_Intersection.txt", textIntersection);
        }   
    }
}
