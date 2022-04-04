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
            Form1.StudentBasicInfo.Visible = Form1.showCareer.Visible = true;
            Form1.showCareer.BringToFront();
            Form1.showCareer.Text = Form1.myCareer;
        }
		public override void BuildSubjectID()
		{
			_user.Add("subjectID");
		}
		public override void BuildGrades()
		{
			_user.Add("grades");
            Form1.gradesTable.Visible = true;
            Form1.gradesTable.Columns.Add("Subject", "Subject");
            Form1.gradesTable.Columns.Add("P1", "P1");
            Form1.gradesTable.Columns.Add("P2", "P2");
            Form1.gradesTable.Columns.Add("P3", "P3");
            Form1.gradesTable.Rows.Add(Form1.mySubjectName, Form1.mygrades[0], Form1.mygrades[1], Form1.mygrades[2]);
        }

        public override void Download()
        {
            Form1.downloadbutton.Visible = true;
            //export
            //    //Application application = new Application();
            //    //Document document = application.Documents.Open("C:\\word.doc");
            //    //int count = document.Words.Count;
            //    //for (int i = 1; i <= count; i++)
            //    //{
            //    //    string text = document.Words[i].Text;
            //    //    Console.WriteLine("Word {0} = {1}", i, text);
            //    //}
            //    //application.Quit();
        }

        public override void NoAccess()
        {
            //just for supervisor
        }

    }
}

/*
 
		StudentBasicInfo.Visible = showCareer.Visible = downloadbutton.Visible = gradesTable.Visible = true;
        showCareer.BringToFront();
        showCareer.Text = myCareer;
        
 
 */