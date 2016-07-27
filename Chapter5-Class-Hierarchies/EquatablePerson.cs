using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    class EquatablePerson : IEquatable<EquatablePerson>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals(EquatablePerson other)
        {
            return ((FirstName == other.FirstName) &&
                (LastName == other.LastName));
        }
    }
}
