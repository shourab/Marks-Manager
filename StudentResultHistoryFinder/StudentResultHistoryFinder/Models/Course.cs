using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentResultHistoryFinder.Models
{
    public class Course:StudentInformation
    {
        public int CourseId { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }


        public double CourseCredit { get; set; }
    
    }
}