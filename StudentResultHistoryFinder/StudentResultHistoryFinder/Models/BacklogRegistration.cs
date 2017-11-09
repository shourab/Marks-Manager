using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentResultHistoryFinder.Models
{
    public class BacklogRegistration:Course
    {
        public int BacklogRegistrationId { get; set; }

        public string StudentId { get; set; }

        public int CourseId { get; set; }

        public string BacklogBatch { get; set; }
    }
}