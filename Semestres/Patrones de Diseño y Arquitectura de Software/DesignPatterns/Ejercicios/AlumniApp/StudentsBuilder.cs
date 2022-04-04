using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;

namespace AlumniApp
{
	class StudentsBuilder : UserBuilder
	{
      
        public override void BuildCareer()
		{
			_user.Add("career");
            /*for (int i = 0; i < Adaptee.data.users.students.Count; i++)
            {
                Console.WriteLine("\t\tMY MAAAAIL");
                Console.WriteLine(Form1.mymail);
                if (Form1.mymail == Adaptee.data.users.students[i].mail)
                {
                    Console.WriteLine("is a student");
                    Form1.isStudent = true;
                    Form1.isTeacher = false;
                    Form1.isSupervisor = false;
                    //exists
                    Form1.myID = Adaptee.data.users.students[i].id.ToString();
                    Form1.myName = Adaptee.data.users.students[i].name;
                    Form1.myBday = Adaptee.data.users.students[i].birthYear.ToString();
                    Form1.myHometown = Adaptee.data.users.students[i].hometown;
                    Form1.myCareer = Adaptee.data.users.students[i].career;
                    for (int j = 0; j < Adaptee.data.subjects.Count; j++)
                    {
                        if (Adaptee.data.subjects[j].id == Adaptee.data.users.students[i].subjectID)
                        {
                            Form1.mySubject = Adaptee.data.subjects[j].id.ToString();
                            Form1.mySubjectName = Adaptee.data.subjects[j].name.ToString();
                        }

                    }
                    Form1.existsMail = 1;
                    Form1.existsMailID = Adaptee.data.users.students[i].mail; //guardo el ID del usuario
                    Form1.correctPass = Adaptee.data.users.students[i].password; //guardo la contraseña correcta
                    break;
                }
            }*/
        }
		public override void BuildSubjectID()
		{
			_user.Add("subjectID");
		}
		public override void BuildGrades()
		{
			_user.Add("grades");
		}

	}
}