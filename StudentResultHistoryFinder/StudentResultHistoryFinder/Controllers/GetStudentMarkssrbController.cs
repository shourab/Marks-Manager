using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentResultHistoryFinder.Manager;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Controllers
{
    public class GetStudentMarkssrbController : Controller
    {
        //
        // GET: /GetStudentMarkssrb/
        public ActionResult IndividulaResult(string StudentId, string courseID)
        {
            MarksManagersrb aManagersrb=new MarksManagersrb();
            CourseManagersrb aCourseManagersrb = new CourseManagersrb();
            ViewBag.courses = aCourseManagersrb.Getallcourse();
            StudentMarks aMarks = aManagersrb.AMarks(courseID, StudentId);
            ViewBag.marks = aMarks;
            return View();
        }

        public ActionResult AllstudentResult(string courseId, string batch)
        {
            MarksManagersrb aManagersrb = new MarksManagersrb();
            CourseManagersrb aCourseManagersrb = new CourseManagersrb();
            ViewBag.courses = aCourseManagersrb.Getallcourse();
            List<StudentMarks> allstudents = aManagersrb.GetAllMarks(courseId, batch);
            ViewBag.list = allstudents;
            return View();
        }
	}
}