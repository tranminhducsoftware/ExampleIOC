using System;
using SimpleIoC.Interface;

namespace SimpleIoC.Implement
{
    public class Database : IDatabase
    {
        public void Save(int id)
        {
              Console.WriteLine($"ToSave : {id}");
        }
    }
}