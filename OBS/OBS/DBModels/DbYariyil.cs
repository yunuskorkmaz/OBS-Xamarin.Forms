using SQLite.Net.Attributes;
using System;

namespace OBS.DBMOdels
{
    public class DbYariyil
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
    }
}
