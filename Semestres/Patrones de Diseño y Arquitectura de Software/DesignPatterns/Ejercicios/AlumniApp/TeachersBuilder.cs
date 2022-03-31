using System;

namespace AlumniApp
{
	class TeachersBuilder : UserBuilder
	{
		private User _user = new User();
		public override void BuildID()
		{
			_user.Add("id");
		}
		public override void BuildName()
		{
			_user.Add("name");
		}
		public override void BuildCareer()
		{
			//just for students
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
			//just for students
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