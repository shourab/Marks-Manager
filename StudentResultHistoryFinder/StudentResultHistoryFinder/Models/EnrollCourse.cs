using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentResultHistoryFinder.Models
{
    public class EnrollCourse:Course
    {
        public int EnrollCourseId { get; set; }

        

        public string StudentId { get; set; }

        
        public int CourseId { get; set; }
        
        public string LevelTerm { get; set; }

        public string Batch { get; set; }

       






    }
}