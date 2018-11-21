using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRecordDal;

public partial class AddStudent : BasePage
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e); //loading base page     
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome"); //loading button home from base page             

        if (!IsPostBack)
        {
            using (StudentRecordEntities entityContext = new StudentRecordEntities())
            {
                string action = Request.Params["action"];
                string studentNumber = Request.Params["id"];

                // displaying courses in dropdown list for the first time the page loads the first time
                var cs = (from c in entityContext.Courses
                          orderby c.Title
                          select new
                          {
                              CourseId = c.Code,
                              CourseText = c.Code + " - " + c.Title
                          }).ToList();
                if (cs.Count() == 0) //if there are no courses yet
                {
                    Response.Redirect("AddCourse.aspx");
                }
                else //retrieving courses information
                {
                    DropDownList1.DataSource = cs;
                    DropDownList1.DataTextField = "CourseText";
                    DropDownList1.DataValueField = "CourseId";
                    DropDownList1.DataBind();
                }

                //retrieve value if a course was previously selected for the dropdown list
                if (Session["selectedCourse"] != null) 
                {
                    DropDownList1.SelectedValue = (string)Session["selectedCourse"];
                }

                //displayin info to edit grade
                if (Request.Params["action"] == "edit")
                {
                    {
                        var acRecord = (from ac in entityContext.AcademicRecords
                                        where (ac.StudentId == studentNumber && ac.CourseCode == DropDownList1.SelectedValue)
                                        select ac).FirstOrDefault<AcademicRecord>();
                        if (acRecord != null)
                        {
                            studentNumberTxt.Text = acRecord.Student.Id;
                            studentNumberTxt.Enabled = false;
                            studentNameTxt.Text = acRecord.Student.Name;
                            studentNameTxt.Enabled = false;
                            gradeTxt.Text = acRecord.Grade.ToString();
                            DropDownList1.Enabled = false;
                        }
                    }
                }

                //deleting student
                if (Request.Params["action"] == "delete")
                {
                    var student = (from st in entityContext.Students
                                  where st.Id == studentNumber
                                  select st).FirstOrDefault<Student>();
                    if (student != null)
                    {
                        for (int i = student.AcademicRecords.Count() - 1; i >= 0; i--)
                        {
                            var ar = student.AcademicRecords.ElementAt<AcademicRecord>(i);
                            student.AcademicRecords.Remove(ar);
                        }
                    }
                    entityContext.Students.Remove(student);
                    entityContext.SaveChanges();
                    Response.Redirect("AddStudent.aspx");
                }                
            }
        }

        //displaying table of students when page loads again
        using (StudentRecordEntities  entityContext = new StudentRecordEntities())
        {
            List<AcademicRecord> academicRecord = entityContext.AcademicRecords.ToList<AcademicRecord>();
            foreach (AcademicRecord ac in academicRecord)
            {
                if (DropDownList1.SelectedValue == ac.Course.Code)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = ac.Student.Id.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = ac.Student.Name.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = ac.Grade.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "<a href='AddStudent.aspx?action=edit&id=" + ac.Student.Id + "'>Change Grade</a>" + " | " +
                            "<a class='deleteAcademicRecord' href='AddStudent.aspx?action=delete&id=" + ac.Student.Id + " '>Delete</a>";
                    row.Cells.Add(cell);
                    tableSort.Rows.Add(row);
                }
            }
        }            
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            //check if student number exists
            var student = (from st in entityContext.Students
                           where st.Id == studentNumberTxt.Text
                           select st).FirstOrDefault<Student>();

            if (student == null) //if student number is not found
            {
                //creating a new student and saving into database
                Student student1 = new Student();
                { student1.Id = studentNumberTxt.Text; student1.Name = studentNameTxt.Text; };
                entityContext.Students.Add(student1);
                entityContext.SaveChanges();

                //retrieving the course info from dropdown list
                var course = (from c in entityContext.Courses
                              where c.Code == DropDownList1.SelectedValue.ToString()
                              select c).FirstOrDefault<Course>();

                //creating academic records
                AcademicRecord academicRecord = new AcademicRecord();
                { academicRecord.Course = course; academicRecord.Student = student1; academicRecord.Grade = int.Parse(gradeTxt.Text); };

                //adding academic record to database:
                entityContext.AcademicRecords.Add(academicRecord);
                entityContext.SaveChanges();

                //clear form fields and redirecting to home page:
                studentNumberTxt.Text = "";
                studentNameTxt.Text = "";
                gradeTxt.Text = "";          
                Response.Redirect("AddStudent.aspx");
            }
            else //if student number already exists
            {
                if (Request.Params["action"] == "edit") //if user wants to change grade (edit)
                {
                    List<Student> stList = entityContext.Students.ToList<Student>();
                    student.Id = studentNumberTxt.Text;
                    var academicRecord = (from ac in entityContext.AcademicRecords
                                          where (ac.StudentId == student.Id &&
                                          ac.CourseCode == DropDownList1.SelectedValue)
                                          select ac).FirstOrDefault<AcademicRecord>();
                    academicRecord.Grade = int.Parse(gradeTxt.Text);

                    entityContext.SaveChanges();                    
                    studentNumberTxt.Text = "";
                    studentNumberTxt.Enabled = true;
                    studentNameTxt.Text = "";
                    studentNameTxt.Enabled = true;
                    gradeTxt.Text = "";
                    gradeTxt.Enabled = true;
                    DropDownList1.Enabled = true;
                    Response.Redirect("AddStudent.aspx");
                }
                else //if it's not editing
                {                
                    //checking if there is an academic record for student + course
                    var academicRecord = (from ac in entityContext.AcademicRecords
                                          where ac.StudentId == studentNumberTxt.Text && ac.Course.Code == DropDownList1.SelectedValue.ToString()
                                          select ac).FirstOrDefault<AcademicRecord>();
                
                    if (academicRecord == null) //if academicRecord for student + course is not found
                    {
                        //creating a new student
                        Student student1 = new Student();
                        { student1.Id = studentNumberTxt.Text; student1.Name = studentNameTxt.Text; };

                        //retrieving the course info from dropdown list
                        var course = (from c in entityContext.Courses
                                      where c.Code == DropDownList1.SelectedValue.ToString()
                                      select c).FirstOrDefault<Course>();                     

                        //creating academic records
                        AcademicRecord academicRecord1 = new AcademicRecord();
                        { academicRecord1.CourseCode = course.Code; academicRecord1.StudentId = student1.Id; academicRecord1.Grade = int.Parse(gradeTxt.Text); };

                        //adding academic record to database:
                        entityContext.AcademicRecords.Add(academicRecord1);
                        entityContext.SaveChanges();

                        //clear form fields:
                        studentNumberTxt.Text = "";
                        studentNameTxt.Text = "";
                        gradeTxt.Text = "";
                        Response.Redirect("AddStudent.aspx");
                    }
                    else //if there is an academic record with student number + course (display error)
                    {
                        spanNumber.InnerText = "The system already has records of this student for the selected course!";
                        //clear form fields:
                        studentNumberTxt.Text = "";
                        studentNameTxt.Text = "";
                        gradeTxt.Text = "";
                    }
                }
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //create session for selected course and empty fields every time dropdown list changes
        Session["selectedCourse"] = DropDownList1.SelectedValue.ToString();
        studentNumberTxt.Text = "";
        studentNameTxt.Text = "";
        gradeTxt.Text = "";
        spanNumber.InnerText = "";
    }
}