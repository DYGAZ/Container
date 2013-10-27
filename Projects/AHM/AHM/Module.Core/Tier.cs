using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHM.Core;

namespace Module.Core
{
    public class Tier : ITier
    {
        public string TypeName { get; set; }
        public List<Enum> FieldList { get; set; }
    }
}
