using System;

namespace AlumniApp
{
	class TeachersBuilder : UserBuilder
	{
		public override void BuildCareer()
		{
			//just for students
		}
		public override void BuildSubjectID()
		{
			_user.Add("subjectID");
		}
		public override void BuildGrades()
		{
			//just for students
		}
		
	}
}