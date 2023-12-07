﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using ToothCare.Domain.Entities;

namespace ToothCare.Infrastructure.Data
{
    public class DbContext
    {   private readonly string _baseFilePath;
        public DbContext()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            _baseFilePath = currentDirectory.Replace("ToothCare.Presentation", "ToothCare.Infrastructure") + "\\DataBase\\" ;
        }
        public async Task<int> getNextId<T>(string fileName) where T : BaseEntity
        {
            List<T>? dataList =  await GetAllFromFile<T>(fileName);
            return dataList == null ? 1 : dataList.Last().Id+=1;
        }
        
        public async Task<bool> WriteToFile<T>(string fileName, T model) where T : BaseEntity
        {
            try
            {
                
                string filePath = _baseFilePath + fileName + ".txt";
                if (File.Exists(filePath))
                {
                    model.Id = await getNextId<T>(fileName);
                }
                else
                {
                    model.Id = 1;
                }
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    string stringData = JsonConvert.SerializeObject(model);
                    await writer.WriteLineAsync(stringData+",");
                }
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<T>?> GetAllFromFile<T>(string fileName)
        {
            string filePath = _baseFilePath + fileName + ".txt";
            string data = await File.ReadAllTextAsync(filePath);
            data= "["+data+"]";
            List<T>? dataList = JsonConvert.DeserializeObject<List<T>>(data);
            return dataList;
        }

       /* public async Task<bool> UpdateRcordById<T>(string fileName, T model) where T: BaseEntity
        {
            var lines = new StringBuilder();

            string filePath = _baseFilePath + fileName + ".txt";

            List<T>? dataList = await GetAllFromFile<T>(fileName);
            dataList.Where((){ })

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(lines.ToString());
                return status;
            }
        }*/

        public async Task<bool> DeleteRcordById<T>(string fileName, int id)
        {
            var lines =new StringBuilder();
            bool status = false;
            string query = "\"Id\":" + id.ToString();

            string filePath = _baseFilePath + fileName + ".txt";
            using (StreamReader reader = new StreamReader(filePath, true)) 
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.Contains(query)) 
                    {
                        status = true;
                    }
                    else lines.AppendLine(line);
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(lines.ToString());
                return status;
            }
            
        }
    }
}
