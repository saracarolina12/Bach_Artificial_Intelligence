using System;

namespace AlumniApp
{
	class MenuDirector
	{
		public void Construct(UserBuilder builder)
		{
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