using SQLite.Net.Attributes;
using System;

namespace OBS.DBModels
{
    public class DbSinavSonuc
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
        public string YariyilID { get; set; }
    }
}
