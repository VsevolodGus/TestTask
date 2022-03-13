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

            WriteFullData(dataFile1, dataFile2);

            WriteLostData(dataFile1, dataFile2);

            WriteIntersectionData(dataFile1, dataFile2);
        }


        private void WriteFullData(IEnumerable<Bar> firstBars, IEnumerable<Bar> secondBars)
        {
            var fullData = new List<Bar>(firstBars);
            fullData.AddRange(secondBars);
            var textFullData = fullData.DisticntBar().JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task3_FullData.txt", textFullData);
        }

        private void WriteLostData(IEnumerable<Bar> firstBars, IEnumerable<Bar> secondBars)
        {
            var lostData = firstBars.LostBars(secondBars);
            var textLost = lostData.JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task3_Lost.txt", textLost);
        }

        private void WriteIntersectionData(IEnumerable<Bar> firstBars, IEnumerable<Bar> secondBars)
        {
            var intersectionData = firstBars.LostBars(secondBars);
            var textIntersection = intersectionData.JoinToString();
            _workFile.WriteToFile(Environment.CurrentDirectory + @"\task3_Intersection.txt", textIntersection);
        }   
    }
}
