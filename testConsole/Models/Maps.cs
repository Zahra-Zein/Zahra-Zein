using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole.Models
{
    [Table("Maps ")]
    public class Maps
    {
        public int Id { get; set; }

        public int TreeId { get; set; }

        public int NodeId { get; set; }

        public int CreatedByCategoryId { get; set; }

        public int SubstituteNodeId { get; set; }

        public virtual ICollection<MapSource> MapSources { get; set; }
    }
}
