using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestTask
{
    class WorkFile
    {
        private List<string> ReadFromFile(string path)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(path))
            {
                bool firstStr = true;

                while (!reader.EndOfStream)
                {
                    var str = reader.ReadLine();

                    if (firstStr)
                    {
                        firstStr = false;
                        continue;
                    }

                    result.Add(str);
                }
            }

            return result;
        }


        public List<Bar> GetDataFromFile(string path)
        {
            var lines = ReadFromFile(path);
            return ConvertTextToModels(lines);
        }


        public void WriteToFile(string path, string text)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path).Dispose();
            }

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(text);
            }
        }


        private List<Bar> ConvertTextToModels(List<string> lines)
        {
            var result = new List<Bar>();

            foreach (var line in lines)
            {
                var str = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                var item = new Bar();
                item.Symbol = str[0];
                item.Description = str[1];
                item.Date = Convert.ToDateTime(str[2]);
                item.Time = Convert.ToDateTime(str[2] + ' ' + str[3]).TimeOfDay;
                item.Open = Convert.ToDecimal(str[4].Replace('.',','));
                item.High = Convert.ToDecimal(str[5].Replace('.', ','));
                item.Low = Convert.ToDecimal(str[6].Replace('.',','));
                item.Close = Convert.ToDecimal(str[7].Replace('.',','));
                item.TotalVolume = Convert.ToDecimal(str[8].Replace('.',','));

                result.Add(item);
            }

            return result;
        }


    }
}
