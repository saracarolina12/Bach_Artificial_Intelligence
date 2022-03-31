using System;

namespace AlumniApp
{
	class UserDirector
	{
		public void Construct(UserBuilder builder)
		{
			builder.BuildID();
			builder.BuildName();
			builder.BuildCareer();
			builder.BuildBirthYear();
			builder.BuildHometown();
			builder.BuildMail();
			builder.BuildPassword();
			builder.BuildSubjectID();
			builder.BuildGrades();
			builder.BuildteacherID();
			builder.BuildstudentsID();
		}
	}
}