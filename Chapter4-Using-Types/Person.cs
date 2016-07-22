
namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter4_Using_Types
{
    class Person
    {
        //private string firstName;
        //private string lastName;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return "Person";
        }
    }
}
