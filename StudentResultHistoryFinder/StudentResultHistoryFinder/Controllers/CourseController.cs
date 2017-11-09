using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentResultHistoryFinder.Manager;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        public ActionResult Index()
        {
            return View();
        }

        private CourseManager aCourseManager = new CourseManager();

        EnrollCourseManager aEnrollCourseManager=new EnrollCourseManager();

        public ActionResult SaveCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            ViewBag.Message = aCourseManager.NewCourseSave(aCourse);
            return View();
        }


        public ActionResult EnrollCourseSave()
        {
            ViewBag.levelTerm = GetAllLevelTerm().ToList();
            ViewBag.getCourse = aCourseManager.GetAllCourses().ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult EnrollCourseSave(EnrollCourse aEnrollCourse)
        {
            ViewBag.LevelTerm = GetAllLevelTerm().ToList();
            ViewBag.getCourse = aCourseManager.GetAllCourses().ToList();

            ViewBag.message=aEnrollCourseManager.EnrollCourseSave(aEnrollCourse);


            return View();
        }

        private List<EnrollCourse> GetAllLevelTerm()
        {
            List<EnrollCourse> allLevelTerm = new List<EnrollCourse>()
            {
                new EnrollCourse() {LevelTerm = "1-1"},
                new EnrollCourse() {LevelTerm = "1-2"},
                new EnrollCourse() {LevelTerm = "2-1"},
                new EnrollCourse() {LevelTerm = "2-2"},
                new EnrollCourse() {LevelTerm = "3-1"},
                new EnrollCourse() {LevelTerm = "3-2"},
                new EnrollCourse() {LevelTerm = "4-1"},
                new EnrollCourse() {LevelTerm = "4-2"},
                new EnrollCourse() {LevelTerm = "5-1"},
                new EnrollCourse() {LevelTerm = "5-2"},

            };


            return allLevelTerm;
        }


        public List<Course> GetAllCourse()
        {
                 return  aCourseManager.GetAllCourses();
        }


        

        public JsonResult GetCourseNameByCourseId(int courseId)
        {
            var course = GetAllCourse();

            var specificCourseName = course.Where(a => a.CourseId == courseId).ToList();

            return Json(specificCourseName);
        }

        public JsonResult GetCourseCreditByCourseId(int courseId)
        {
            var course = GetAllCourse();

            var courseCredit = course.Where(a => a.CourseId == courseId).ToList();

            return Json(courseCredit);
        }


}
}