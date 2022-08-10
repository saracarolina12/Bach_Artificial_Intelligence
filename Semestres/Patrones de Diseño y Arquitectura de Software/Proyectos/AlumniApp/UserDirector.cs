using System;

namespace AlumniApp
{
	class UserDirector
	{
		public void Construct(UserBuilder builder)
		{
			builder.BuildCareer();
			builder.BuildSubjectID();
			builder.BuildGrades();
			builder.BasicInfo();
			builder.Login();
			builder.Download();
			builder.NoAccess();

	}
	}
}