﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dependencies.DatabaseSetting
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CitizenCollection { get; set; }
    }
}
