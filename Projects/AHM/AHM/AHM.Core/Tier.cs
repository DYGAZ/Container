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
        List<Field> FieldList { get; set; }

    }

    public class Tier : ITier
    {
        public string TypeName { get; set; }
        public List<Field> FieldList { get; set; }
    }

    public class Field
    {
        public string Name;
        public float Value;
    }

}
