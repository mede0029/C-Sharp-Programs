using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student : IComparable<Student>
{
    public string Name;
    public string ID;
    public int Grade;

    public Student(string id, string name, int grade)
    {
        this.Name = name;
        this.ID = id;
        this.Grade = grade;
    }

    public override string ToString()
    {
        return ID + " " + Name;
    }

    public int CompareTo(Student other)
    {
        // If other is not a valid object, this student instance is greater.
        if (other == null) return 1;

        //string class implements ICompareTo
        return this.ID.CompareTo(other.ID);
    }

}