using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using word = Microsoft.Office.Interop.Word;

namespace AlumniApp
{
	
	abstract class UserBuilder
	{
		public User _user = new User();
		//private User _user = new User();
		public abstract void BuildCareer();
		public abstract void BuildSubjectID();
		public abstract void BuildGrades();
        public abstract void Download();
        public abstract void NoAccess();

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
           if(Form1.TODOBIEN == true)
            {
                Form1.logoUP.Visible = Form1.setMail.Visible = Form1.setPassword.Visible = Form1.line1.Visible = Form1.line2.Visible = Form1.sign_inbutton.Visible = false;
                Form1.pagetittle.Text = "¡Bienvenido!";
                Form1.basicinfo.Visible = Form1.dataBasicInfo.Visible = true;

                //interfaz individual
                //Console.WriteLine(Form1.mymail);
                Form1.showID.Visible = Form1.showName.Visible = Form1.showBday.Visible = Form1.showHometown.Visible = Form1.showMail.Visible = true;
                Form1.showMail.BringToFront(); Form1.showName.BringToFront(); Form1.showBday.BringToFront(); Form1.showHometown.BringToFront(); Form1.showID.BringToFront();

                //PARA TODOS
                Form1.showID.Text = Form1.myID;
                Form1.showMail.Text = Form1.mymail;
                Form1.showName.Text = Form1.myName;
                Form1.showBday.Text = Form1.myBday;
                Form1.showHometown.Text = Form1.myHometown;

                Console.WriteLine("my ID from userbuilder");
                Console.WriteLine(Form1.myID);
            }
        }
		public virtual User GetResult()
		{
			return _user;
		}
	}



}