using System;

namespace AlumniApp
{
	abstract class UserBuilder
	{
		public abstract void BuildID();
		public abstract void BuildName();
		public abstract void BuildCareer();
		public abstract void BuildBirthYear();
		public abstract void BuildHometown();
		public abstract void BuildMail();
		public abstract void BuildPassword();
		public abstract void BuildSubjectID();
		public abstract void BuildGrades();
		public abstract void BuildteacherID();
		public abstract void BuildstudentsID();
		public abstract User GetResult();
	}
}