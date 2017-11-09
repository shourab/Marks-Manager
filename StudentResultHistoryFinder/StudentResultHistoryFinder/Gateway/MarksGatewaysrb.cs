using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class MarksGatewaysrb
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentsResultHistoryDBConnectionString"].ConnectionString;
        public string Insertmarks(string Studentid, string courseId, string marksfor, string Marks)
        {
            string query;

            int courseid2 = Convert.ToInt32(courseId);
           bool Isexist= CheckMarks(Studentid, courseId);
            SqlConnection connection = new SqlConnection(connectionString);
            if (Isexist)
            {
                query = "UPDATE InputCTAttendence SET " + marksfor + "=" + Marks + " WHERE StudentId='" + Studentid + "' AND courseid='" + courseid2 + "'"; 
            }
            else
            {
                query = "INSERT INTO InputCTAttendence(StudentId,courseid," + marksfor + ") VALUES('" + Studentid +   "','" + courseid2 + "','" + Marks + "')";
            }
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
           int rowaffected= command.ExecuteNonQuery();
            if (rowaffected!=null)
            {
                return "Saved successfully";
            }
            else
            {
                return "Save Failed";
            }
        }

        public bool CheckMarks(string Studentid, string courseid)
        {
            int courseid2 = Convert.ToInt32(courseid);

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT* FROM InputCTAttendence WHERE StudentId='" + Studentid + "' AND courseid='" +courseid2 + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                return true;
            }


            else
            {
                reader.Close();
                connection.Close();
                return false;
            }
        }

        public StudentMarks GetNumber(string courseId, string StudentId)
        {
            StudentMarks aMarks=new StudentMarks();
            int courseid2 = Convert.ToInt32(courseId);

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT* FROM InputCTAttendence WHERE StudentId='" + StudentId + "' AND courseid='" + courseid2 + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                aMarks.CT1 = reader["CT1"].ToString();
                aMarks.CT2 = reader["CT2"].ToString();
                aMarks.CT3 = reader["CT3"].ToString();
                aMarks.CT4 = reader["CT4"].ToString();
                aMarks.Attendance = reader["Attendence"].ToString();
            }
            reader.Close();
            connection.Close();
            return aMarks;
        }
        public List<StudentMarks> GetAllMarks(string courseId, string batch)
        {
            List<StudentMarks> aList=new List<StudentMarks>();
           
            int courseid2 = Convert.ToInt32(courseId);

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT EnrollCourse.StudentId,EnrollCourse.courseid,EnrollCourse.Batch,InputCTAttendence.CT1,InputCTAttendence.CT2,InputCTAttendence.CT3,InputCTAttendence.CT4,InputCTAttendence.Attendence FROM EnrollCourse INNER JOIN InputCTAttendence ON InputCTAttendence.StudentId=EnrollCourse.StudentId AND InputCTAttendence.courseid=EnrollCourse.courseid AND InputCTAttendence.courseid='"+courseId+"' AND EnrollCourse.Batch='"+batch+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentMarks aMarks = new StudentMarks();
                aMarks.StudentId = reader["StudentId"].ToString();
                aMarks.CT1 = reader["CT1"].ToString();
                aMarks.CT2 = reader["CT2"].ToString();
                aMarks.CT3 = reader["CT3"].ToString();
                aMarks.CT4 = reader["CT4"].ToString();
                aMarks.Attendance = reader["Attendence"].ToString();
                aList.Add(aMarks);
            }
            reader.Close();
            connection.Close();
            return aList;
        }
    }
}