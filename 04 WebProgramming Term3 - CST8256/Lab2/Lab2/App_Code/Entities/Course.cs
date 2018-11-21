using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course
{
    public string CourseNumber { get; set; }
    public string CourseName {get; set;}
    List<Student> StudentList = new List<Student>();

    public Course(string number, string name)
    {
        this.CourseName = name;
        this.CourseNumber = number;
    }

    //A method to add a student object to the course
    public void addStudent(Student student)
    {
        StudentList.Add(student);
    }
    
    //A method to return a list of students have been added to the course
    public static Student GetStudents(Student StudentList)
    {
        return StudentList;
    }

    //A method to present a course object in a string
    public override string ToString()
    {
        return CourseName.ToString() + " " + CourseNumber.ToString();
    }

}