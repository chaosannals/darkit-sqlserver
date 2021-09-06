using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Darkit.SQLServer.Data;

namespace Darkit.SQLServer.Demo
{
    [Table(Name = "d_book")]
    [PrimaryKey("id")]
    [Index("NAME_UNIQUE", "Name", "Anthor", IsUnique = true)]
    public class Book
    {
        [Identity]
        [Column("id", IsNotNull = true)]
        public long Id { get; set; }

        [Column("name", Length = 100)]
        public string Name { get; set; }

        [Column("anthor")]
        public string Anthor { get; set; }

        [Column("price", Precision = 12, Scale = 3)]
        public decimal? Price { get; set; }

        [Column("up_at", IsNotNull = true, Default = "GETDATE()")]
        public DateTime UpAt { get; set; }

        [Column("down_at", Default = "NULL")]
        public DateTime? DownAt { get; set; }
    }
}
