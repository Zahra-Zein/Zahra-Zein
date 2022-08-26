using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole.ViewModel
{
    public class MapViewModel
    {
        public int Id { get; set; }

        public int TreeId { get; set; }

        public int NodeId { get; set; }

        public int CreatedByCategoryId { get; set; }

        public int SubstituteNodeId { get; set; }
        public int MapSourceId { get; set; }

        public int MapId { get; set; }

        public string Code { get; set; }
    }
}
