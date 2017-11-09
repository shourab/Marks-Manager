using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class EnrollCourseGateway : Gateway
    {
        public int NewEnrollCourseSave(EnrollCourse aEnrollCourse)
        {


            Query = "INSERT INTO EnrollCourse VALUES (@sid,@cid, @level,@batch)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("sid", SqlDbType.VarChar);
            Command.Parameters["sid"].Value = aEnrollCourse.StudentId;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = aEnrollCourse.CourseId;


            Command.Parameters.Add("level", SqlDbType.VarChar);
            Command.Parameters["level"].Value = aEnrollCourse.LevelTerm;

            Command.Parameters.Add("batch", SqlDbType.VarChar);
            Command.Parameters["batch"].Value = aEnrollCourse.Batch;





            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<EnrollCourse> ShowEnrollCourseInformationsByUsingTerm(string studentId, string levelTerm)
        {
            Query = "SELECT * FROM EnrollCourse,Course WHERE EnrollCourse.StudentId='" + studentId +
                    "' AND EnrollCourse.LevelTerm='" + levelTerm + "' AND EnrollCourse.courseid=Course.CourseId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<EnrollCourse> aEnrollCourses = new List<EnrollCourse>();

            while (Reader.Read())
            {
                EnrollCourse aEnrollCourse = new EnrollCourse();

                aEnrollCourse.EnrollCourseId = (int) Reader["EnrollCourseId"];
                aEnrollCourse.StudentId = Reader["StudentId"].ToString();
                aEnrollCourse.CourseId = (int) Reader["CourseId"];
                aEnrollCourse.LevelTerm = Reader["LevelTerm"].ToString();
                aEnrollCourse.Batch = Reader["Batch"].ToString();
                aEnrollCourse.CourseCode = Reader["CourseCode"].ToString();
                aEnrollCourse.CourseName = Reader["CourseName"].ToString();
                aEnrollCourse.CourseCredit = Convert.ToDouble(Reader["CourseCredit"]);


                aEnrollCourses.Add(aEnrollCourse);
            }

            Reader.Close();
            Connection.Close();

            return aEnrollCourses;
        }

        public List<EnrollCourse> StudentEnrollinParticularCourse(int courseId, string batch)
        {
            Query = "SELECT * FROM EnrollCourse,StudentInformation WHERE courseid='" + courseId + "' AND Batch='" + batch + "' AND EnrollCourse.StudentId=StudentInformation.StudentId";

            Command = new SqlCommand(Query, Connection);

          
            
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<EnrollCourse> aEnrollCourses = new List<EnrollCourse>();

            while (Reader.Read())
            {
                EnrollCourse aEnrollCourse = new EnrollCourse();


                aEnrollCourse.StudentId = Reader["StudentId"].ToString();
                aEnrollCourse.StudentName = Reader["StudentName"].ToString();
               
                aEnrollCourses.Add(aEnrollCourse);

                }

            Reader.Close();
            Connection.Close();

            return aEnrollCourses;
        }
    }
}