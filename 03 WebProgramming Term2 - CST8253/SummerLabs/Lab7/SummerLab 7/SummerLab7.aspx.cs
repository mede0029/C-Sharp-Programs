using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SummerLab7 : System.Web.UI.Page
{
    List<Course> newCourseList = Helper.GetCourses();
    Student newStudent;
    protected void Page_Load(object sender, EventArgs e)
    {
        //printing available courses:
        if (!IsPostBack)
        {
            foreach (Course courseItem in newCourseList)
            {
                checkBoxLst.Items.Add(courseItem.ToString());
            }
        }
    }

    protected void studentNameTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void button_Click(object sender, EventArgs e)
    {
        //validating answers:
        if (studentNameTxt.Text.Trim() == "")
        {
            erroSpan.InnerText = "You must type the student name";
            return;
        }
        else
        {
            if (radioButtonLst.SelectedItem == null)
            {
                erroSpan.InnerText = "You must select the student type";
                return;
            }
            else
            {
                if (checkBoxLst.SelectedItem == null)
                {
                    erroSpan.InnerText = "You must select at list one course";
                    return;
                }
                else
                {
                    //creating the newS tudent:
                    switch (radioButtonLst.SelectedItem.Text)
                    {
                        case "Full-Time":
                            newStudent = new FullTimeStudent(studentNameTxt.Text);
                            break;
                        case "Part-Time":
                            newStudent = new PartTimeStudent(studentNameTxt.Text);
                            break;
                        case "Co-op":
                            newStudent = new CoopStudent(studentNameTxt.Text);
                            break;
                    }
                }
            }
        }
        try
        {
            //adding the selected courses to the newStudent:
            int d = checkBoxLst.Items.Count;
            for (int i = 0; i < d; i++)
            {
                if (checkBoxLst.Items[i].Selected)
                {
                    newStudent.addCourse(newCourseList[i]);
                }
            }
        }
        catch (Exception exception)
        {
            erroSpan.InnerText = exception.Message;
            return;
        }

        //changing forms:  
        form1.Visible = false;
        form2.Visible = true;
        spanName.InnerText = newStudent.Name; //displays name of student at the end
        spanType.InnerText = newStudent.ToString(); //displays type of student at the end


        //creating the table's body:
        foreach (Course item in newStudent.getEnrolledCourses())
        {
            TableRow tbRow = new TableRow(); //creating the rows
            TableCell tbCell = new TableCell(); //creating the cells

            tbCell.Text = item.Code; //adding the code to the cell
            tbRow.Cells.Add(tbCell); //creating the next cell in the row

            tbCell = new TableCell();
            tbCell.Text = item.Title; //adding the title to the cell
            tbRow.Cells.Add(tbCell); //creating the next cell in the row

            tbCell = new TableCell();
            tbCell.Text = item.WeeklyHours.ToString(); //adding the number or weekly hours to the cell
            tbRow.Cells.Add(tbCell); //creating the next cell in the row

            tbCell = new TableCell();
            tbCell.Text = item.Fee.ToString("C"); //adding the title to the cell
            tbRow.Cells.Add(tbCell); //creating the next cell in the row

            resultTable.Rows.Add(tbRow); //adding the rows to the table
        }

        if (radioButtonLst.SelectedItem.Text == "Co-op")
        {
            //adding Coop fee to the table:
            TableRow tbRow2 = new TableRow();
            TableCell tbCell2 = new TableCell();
            tbCell2.Text = "";
            tbRow2.Cells.Add(tbCell2);

            tbCell2 = new TableCell();
            tbCell2.Text = "Co-op Fee";
            tbRow2.Cells.Add(tbCell2);

            tbCell2 = new TableCell();
            tbCell2.Text = "";
            tbRow2.Cells.Add(tbCell2);

            tbCell2 = new TableCell();
            tbCell2.Text = (CoopStudent.COOP_FEE).ToString("C");
            tbRow2.Cells.Add(tbCell2);

            resultTable.Rows.Add(tbRow2);
        }

        //adding total to the table:
        TableRow tbRow1 = new TableRow();
        TableCell tbCell1 = new TableCell();
        tbCell1.Text = "";
        tbRow1.Cells.Add(tbCell1);

        tbCell1 = new TableCell();
        tbCell1.Text = "Total";
        tbRow1.Cells.Add(tbCell1);

        tbCell1 = new TableCell();
        tbCell1.Text = newStudent.totalWeeklyHours().ToString();
        tbRow1.Cells.Add(tbCell1);

        tbCell1 = new TableCell();
        tbCell1.Text = newStudent.feePayable().ToString("C");
        tbRow1.Cells.Add(tbCell1);

        resultTable.Rows.Add(tbRow1);
    }
}