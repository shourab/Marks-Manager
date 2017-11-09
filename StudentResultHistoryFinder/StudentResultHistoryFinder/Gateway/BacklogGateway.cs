using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class BacklogGateway:Gateway
    {
        public int BacklogCourseSave(BacklogRegistration aBacklogRegistration)
        {


            Query = "INSERT INTO BacklogRegistration VALUES (@sid,@cid, @batch)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("sid", SqlDbType.VarChar);
            Command.Parameters["sid"].Value = aBacklogRegistration.StudentId;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = aBacklogRegistration.CourseId;

            Command.Parameters.Add("batch", SqlDbType.VarChar);
            Command.Parameters["batch"].Value = aBacklogRegistration.BacklogBatch;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsStudentExists(BacklogRegistration aBacklogRegistration)
        {
            Query = "SELECT * FROM EnrollCourse WHERE EnrollCourse.StudentId='" + aBacklogRegistration.StudentId +
                    "' AND EnrollCourse.courseid='" + aBacklogRegistration.CourseId + "'";


            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;
}


        public int UpdateCTAttendanceStatus(BacklogRegistration aBacklogRegistration)
        {
            Query = "UPDATE InputCTAttendence SET CT1='0',CT2='0',CT3='0',CT4='0',CT5='0',Attendence='0' WHERE InputCTAttendence.courseid='" +aBacklogRegistration.CourseId + "' AND InputCTAttendence.StudentId='"+aBacklogRegistration.StudentId+"'";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;


        }




        public List<BacklogRegistration> ShowBacklogRegistrationbyStudentId(string studentId)
        {
            Query = "SELECT * FROM BacklogRegistration,Course WHERE BacklogRegistration.StudentId='" + studentId + "' AND Course.CourseId=BacklogRegistration.courseid";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<BacklogRegistration> backlogInformation = new List<BacklogRegistration>();

            while (Reader.Read())
            {
                BacklogRegistration aBacklogStudentInformation = new BacklogRegistration();

                aBacklogStudentInformation.BacklogRegistrationId = (int)Reader["BacklogRegistrationId"];
                aBacklogStudentInformation.StudentId = Reader["StudentId"].ToString();
                aBacklogStudentInformation.CourseId = (int)Reader["courseid"];
               aBacklogStudentInformation.BacklogBatch = Reader["BacklogBatch"].ToString();
               aBacklogStudentInformation.CourseCode = Reader["CourseCode"].ToString();
              aBacklogStudentInformation.CourseName = Reader["CourseName"].ToString();
               aBacklogStudentInformation.CourseCredit = Convert.ToDouble(Reader["CourseCredit"]);

                backlogInformation.Add(aBacklogStudentInformation);

            }

            Reader.Close();
            Connection.Close();

            return backlogInformation;
        }


        public List<BacklogRegistration> StudentEnrollinParticularCourse(int courseId, string batch)
        {
           
            Query = "SELECT * FROM BacklogRegistration,StudentInformation  WHERE courseid='" + courseId + "' AND BacklogBatch='" + batch +"' AND BacklogRegistration.StudentId=StudentInformation.StudentId";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();

            Reader = Command.ExecuteReader();

            List<BacklogRegistration> aBacklogRegistrations = new List<BacklogRegistration>();

            while (Reader.Read())
            {
               BacklogRegistration aBacklogRegistration=new BacklogRegistration();

                aBacklogRegistration.StudentId = Reader["StudentId"].ToString();
                aBacklogRegistration.StudentName = Reader["StudentName"].ToString();

                aBacklogRegistrations.Add(aBacklogRegistration);

            }

            Reader.Close();
            Connection.Close();

            return aBacklogRegistrations;
        }

    }
}