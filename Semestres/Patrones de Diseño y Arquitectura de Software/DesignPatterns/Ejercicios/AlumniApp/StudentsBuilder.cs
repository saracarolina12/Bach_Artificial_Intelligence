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
		private User _user = new User();
        private int v;

        public StudentsBuilder(int v)
        {
            this.v = v;
        }

        public override void BuildID()
		{
			StreamReader read = new StreamReader("..\\..\\Data.json");
			Root data;
			using (read)
			{
				string json = read.ReadToEnd();
				data = JsonConvert.DeserializeObject<Root>(json);
				for(int i=0; i<data.users.students.Count; i++)
                {
					Console.WriteLine("data: {0}", data.users.students[i].id.ToString());
					_user.Add(data.users.students[i].id.ToString());
				}
				
			}
			
		}
		public override void BuildName()
		{
			_user.Add("name");
		}
		public override void BuildCareer()
		{
			_user.Add("career");
		}
		public override void BuildBirthYear()
		{
			_user.Add("birthYear");
		}
		public override void BuildHometown()
		{
			_user.Add("hometown");
		}

		public override void BuildMail()
		{
			_user.Add("mail");
		}
		public override void BuildPassword()
		{
			_user.Add("password");
		}
		public override void BuildSubjectID()
		{
			_user.Add("subjectID");
		}
		public override void BuildGrades()
		{
			_user.Add("grades");
		}
		public override void BuildteacherID()
		{
			//just for subjects
		}
		public override void BuildstudentsID()
		{
			//just for subjects
		}
		public override User GetResult()
		{
			return _user;
		}
	}
}