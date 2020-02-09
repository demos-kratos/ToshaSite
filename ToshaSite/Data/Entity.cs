using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToshaSite.Data
{
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        public string Text { get; set; }
        public int Weight { get; set; } = 100;
        public DateTime CreationDate { get; set; }
    }
}
