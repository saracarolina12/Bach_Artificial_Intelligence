using System;
using System.Collections.Generic;

namespace AlumniApp
{
    public class students
    {
        public int id { get; set; }
        public string name { get; set; }
        public string career { get; set; }
        public int birthYear { get; set; }
        public string hometown { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int subjectID { get; set; }
        public List<int> grades { get; set; }
    }
    public class teachers
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subjectID { get; set; }
        public int birthYear { get; set; }
        public string hometown { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
    }
    public class supervisors
    {
        public int id { get; set; }
        public string name { get; set; }
        public int birthYear { get; set; }
        public string hometown { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
    }
    public class subjects
    {
        public int id { get; set; }
        public string name { get; set; }
        public int teacherID { get; set; }
        public List<int> studentsID;

    }
    public class users
    {
        public students[] students;
        public teachers[] teachers;
        public supervisors[] supervisor;
    }
    public class Data
    {
        public users users;
        public subjects[] subjects;
    }

}