using System;

namespace AlumniApp
{
	class StudentsBuilder : UserBuilder
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