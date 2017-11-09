using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentResultHistoryFinder.Manager;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Controllers
{
    public class ShowAllStudentInformationController : Controller
    {
        //
        // GET: /ShowAllStudentInformation/
        public ActionResult Index()
        {
            return View();
        }

        private StudentInformationManager aStudentInformationManager = new StudentInformationManager();
        private EnrollCourseManager aEnrollCourseManager = new EnrollCourseManager();
        private SelfStudyManager aSelfStudyManager = new SelfStudyManager();
        private BacklogManager aBacklogManager = new BacklogManager();
        private CourseManager aCourseManager=new CourseManager();

        public ActionResult ShowStudentInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowStudentInformation(string studentId)
        {
            List<StudentInformation> informations =
                aStudentInformationManager.ShowStudentInformations(studentId).ToList();
            ViewBag.studentSearch = informations;
            return View();

        }

        public ActionResult ShowStudentEnrollCourseInformation()
        {
            List<EnrollCourse> allLevelTerm = GetAllLevelTerm();
            ViewBag.levelTerm = allLevelTerm;
            return View();

        }

        [HttpPost]
        public ActionResult ShowStudentEnrollCourseInformation(string studentId, string levelTerm)
        {
            List<EnrollCourse> enrollCourses =
                aEnrollCourseManager.ShowEnrollCourseInformationsByUsingTerm(studentId, levelTerm).ToList();
            ViewBag.enrollCourse = enrollCourses;

            List<EnrollCourse> allLevelTerm = GetAllLevelTerm();
            ViewBag.levelTerm = allLevelTerm;



            return View();

        }


        public ActionResult ShowSelfStudyRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowSelfStudyRegistration(string studentId)
        {
            List<SelfStudyRegistration> aSelfStudyStudentInformation =
                aSelfStudyManager.ShowSelfStudyRegistrationbyStudentId(studentId);

            ViewBag.information = aSelfStudyStudentInformation;
            return View();
        }

        public ActionResult ShowBacklogRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowBacklogRegistration(string studentId)
        {

            List<BacklogRegistration> aBacklogStudentInformation =

                aBacklogManager.ShowBacklogRegistrationbyStudentId(studentId);

            ViewBag.information = aBacklogStudentInformation;

            return View();
        }

        public ActionResult ShowStudentRegistrationinParticularCourse()
        {
            List<Course> aCourse = aCourseManager.GetAllCourses();
            ViewBag.courses = aCourse;
            return View();
        }
        
        [HttpPost]
        public ActionResult ShowStudentRegistrationinParticularCourse(int courseId,string batch)
        {
            List<Course> aCourse = aCourseManager.GetAllCourses();
            ViewBag.courses = aCourse;

            List<EnrollCourse> aEnrollCourse = aEnrollCourseManager.StudentEnrollinParticularCourse(courseId, batch);
            ViewBag.enrollCourses = aEnrollCourse;

            List<BacklogRegistration> aBacklogRegistrations = aBacklogManager.StudentEnrollinParticularCourse(courseId, batch);
            ViewBag.backlogEnrollCourses = aBacklogRegistrations;

            List<SelfStudyRegistration> aSelfStudyRegistrations = aSelfStudyManager.StudentEnrollinParticularCourse(courseId, batch);
            ViewBag.selfStudyEnrollCourses = aSelfStudyRegistrations;

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



    
    }
}