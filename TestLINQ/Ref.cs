using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLINQ
{
    [Table("Ref")]
    public class Ref : BaseEntity
    {
        public int ID2 { get; set; }
    }
}
