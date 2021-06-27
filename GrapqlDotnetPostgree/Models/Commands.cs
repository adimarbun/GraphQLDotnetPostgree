using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapqlDotnetPostgree.Models
{
    public class Commands
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string CommandLine { get; set; }
        public int PlatformsId { get; set; }
        public Platforms Platforms { get; set; }

    }
}
