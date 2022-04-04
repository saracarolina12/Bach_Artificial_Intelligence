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
			{
				Form1.gradesTable.Visible = Form1.showSubject.Visible = Form1.setSubject.Visible = true;
				Form1.showSubject.BringToFront();
				Form1.showSubject.Text = Form1.myTeacherSubject;

				Form1.gradesTable.Columns.Add("N°", "N°");
				Form1.gradesTable.Columns.Add("Student", "Student");
				Form1.gradesTable.Columns.Add("P1", "P1");
				Form1.gradesTable.Columns.Add("P2", "P2");
				Form1.gradesTable.Columns.Add("P3", "P3");
				for (int c = 1, i = 0; i < Adaptee.data.users.students.Count; i++)
				{
					if (Adaptee.data.users.students[i].subjectID.ToString() == Form1.myTeachersSubject_ID)
						Form1.gradesTable.Rows.Add(c++, Adaptee.data.users.students[i].name, Adaptee.data.users.students[i].grades[0], Adaptee.data.users.students[i].grades[1], Adaptee.data.users.students[i].grades[2]);
				}
			}
		}
		public override void BuildGrades()
		{
			//just for students
		}
		public override void Download()
		{
			//just for students
		}
		public override void NoAccess()
		{
			//just for supervisor
		}
	}
}
