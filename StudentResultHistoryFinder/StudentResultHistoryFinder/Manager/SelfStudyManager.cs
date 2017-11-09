using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class SelfStudyManager
    {
        private SelfStudyGateway aSelfStudyGateway = new SelfStudyGateway();

        public string SelfStudyCourseSave(SelfStudyRegistration aSelfStudyRegistration)
        {
            bool isExist = aSelfStudyGateway.IsStudentExists(aSelfStudyRegistration);

            if (isExist)
            {
                int rowAffected = aSelfStudyGateway.SelfStudyCourseSave(aSelfStudyRegistration);

                if (rowAffected > 0)
                {
                    return "You have Successfully Registered with the Course";
                }
                else
                {
                    return "Sorry Your Registration have failed";
                }
            }


            else
            {
                return "Sorry Your Registration have failed.You may not be Enrolled this Course Before.So Enroll New Registration.";
            }
        }

        public List<SelfStudyRegistration> ShowSelfStudyRegistrationbyStudentId(string studentId)
        {
            return aSelfStudyGateway.ShowSelfStudyRegistrationbyStudentId(studentId);
        }

        public List<SelfStudyRegistration> StudentEnrollinParticularCourse(int courseId, string batch)
        {
            return aSelfStudyGateway.StudentEnrollinParticularCourse(courseId, batch);
        }
    }
}