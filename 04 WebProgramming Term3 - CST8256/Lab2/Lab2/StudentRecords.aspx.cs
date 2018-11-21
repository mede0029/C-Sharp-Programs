using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if first page was not filled out yet, this page will be redirected to Default.cs
            if (Session["newCourse"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            // Course number and course name should be displayed in the Title bar of the page
            this.Title = (String)Session["courseNumberSession"] + " " + (String)Session["courseNameSession"];

            //Displaying table
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No student record exists so far.";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tableSort.Rows.Add(lastRow);
        }
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        string studentName = studentNameTxt.Text;
        string studentId = studentIdTxt.Text;
        int studentGrade = int.Parse(studentGradeTxt.Text);
        List<Student> courseList = new List<Student>();

        //Once the user clicks Add to Course Record button a student object will be created 
        Student newStudent = new Student(studentName, studentId, studentGrade);

        //and adde to the student list held by the course object.
        if (Session["courseListSession"] == null)
        {            
            courseList.Add(newStudent);
            Session["courseListSession"] = courseList;
        }
        else
        {
            courseList = (List<Student>)Session["courseListSession"];
            courseList.Add(newStudent);
            Session["courseListSession"] = courseList;
        }
     
        courseList = (List<Student>)Session["courseListSession"];
        foreach (Student st in courseList)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = st.ID.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = st.Name.ToString();
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = st.Grade.ToString();
            row.Cells.Add(cell);
            tableSort.Rows.Add(row);
        }

        studentIdTxt.Text = "";
        studentNameTxt.Text = "";
        studentGradeTxt.Text = "";

    }

    protected void sortType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Student> courseList = new List<Student>();
        courseList = (List<Student>)Session["courseListSession"];

        if (sortType.SelectedItem.Value == "0")
        {
            //ID was selected for sorting
            courseList.Sort();
            foreach (Student st in courseList)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = st.ID.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = st.Name.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = st.Grade.ToString();
                row.Cells.Add(cell);
                tableSort.Rows.Add(row);
            }
        }

        if (sortType.SelectedItem.Value == "1")
        {
            //Name was selected for sorting
            StudentCompareByName myComp = new StudentCompareByName();
            courseList.Sort(myComp);
            foreach (Student st in courseList)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = st.ID.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = st.Name.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = st.Grade.ToString();
                row.Cells.Add(cell);
                tableSort.Rows.Add(row);
            }
        }

        if (sortType.SelectedItem.Value == "2")
        {
            //Grade was selected for sorting
            StudentComparerByGrade myComp = new StudentComparerByGrade();
            courseList.Sort(myComp);
            foreach (Student st in courseList)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = st.ID.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = st.Name.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = st.Grade.ToString();
                row.Cells.Add(cell);
                tableSort.Rows.Add(row);
            }

        }
    }
}