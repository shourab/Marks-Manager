using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class BacklogManager
    {
        BacklogGateway aBacklogGateway=new BacklogGateway();

        public string BacklogCourseSave(BacklogRegistration aBacklogRegistration)
        {

            bool isExist = aBacklogGateway.IsStudentExists(aBacklogRegistration);

            if (isExist)
            {
                int updateCTAttendance =aBacklogGateway.UpdateCTAttendanceStatus(aBacklogRegistration);
                
                int rowAffected = aBacklogGateway.BacklogCourseSave(aBacklogRegistration);

                if (rowAffected > 0)
                {
                    return "You have Successfully Registered with the Course";
                }
                else
                {
                    return "Sorry Your Registration have failed.";
                }

            }
            else
            {
                return
                    "Sorry Your Registration have failed.You may not be Enrolled this Course Before.So Enroll New Registration.";
            }

        }

        public List<BacklogRegistration> ShowBacklogRegistrationbyStudentId(string studentId)
        {
            return aBacklogGateway.ShowBacklogRegistrationbyStudentId(studentId);
        }

        public List<BacklogRegistration> StudentEnrollinParticularCourse(int courseId, string batch)
        {
            return aBacklogGateway.StudentEnrollinParticularCourse(courseId, batch);
        }
    }
}