using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Gateway;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Manager
{
    public class MarksManagersrb
    {
        MarksGatewaysrb aMarksGatewaysrb=new MarksGatewaysrb();

        public string InsertMarks(string Studentid, string courseId, string marksfor, string Marks)
        {
            string message = aMarksGatewaysrb.Insertmarks(Studentid, courseId, marksfor, Marks);
            return message;
        }

        public StudentMarks AMarks(string courseID, string StudentId)
        {
            StudentMarks aMarks = aMarksGatewaysrb.GetNumber(courseID, StudentId);
            return aMarks;
        }

        public List<StudentMarks> GetAllMarks(string courseId, string batch)
        {
            List<StudentMarks> aList = aMarksGatewaysrb.GetAllMarks(courseId, batch);
            return aList;
        } 
    }
    
}