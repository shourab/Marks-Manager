using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentResultHistoryFinder.Models
{
    public class SelfStudyRegistration:Course
    {
        public int SelfStudyId { get; set; }

        public string StudentId { get; set; }

        public int CourseId { get; set; }

        public string SelfStudyBatch { get; set; }
    }
}