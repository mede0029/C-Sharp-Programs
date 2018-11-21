using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgonquinCollege.Registration.Entities;

public class StudentCompareByName : IComparer<AcademicRecord>
{
    public StudentCompareByName()
    {

    }

    public int Compare(AcademicRecord academicRecord1, AcademicRecord academicRecord2)
    {
        if (academicRecord1 == null && academicRecord2 != null)
            return -1;
        if (academicRecord1 != null && academicRecord2 == null)
            return 1;
        if (academicRecord1 == null && academicRecord2 == null)
            return 0;

        string firstname1 = academicRecord1.Student.Name.Split(' ')[0];
        string lastname1 = academicRecord1.Student.Name.Split(' ')[1];
        string firstname2 = academicRecord2.Student.Name.Split(' ')[0];
        string lastname2 = academicRecord2.Student.Name.Split(' ')[1];

        if (lastname1.CompareTo(lastname2) != 0)
        {
            return lastname1.CompareTo(lastname2);
        }
        else if (firstname1.CompareTo(firstname2) != 0)
        {
            return firstname1.CompareTo(firstname2);
        }
        return academicRecord1.Student.Name.CompareTo(academicRecord2.Student.Name);
    }
}