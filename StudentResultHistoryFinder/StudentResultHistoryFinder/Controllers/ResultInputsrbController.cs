using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentResultHistoryFinder.Models;
using StudentResultHistoryFinder.Manager;

namespace StudentResultHistoryFinder.Controllers
{
    public class ResultInputsrbController : Controller
    {
        //
        // GET: /ResultInputsrb/
        public ActionResult Students(String batch, String courseid, string Marksfor)

        {
            ViewBag.batch = batch;
            ViewBag.marksfor = Marksfor;
            CourseManagersrb aCourseManagersrb=new CourseManagersrb();
            int batch2 = Convert.ToInt32(batch);
            int courseid2 = Convert.ToInt32(courseid);
           ViewBag.students = aCourseManagersrb.GetStudents(batch2, courseid2);
          
            return View();
        }
        [HttpPost]
        public ActionResult Students(string StudentId, string courseid, string Marksfor, string Marks,string batch)
        {
            MarksManagersrb aMarksManagersrb=new MarksManagersrb();
            ViewBag.Message = aMarksManagersrb.InsertMarks(StudentId, courseid, Marksfor, Marks);

            ViewBag.batch = batch;
            ViewBag.marksfor = Marksfor;
            CourseManagersrb aCourseManagersrb = new CourseManagersrb();
            int batch2 = Convert.ToInt32(batch);
            int courseid2 = Convert.ToInt32(courseid);
            ViewBag.students = aCourseManagersrb.GetStudents(batch2, courseid2);

            return View();
        }

        public ActionResult SearchStudent(string batch, string course, string stage)
        {
              CourseManagersrb aCourseManagersrb=new CourseManagersrb();
            ViewBag.courses = aCourseManagersrb.Getallcourse();
            return View();
        }
    }
}