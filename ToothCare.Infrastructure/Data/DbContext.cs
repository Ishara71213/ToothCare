using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using ToothCare.Domain.DataStructures;
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
        public async Task<int> GetNextId<T>(string fileName) where T : BaseEntity
        {
            CustomLinkedList<T>? dataList =  await GetAllFromFile<T>(fileName);
            int nextId = 1;
            if (dataList?.Count != 0)
            {
                nextId = dataList!.GetLast()!.GetId() + 1;
            }
            return nextId;
        }
        
        public async Task<T?> WriteToFile<T>(string fileName, T model) where T : BaseEntity 
        {
            try
            {
                

                string filePath = _baseFilePath + fileName + ".txt";
                if (File.Exists(filePath))
                {
                    model.SetId(await GetNextId<T>(fileName));
                }
                else
                {
                    model.SetId(1);
                }
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    //string stringData = JsonSerializer.Serialize(model);
                    string stringData = model.ToString()!;
                    await writer.WriteLineAsync(stringData);
                   // await writer.WriteLineAsync(stringData+",");
                }
                return model;
            }catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<CustomLinkedList<T>?> GetAllFromFile<T>(string fileName) where T : BaseEntity
        {
            CustomLinkedList<T>? dataList=new();
            string filePath = _baseFilePath + fileName + ".txt";
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    T genericObject = (T)Activator.CreateInstance(typeof(T))!;
                    T element = (T) genericObject.FromJson(line);
                    if (element.GetId()!= default)
                    {
                        dataList.Add(element);
                    }
                }
               

            }
            return dataList;
        }

        public async Task<bool> UpdateRcordById<T>(string fileName, T model) where T : BaseEntity
        {
            var lines = new StringBuilder();
            bool status = false;
            string query = "\"id\":\"" + model.GetId().ToString();

            string filePath = _baseFilePath + fileName + ".txt";
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.Contains(query))
                    {
                        lines.AppendLine(model.ToString());
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

        public async Task<T?> GetRcordById<T>(string fileName, int id) where T : BaseEntity
        {
            
            T? result = default;
            string query = "\"id\":\"" + id.ToString();

            string filePath = _baseFilePath + fileName + ".txt";
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.Contains(query))
                    {
                        T genericObject = (T)Activator.CreateInstance(typeof(T))!;
                        T element = (T)genericObject.FromJson(line);
                        if (element.GetId() != default)
                        {
                            return element;
                        }
                    }
                }
            }
            return result;

        }

        public async Task<bool> DeleteRcordById<T>(string fileName, int id)
        {
            var lines =new StringBuilder();
            bool status = false;
            string query = "\"id\":\"" + id.ToString();

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
