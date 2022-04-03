using System;
using System.Collections.Generic;

namespace AlumniApp
{
    public class Student
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

    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subjectID { get; set; }
        public int birthYear { get; set; }
        public string hometown { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
    }

    public class Supervisor
    {
        public int id { get; set; }
        public string name { get; set; }
        public int birthYear { get; set; }
        public string hometown { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
    }

    public class Users
    {
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
        public List<Supervisor> supervisor { get; set; }
    }

    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int teacherID { get; set; }
        public List<int> studentsID { get; set; }
    }

    public class Root
    {
        public Users users { get; set; }
        public List<Subject> subjects { get; set; }
    }



}