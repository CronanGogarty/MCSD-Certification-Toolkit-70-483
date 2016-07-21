
namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter4_Using_Types
{
    class Employee : Person
    {
        private string jobTitle;
        private int employeeID;
        public string JobTitle { get; set; }
        public int EmployeeID { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return "Employee";
        }
    }
}
