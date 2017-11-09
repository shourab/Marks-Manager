using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class StudentInformationGateway:Gateway
    {

        public int NewRegistrationSave(StudentInformation aStudentInformation)
        {
          

            Query = "INSERT INTO StudentInformation VALUES (@name, @id, @email,@bloodgroup)";

             Command = new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aStudentInformation.StudentName;
            Command.Parameters.Add("id", SqlDbType.VarChar);
            Command.Parameters["id"].Value = aStudentInformation.StudentId;
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = aStudentInformation.StudentEmail;
            Command.Parameters.Add("bloodGroup", SqlDbType.VarChar);
            Command.Parameters["bloodGroup"].Value = aStudentInformation.BloodGroup;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

           Connection.Close();

            return rowAffected;
        }


        public bool IsEmailExists(StudentInformation aStudentInformation )
        {

            Query = "SELECT * FROM StudentInformation WHERE StudentEmail = '" + aStudentInformation.StudentEmail + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;




        }



        public bool IsStudentIdExists(StudentInformation aStudentInformation)
        {

            Query = "SELECT * FROM StudentInformation WHERE StudentId = '" + aStudentInformation.StudentId + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;




        }



        public List<StudentInformation> ShowStudentInformations(string studentId)
        {
            Query = "SELECT * FROM StudentInformation WHERE StudentId='"+studentId+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<StudentInformation> informations = new List<StudentInformation>();

            while (Reader.Read())
            {
                StudentInformation aStudentInformation = new StudentInformation();

                aStudentInformation.StudentInformationId = (int)Reader["StudentInformationId"];
                aStudentInformation.StudentName = Reader["StudentName"].ToString();
                aStudentInformation.StudentId = Reader["StudentId"].ToString();
                aStudentInformation.StudentEmail = Reader["StudentEmail"].ToString();
                aStudentInformation.BloodGroup = Reader["BloodGroup"].ToString();
                

                informations.Add(aStudentInformation);
            }

            Reader.Close();
            Connection.Close();

            return informations;
        }

        }



    }
