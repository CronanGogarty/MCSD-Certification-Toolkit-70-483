using System;
using System.Collections.Generic;


namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    public interface IStudent
{
    // The student's list of current courses.
    List<string> Courses { get; set; }

    // Print the student's current grades.
    void PrintGrades();
}
}
