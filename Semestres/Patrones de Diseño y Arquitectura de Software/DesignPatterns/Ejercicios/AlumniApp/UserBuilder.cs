using System;

namespace AlumniApp
{
	
	abstract class UserBuilder
	{
		public User _user = new User();
		//private User _user = new User();
		public abstract void BuildCareer();
		public abstract void BuildSubjectID();
		public abstract void BuildGrades();
		public virtual void BasicInfo()
		{
            _user.Add("id");
            _user.Add("name");
            _user.Add("birthyear");
            _user.Add("hometown");
            _user.Add("mail");
            _user.Add("password");
        }
        public virtual void Login()
		{
            _user.Add("login");
        }
		public virtual User GetResult()
		{
			return _user;
		}
	}



}