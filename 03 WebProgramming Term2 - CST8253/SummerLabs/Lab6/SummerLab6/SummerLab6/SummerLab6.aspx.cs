using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SummerLab6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            try
            {
                //calc maximum number:
                int maxValue = 0;
                if (int.Parse(firstTextBox.Text) > maxValue)
                {
                    maxValue = int.Parse(firstTextBox.Text);
                }
                if (int.Parse(secondTextBox.Text) > maxValue)
                {
                    maxValue = int.Parse(secondTextBox.Text);
                }
                if (int.Parse(thirdTextBox.Text) > maxValue)
                {
                    maxValue = int.Parse(thirdTextBox.Text);
                }
                maximum.Text = $"Maximum number typed: {maxValue}";
                errorMsg.Text = " ";

                //calc minimum number:
                int minValue = maxValue;
                if (int.Parse(firstTextBox.Text) < minValue)
                {
                    minValue = int.Parse(firstTextBox.Text);
                }
                if (int.Parse(secondTextBox.Text) < minValue)
                {
                    minValue = int.Parse(secondTextBox.Text);
                }
                if (int.Parse(thirdTextBox.Text) < minValue)
                {
                    minValue = int.Parse(thirdTextBox.Text);
                }
                minimum.Text = $"Minimum number typed: {minValue}";
                errorMsg.Text = " ";

                //calc total:
                int total = (int.Parse(firstTextBox.Text) + int.Parse(secondTextBox.Text) + int.Parse(thirdTextBox.Text));
                totalLbl.Text = $"The sum of all numbers typed was: {total}";
                errorMsg.Text = " ";

                //calc average
                int average = total / 3;
                averageLbl.Text = $"The average of all numbers typed was: {average}";
                errorMsg.Text = " ";
            }
            catch
            {
                errorMsg.Text = "Input string was not in a correct format! Please try again.";
            }
        }
    }
}