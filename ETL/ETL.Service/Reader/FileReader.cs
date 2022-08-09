using ETL.Service.Logger;
using ETL.Service.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Reader
{
    public class FileReader
    {
        private readonly string _filePath;
        private int _parsedLines;
        private int _foundErrors;
        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<InputData>> ReadFileAsync()
        {
            var list = new ConcurrentBag<InputData?>();
            var skipHeader = _filePath.EndsWith("csv");
            using (var reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (skipHeader)
                    {
                        skipHeader = false;
                        continue;
                    }
                    _parsedLines++;
                    if (line == null) continue;
                    if (InputData.TryParse(line, out var inputData))
                    {
                        list.Add(inputData);
                    }
                    else
                    {
                        _foundErrors++;
                    }
                }
            }
            return list.ToList();
        }
        public LogDetails GetLogs() => new(_foundErrors, _parsedLines, _filePath);
    }
}
