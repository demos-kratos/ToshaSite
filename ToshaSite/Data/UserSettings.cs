using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToshaSite.Data
{
    public class UserSettings
    {
        public string Username { get; set; }
        public string PwdHash { get; set; }
        public string PwdSalt { get; set; }
    }
}
