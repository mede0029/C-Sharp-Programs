using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentComparerByGrade
/// </summary>
public class StudentComparerByGrade : IComparer<Student>
{
    public int Compare(Student student1, Student student2)
    {
        if (student1.Grade.CompareTo(student2.Grade) != 0)
        {
            return student1.Grade.CompareTo(student2.Grade);
        }
        else
        {
            StudentCompareByName compareByName = new StudentCompareByName();
            return compareByName.Compare(student1, student2); //if grades are the same, then sort by name (first name, last name, then ID)
        }
    }
}