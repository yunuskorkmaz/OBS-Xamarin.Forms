using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.DBModels
{
    public class DbProgram
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
    }
}
