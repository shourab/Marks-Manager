using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class StudentInformationManager
    {
        StudentInformationGateway aStudentInformationGateway=new StudentInformationGateway();

        public string StudentInformationSave(StudentInformation aStudentInformation)
        {


            bool isStudentIdExists = aStudentInformationGateway.IsStudentIdExists(aStudentInformation);

            if (isStudentIdExists)
            {
                return "The Student Id Already Exists";
            }

            else
            {

                bool isEmailExist = aStudentInformationGateway.IsEmailExists(aStudentInformation);

                if (isEmailExist)
                {
                    return "Email Already Exists";
                }
                else
                {
                    int rowAffected = aStudentInformationGateway.NewRegistrationSave(aStudentInformation);

                    if (rowAffected > 0)
                    {
                        return "Student Information Saved successfully";
                    }
                    else
                    {
                        return "Save failed";
                    }
                }
                
            }
           
}



        public List<StudentInformation> ShowStudentInformations(string studentId)
        {
            return aStudentInformationGateway.ShowStudentInformations(studentId);
        }


    }
}