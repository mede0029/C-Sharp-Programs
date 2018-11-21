using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlgonquinCollege.Registration.Entities;


public partial class AddStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            LinkButton btnHome = (LinkButton)Master.FindControl("btnHome"); //instanciating Home Button
            BulletedList topMenu = (BulletedList)Master.FindControl("topMenu"); //instanciationg Top Menu
            if (!IsPostBack)
            {
                topMenu.Items.Add(new ListItem("Add Courses")); //adding dynamic buttons to Top Menu
            }
            topMenu.Click += (s, a) => Response.Redirect("AddCourse.aspx");//adding action to Add Courses Button
            btnHome.Click += (s, a) => Response.Redirect("Default.aspx");//adding action to Home Button

            if (!IsPostBack)
            {
                if (Session["courseListSession"] != null)//diplaying table of courses
                {
                    List<Course> courseList = new List<Course>();
                    courseList = (List<Course>)Session["courseListSession"];
                    foreach (Course item in courseList)
                    {
                        DropDownList1.Items.Add(item.ToString());
                    }
                }
            }
        }
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        //creating a new student
        string studentNumber = studentNumberTxt.Text;
        string studentName = studentNameTxt.Text;
        AlgonquinCollege.Registration.Entities.Student newStudent = new AlgonquinCollege.Registration.Entities.Student(studentNumber, studentName);

        //create a new course
        string index = (string)Session["selectedCourse"];
        string selectedCourseName = DropDownList1.SelectedValue.ToString();
        Course newCourse = new Course(index, selectedCourseName);

        //creating a list of academic records
        List<AcademicRecord> academicRecordList = new List<AcademicRecord>();
        AcademicRecord newAcademicRecord = new AcademicRecord(newCourse, newStudent);
        newAcademicRecord.Grade = int.Parse(gradeTxt.Text);

        //adding course to list and session
        if (Session["academicRecordListSession"] == null)
        {
            academicRecordList.Add(newAcademicRecord);
            Session["academicRecordListSession"] = academicRecordList;
        }
        else
        {
            academicRecordList = (List<AcademicRecord>)Session["academicRecordListSession"];
            academicRecordList.Add(newAcademicRecord);
            Session["academicRecordListSession"] = academicRecordList;
        }

        //sorting list by name       
        StudentCompareByName myComp = new StudentCompareByName();
        academicRecordList.Sort(myComp);

        //displaying table
        foreach (AcademicRecord item in academicRecordList)
        {
            if (item.Course.CourseName == DropDownList1.Text)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = item.Student.Id.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Student.Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Grade.ToString();
                row.Cells.Add(cell);
                tableSort.Rows.Add(row);
            }
        }
        studentNumberTxt.Text = "";
        studentNameTxt.Text = "";
        gradeTxt.Text = "";
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //adding course to list and session
        if (Session["academicRecordListSession"] == null)
        {
            //Displaying empty table when page is loaded for the first time
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No student record exists so far.";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tableSort.Rows.Add(lastRow);
        }
        else
        {
            List<AcademicRecord> academicRecordList = new List<AcademicRecord>();
            academicRecordList = (List<AcademicRecord>)Session["academicRecordListSession"];
            foreach (AcademicRecord item in academicRecordList)
            {
                if (item.Course.CourseName == DropDownList1.Text)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();

                    cell.Text = item.Student.Id.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.Student.Name;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.Grade.ToString();
                    row.Cells.Add(cell);
                    tableSort.Rows.Add(row);
                }
            }
        }
    }
}