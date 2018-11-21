using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentCompareByName
/// </summary>
public class StudentCompareByName: IComparer<Student>
{
    public StudentCompareByName()
    {

    }
    
    public int Compare(Student student1, Student student2)
    {
        if (student1 == null && student2 != null)
            return -1;
        if (student1 != null && student2 == null)
            return 1;
        if (student1 == null && student2 == null)
            return 0;        

        string firstname1 = student1.Name.Split(' ')[0];
        string lastname1 = student1.Name.Split(' ')[1];
        string firstname2 = student2.Name.Split(' ')[0];
        string lastname2 = student2.Name.Split(' ')[1];

        if (lastname1.CompareTo(lastname2) !=0)
        {
            return lastname1.CompareTo(lastname2);
        }   
        else if(firstname1.CompareTo(firstname2)!= 0)
        {
            return firstname1.CompareTo(firstname2);
        }
        return student1.Name.CompareTo(student2.Name);
    }
}