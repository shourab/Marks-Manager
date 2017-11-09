using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class CourseManager
    {
        private CourseGateway aCourseGateway = new CourseGateway();

        public string NewCourseSave(Course aCourse)
        {


            bool isCourseCodeExists = aCourseGateway.IsCourseCodeExists(aCourse);

            if (isCourseCodeExists)
            {
                return "The Course Code Already Exists";
            }

            else
            {

                bool isCourseNameExists = aCourseGateway.IsCourseNameExists(aCourse);

                if (isCourseNameExists)
                {
                    return "Course Name Already Exists";
                }
                else
                {
                    int rowAffected = aCourseGateway.NewCourseSave(aCourse);

                    if (rowAffected > 0)
                    {
                        return "New Course Added Successfully";
                    }
                    else
                    {
                        return " Course Save failed";
                    }
                }

            }


        }

        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }
    }
}