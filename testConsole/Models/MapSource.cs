using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole.Models
{

    public class MapSource
    {
        public int Id { get; set; }

        public int MapId { get; set; }

        public string Code { get; set; }

        public Maps Map { get; set; } 
    }
}
