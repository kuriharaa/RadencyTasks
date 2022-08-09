﻿using ETL.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Loader
{
    public class FileSaver
    {
        private readonly string _fileName;
        private readonly string _folder;
        private string FolderPath => $@"{_folder}\{DateTime.Now.ToString("dd-MM-yyyy")}";
        public FileSaver(string fileName, string folder)
        {
            _fileName = fileName;
            _folder = folder;
        }

        public async Task SaveFileAsync(IEnumerable<OutputData> data)
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            using (var writer = new StreamWriter($@"{FolderPath}\{_fileName}"))
            {
                await writer.WriteLineAsync(JsonConvert.SerializeObject(data));
            }
        }
    }
}
