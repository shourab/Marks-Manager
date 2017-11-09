using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentResultHistoryFinder.Manager;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Controllers
{
      public class NewRegistrationController : Controller
    {
        //
        // GET: /NewRegistration/

          CourseManager aCourseManager = new CourseManager();
          SelfStudyManager aSelfStudyManager=new SelfStudyManager();
          BacklogManager aBacklogManager=new BacklogManager();
          
          
          public ActionResult Index()
        {
            return View();
        }
	
    
       StudentInformationManager aStudentInformationManager=new StudentInformationManager();

        public  ActionResult NewRegistrationSave()
        {
            List<StudentInformation> bloodGroups = GetAllBloodGroup();
            ViewBag.bloodGroups = bloodGroups.ToList();
            

            return View();
        }
        [HttpPost]
        public ActionResult NewRegistrationSave(StudentInformation aStudentInformation)
        {

            List<StudentInformation> bloodGroups = GetAllBloodGroup();
            ViewBag.bloodGroups = bloodGroups.ToList();
            ViewBag.Message = aStudentInformationManager.StudentInformationSave(aStudentInformation);

            return View();

        }

        public ActionResult SelfStudyRegistration()
        {
            ViewBag.getCourse = aCourseManager.GetAllCourses().ToList();
            return View();
        }

        [HttpPost]

        public ActionResult SelfStudyRegistration(SelfStudyRegistration aSelfStudyRegistration)
        {
            ViewBag.message = aSelfStudyManager.SelfStudyCourseSave(aSelfStudyRegistration);
            ViewBag.getCourse = aCourseManager.GetAllCourses().ToList();
            return View();
        }


        private List<StudentInformation> GetAllBloodGroup()
        {
            List<StudentInformation> bloodGroups = new List<StudentInformation>()
            {
                new StudentInformation(){BloodGroup = "A+"},
                new StudentInformation(){BloodGroup = "A-"},
                new StudentInformation(){BloodGroup = "B+"},
                new StudentInformation(){BloodGroup = "AB+"},
                new StudentInformation(){BloodGroup = "AB-"},
                new StudentInformation(){BloodGroup = "B-"},
                new StudentInformation(){BloodGroup = "O+"},
                new StudentInformation(){BloodGroup = "O-"},
               
               
            };

          
            return bloodGroups;
        }

        public ActionResult BacklogRegistration()
        {
           
            ViewBag.getCourse = aCourseManager.GetAllCourses().ToList();
            return View();
        }

        [HttpPost]

        public ActionResult BacklogRegistration(BacklogRegistration aBacklogRegistration)
        {
            ViewBag.message = aBacklogManager.BacklogCourseSave(aBacklogRegistration);
            ViewBag.getCourse = aCourseManager.GetAllCourses().ToList();
            return View();
        }








        public List<Course> GetAllCourse()
        {
            return aCourseManager.GetAllCourses();
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