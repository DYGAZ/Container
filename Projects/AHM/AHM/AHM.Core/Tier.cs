using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHM.Core
{
    public interface ITier
    {
        string TypeName { get; set; }
        List<Enum> FieldList { get; set; }

    }
    public class Tier : ITier
    {
        public string TypeName { get; set; }
        public List<Enum> FieldList { get; set; }
    }
}
