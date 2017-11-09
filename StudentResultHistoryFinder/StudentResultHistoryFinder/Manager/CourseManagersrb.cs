using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class CourseManagersrb
    {
        public List<Studentsinfosrb> GetStudents(int batch, int courseid)
        {
            CourseGatewaysrb aCourseGatewaysrb=new CourseGatewaysrb();
            List<Studentsinfosrb> students=new List<Studentsinfosrb>();
           students= aCourseGatewaysrb.GetStudent(batch, courseid);
            return students;
        }

        public List<Coursesrb> Getallcourse()
        {

            CourseGatewaysrb aCourseGatewaysrb = new CourseGatewaysrb();
            List<Coursesrb> courses = aCourseGatewaysrb.Getallcourse();
            return courses;
        } 
    }
}