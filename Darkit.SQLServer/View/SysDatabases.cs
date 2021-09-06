using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.SQLServer.View
{
    public class SysDatabases
    {
        public string name { get; set; }
        public int dbid { get; set; }
        public DateTime crdate { get; set; }
        public string filename { get; set; }
        public int version { get; set; }
    }
}
