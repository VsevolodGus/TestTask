using System;
using System.IO;
using System.Linq; // для выхода корркктности сортировки файла GetDataFromFile
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

        private List<Bar> ConvertTextToModels(List<string> lines)
        {
            var result = new List<Bar>();

            foreach (var line in lines)
            {
                var str = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                var item = new Bar()
                {
                    Symbol = str[0],
                    Description = str[1],
                    Date = Convert.ToDateTime(str[2]),
                    Time = Convert.ToDateTime(str[2] + ' ' + str[3]).TimeOfDay,
                    Open = Convert.ToDecimal(str[4].Replace('.', ',')),
                    High = Convert.ToDecimal(str[5].Replace('.', ',')),
                    Low = Convert.ToDecimal(str[6].Replace('.', ',')),
                    Close = Convert.ToDecimal(str[7].Replace('.', ',')),
                    TotalVolume = Convert.ToDecimal(str[8].Replace('.', ',')),
                };

                result.Add(item);
            }

            return result;
        }

        public List<Bar> GetDataFromFile(string path)
        {
            var lines = ReadFromFile(path);
            // OrderBy для чтобы  данные точно были отсортированы
            return ConvertTextToModels(lines).OrderBy(c => c.DateTime).ToList();
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


      


    }
}
