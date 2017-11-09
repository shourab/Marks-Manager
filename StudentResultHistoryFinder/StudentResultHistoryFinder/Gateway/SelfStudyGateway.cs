using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class SelfStudyGateway:Gateway
    {
        public int SelfStudyCourseSave(SelfStudyRegistration aSelfStudyRegistration)
        {


            Query = "INSERT INTO SelfStudyRegistration VALUES (@sid,@cid, @batch)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("sid", SqlDbType.VarChar);
            Command.Parameters["sid"].Value = aSelfStudyRegistration.StudentId;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = aSelfStudyRegistration.CourseId;

            Command.Parameters.Add("batch", SqlDbType.VarChar);
            Command.Parameters["batch"].Value = aSelfStudyRegistration.SelfStudyBatch;





            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsStudentExists(SelfStudyRegistration aSelfStudyRegistration)
        {
            Query = "SELECT * FROM EnrollCourse WHERE EnrollCourse.StudentId='" + aSelfStudyRegistration.StudentId +
                    "' AND EnrollCourse.courseid='" + aSelfStudyRegistration.CourseId + "'";


            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;
        
        
        
        }


        public List<SelfStudyRegistration> ShowSelfStudyRegistrationbyStudentId(string studentId)
        {
            Query = "SELECT * FROM SelfStudyRegistration,Course WHERE SelfStudyRegistration.StudentId='" + studentId + "' AND Course.CourseId=SelfStudyRegistration.courseid";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<SelfStudyRegistration> selfStudyInformation = new List<SelfStudyRegistration>();

            while (Reader.Read())
            {
                SelfStudyRegistration aselfStudyStudentInformation=new SelfStudyRegistration();

                aselfStudyStudentInformation.SelfStudyId = (int) Reader["SelfStudyId"];
                aselfStudyStudentInformation.StudentId = Reader["StudentId"].ToString();
                aselfStudyStudentInformation.CourseId = (int) Reader["courseid"];
                aselfStudyStudentInformation.SelfStudyBatch = Reader["SelfStudyBatch"].ToString();
                aselfStudyStudentInformation.CourseCode = Reader["CourseCode"].ToString();
                aselfStudyStudentInformation.CourseName = Reader["CourseName"].ToString();
                aselfStudyStudentInformation.CourseCredit = Convert.ToDouble(Reader["CourseCredit"]);

                selfStudyInformation.Add(aselfStudyStudentInformation);

            }

            Reader.Close();
            Connection.Close();

            return selfStudyInformation;
        }

        public List<SelfStudyRegistration> StudentEnrollinParticularCourse(int courseId, string batch)
        {
          

            Query = "SELECT * FROM SelfStudyRegistration,StudentInformation WHERE courseid='" + courseId + "' AND SelfStudyBatch='" + batch +
                    "' AND SelfStudyRegistration.StudentId=StudentInformation.StudentId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<SelfStudyRegistration> aSelfStudyRegistrations = new List<SelfStudyRegistration>();

            while (Reader.Read())
            {
               SelfStudyRegistration aSelfStudyRegistration=new SelfStudyRegistration();


                aSelfStudyRegistration.StudentId = Reader["StudentId"].ToString();
                aSelfStudyRegistration.StudentName = Reader["StudentName"].ToString();

                aSelfStudyRegistrations.Add(aSelfStudyRegistration);

            }

            Reader.Close();
            Connection.Close();

            return aSelfStudyRegistrations;
        }

    }
}