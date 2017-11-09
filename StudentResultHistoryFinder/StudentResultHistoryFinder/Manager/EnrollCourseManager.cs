using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway aEnrollCourseGateway=new EnrollCourseGateway();

        public string EnrollCourseSave(EnrollCourse aEnrollCourse)
        {
            
                  int rowAffected = aEnrollCourseGateway.NewEnrollCourseSave(aEnrollCourse);

                    if (rowAffected > 0)
                    {
                        return "You have Successfully Enrolled the Course ";
                    }
                    else
                    {
                        return " Sorry Course Save Failed";
                    }
             
        
        
        }



        public List<EnrollCourse> ShowEnrollCourseInformationsByUsingTerm(string studentId, string levelTerm)
        {
            return aEnrollCourseGateway.ShowEnrollCourseInformationsByUsingTerm(studentId, levelTerm);
        }

        public List<EnrollCourse> StudentEnrollinParticularCourse(int courseId, string batch)
        {
            return aEnrollCourseGateway.StudentEnrollinParticularCourse(courseId, batch);
        }

    }
    }
