using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.SQLServer.View
{
    public class SysObjects
    {
        public string name { get; set; }
        public int id { get; set; }
        public string xtype { get; set; }
        public int uid { get; set; }
        public int parent_obj { get; set; }
        public DateTime crdate { get; set; }
        public string type { get; set; }
        public DateTime refdate { get; set; }
    }
}
