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
		//StreamReader read = new StreamReader("..\\..\\Data.json"); //to read json

		public override void BuildCareer()
		{
			_user.Add("career");
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