using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace AcademicLeaveManagement
{
    public partial class _Default : Page
    {
        static List<Leave> records = new List<Leave>();

        public class Leave
        {
            public string Student { get; set; }
            public string Type { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Reason { get; set; }
            public string Status { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Student"] != null)
                    lblWelcome.Text = "Welcome " + Session["Student"];
                else if (Request.Cookies["Student"] != null)
                    txtName.Text = Request.Cookies["Student"].Value;

                BindLeaves();
            }
        }

        protected void btnSession_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                lblWelcome.Text = "Enter your name first.";
                return;
            }

            Session["Student"] = txtName.Text.Trim();
            lblWelcome.Text = "Welcome " + Session["Student"];
        }

        protected void btnCookie_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                lblWelcome.Text = "Enter your name first.";
                return;
            }

            HttpCookie cookie = new HttpCookie("Student", txtName.Text.Trim());
            cookie.Expires = DateTime.Now.AddDays(30);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);

            lblWelcome.Text = "Name saved in cookie.";
        }

        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = "Selected date: " +
                calDate.SelectedDate.ToString("dd-MM-yyyy");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            DateTime start, end;

            if (Session["Student"] == null)
            {
                lblMessage.Text = "Start a session first.";
                return;
            }

            if (!DateTime.TryParse(txtFrom.Text, out start) ||
                !DateTime.TryParse(txtTo.Text, out end) ||
                end.Date < start.Date || txtReason.Text.Trim() == "")
            {
                lblMessage.Text = "Enter valid dates and reason.";
                return;
            }

            records.Add(new Leave
            {
                Student = Session["Student"].ToString(),
                Type = ddlType.SelectedValue,
                From = start.ToString("dd-MM-yyyy"),
                To = end.ToString("dd-MM-yyyy"),
                Reason = txtReason.Text.Trim(),
                Status = "Pending"
            });

            lblMessage.Text = "Leave submitted successfully. Status: Pending.";
            BindLeaves();
        }

        private void BindLeaves()
        {
            gvLeaves.DataSource = records;
            gvLeaves.DataBind();
        }
    }
}
