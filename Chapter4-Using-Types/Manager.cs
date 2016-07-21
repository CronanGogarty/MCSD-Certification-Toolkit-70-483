
using System.Collections.Generic;


namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter4_Using_Types
{
    class Manager : Employee    
    {
        private List<Employee> subordinates;
        private bool isDirector;
        public List<Employee> Subordinates { get; set; }
        public bool IsDirector { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return "Manager";
        }
    }
}
