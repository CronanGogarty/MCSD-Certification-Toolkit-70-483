using System;
using System.Collections.Generic;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    class CarComparer : IComparer<Car>
    {
        public enum CompareField
        {
            Name = 1,
            Price,
            MaxMph,
            Horsepower,
        }

        public CompareField SortBy = CompareField.Name;

        public int Compare(Car x, Car y)
        {
            switch (SortBy)
            {
                case CompareField.Name:
                    return x.Name.CompareTo(y.Name);
                case CompareField.Price:
                    return x.Price.CompareTo(y.Price);
                case CompareField.MaxMph:
                    return  x.MaxMph.CompareTo(y.MaxMph);
                case CompareField.Horsepower:
                    return x.Horsepower.CompareTo(y.Horsepower);
            }
            return x.Name.CompareTo(y.Name);
        }

    }
}
