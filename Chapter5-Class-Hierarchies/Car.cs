using System;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    class Car : IComparable<Car>
    {
        public string Name { get; set; }
        public int MaxMph { get; set; }
        public int Horsepower { get; set; }
        public decimal Price { get; set; }

        // Compare Cars alphabetically by Name.
        public int CompareTo(Car other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
