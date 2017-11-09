using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentResultHistoryFinder.Models
{
    public class StudentInformation
    {
        public int  StudentInformationId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }

        public string BloodGroup { get; set; }


    }
}