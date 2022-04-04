using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using word = Microsoft.Office.Interop.Word;

namespace AlumniApp
{
    public partial class Form1 : Form
    {
        public static int existsMail = 0;
        public static string existsMailID = "x";
        public static string mymail, mypass, myID, myName, myBday, myHometown, myCareer, correctPass, mySubject, mySubjectName, myTeacherSubject, myTeachersSubject_ID;
        public static bool isTeacher, isStudent, isSupervisor;
        public static List<int> mygrades = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void setPassword_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("written Password: {0}", setPassword.Text);
            mypass = setPassword.Text;
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void setMail_Enter(object sender, EventArgs e)
        {
            if(setMail.Text == "Mail")
            {
                setMail.Text = "";
                setMail.ForeColor = Color.FromArgb(122, 122, 122);
            }
        }

        private void setMail_Leave(object sender, EventArgs e)
        {
            if(setMail.Text == "")
            {
                setMail.Text = "Mail";
                setMail.ForeColor = Color.FromArgb(85, 85, 85);
            }
        }

        private void setPassword_Enter(object sender, EventArgs e)
        {
            if (setPassword.Text == "Password")
            {
                setPassword.Text = "";
                setPassword.ForeColor = Color.FromArgb(122, 122, 122);
                setPassword.UseSystemPasswordChar = true;
            }
        }

        private void setPassword_Leave(object sender, EventArgs e)
        {
            if (setPassword.Text == "")
            {
                setPassword.Text = "Password";
                setPassword.ForeColor = Color.FromArgb(85, 85, 85);
                setPassword.UseSystemPasswordChar = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setMail_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("written Mail: {0}", setMail.Text);
            mymail = setMail.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void showMail_Click(object sender, EventArgs e)
        {

        }

        private void downloadbutton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void showHometown_Click(object sender, EventArgs e)
        {

        }

        private void showBday_Click(object sender, EventArgs e)
        {

        }

        private void showName_Click(object sender, EventArgs e)
        {

        }

        private void showID_Click(object sender, EventArgs e)
        {

        }

        private void dataBasicInfo_Click(object sender, EventArgs e)
        {

        }

        /********************************************************************/
        private void sign_inbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click :D");
            //aquí reviso que los campos no estén vacíos
            if(setMail.Text == "Mail" && setPassword.Text == "Password")
            {
                string message = "Empty mail and password";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK; 
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }else if (setPassword.Text == "Password")
            {
                string message = "Empty password";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }
            else if(setMail.Text == "Mail")
            {
                string message = "Empty mail";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }
            else //si no están vacíos, verifica que existan los usuarios
            {
                existsMail = 0;
                existsMailID="x";
                //students
                for (int i=0; i< Adaptee.data.users.students.Count; i++) 
                {
                    if (mymail == Adaptee.data.users.students[i].mail)
                    {
                        Console.WriteLine("is a student");
                        isStudent = true;
                        isTeacher = false;
                        isSupervisor = false;
                        //exists
                        myID = Adaptee.data.users.students[i].id.ToString();
                        myName = Adaptee.data.users.students[i].name;
                        myBday = Adaptee.data.users.students[i].birthYear.ToString();
                        myHometown = Adaptee.data.users.students[i].hometown;
                        myCareer = Adaptee.data.users.students[i].career;
                        for(int j=0; j<Adaptee.data.subjects.Count; j++)
                        {
                            if (Adaptee.data.subjects[j].id == Adaptee.data.users.students[i].subjectID)
                            {
                                mySubject = Adaptee.data.subjects[j].id.ToString();
                                mySubjectName = Adaptee.data.subjects[j].name.ToString();
                            }
                                
                        }
                        for(int j=0; j< Adaptee.data.users.students[i].grades.Count; j++) //Add 3 grades
                            mygrades.Add(Adaptee.data.users.students[i].grades[j]);

                        existsMail = 1;
                        existsMailID = Adaptee.data.users.students[i].mail; //guardo el ID del usuario
                        correctPass = Adaptee.data.users.students[i].password; //guardo la contraseña correcta
                        break;
                    }
                }
                //teachers
                for (int i = 0; i < Adaptee.data.users.teachers.Count; i++) 
                {
                    if (mymail == Adaptee.data.users.teachers[i].mail)
                    {
                        Console.WriteLine("is a teacher");
                        isStudent = false;
                        isTeacher =  true;
                        isSupervisor = false;
                        //exists
                        myID = Adaptee.data.users.teachers[i].id.ToString();
                        myName = Adaptee.data.users.teachers[i].name;
                        myBday = Adaptee.data.users.teachers[i].birthYear.ToString();
                        myHometown = Adaptee.data.users.teachers[i].hometown;
                        for(int j=0; j<Adaptee.data.subjects.Count ; j++)
                        {
                            if (Adaptee.data.subjects[j].id == Adaptee.data.users.teachers[i].subjectID)
                            {
                                myTeachersSubject_ID = Adaptee.data.subjects[j].id.ToString();
                                myTeacherSubject = Adaptee.data.subjects[j].name;
                            }
                        }
                        existsMail = 1;
                        existsMailID = Adaptee.data.users.teachers[i].mail; //guardo el ID del usuario
                        correctPass = Adaptee.data.users.teachers[i].password; //guardo la contraseña correcta
                        break;
                    }
                }
                //supervisor
                for (int i = 0; i < Adaptee.data.users.supervisor.Count; i++) 
                {
                    if (mymail == Adaptee.data.users.supervisor[i].mail)
                    {
                        Console.WriteLine("is a supervisor");
                        isStudent = false;
                        isTeacher = false;
                        isSupervisor =  true;
                        //exists
                        myID = Adaptee.data.users.supervisor[i].id.ToString();
                        myName = Adaptee.data.users.supervisor[i].name;
                        myBday = Adaptee.data.users.supervisor[i].birthYear.ToString();
                        myHometown = Adaptee.data.users.supervisor[i].hometown;
                        existsMail = 1;
                        existsMailID = Adaptee.data.users.supervisor[i].mail; //guardo el ID del usuario
                        correctPass = Adaptee.data.users.supervisor[i].password; //guardo la contraseña correcta
                        break;
                    }
                }

                //Console.WriteLine("EXISTS? {0}", existsMail);

                if (existsMail == 1) //sí existe ese correo en la "db", reviso que la contraseña esté bien
                {
                    if(mypass != correctPass) //CONTRASEÑA INCORRECTA
                    {
                        string message = "Wrong password!!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            setMail.Text = "Mail";
                            setPassword.Text = "Password";
                            mymail = "";
                            mypass = "";
                            return;
                        }
                    }
                    else
                    {
                        //CONTRASEÑA CORRECTA!!!!! LOGIN 
                        logoUP.Visible = setMail.Visible = setPassword.Visible = line1.Visible = line2.Visible = sign_inbutton.Visible = false;
                        pagetittle.Text = "¡Bienvenido!";
                        basicinfo.Visible = dataBasicInfo.Visible = true;

                        //interfaz individual
                        Console.WriteLine(mymail);
                        showID.Visible = showName.Visible = showBday.Visible = showHometown.Visible = showMail.Visible  = true;
                        showMail.BringToFront(); showName.BringToFront(); showBday.BringToFront(); showHometown.BringToFront(); showID.BringToFront(); 

                        //PARA TODOS
                        showID.Text = myID;
                        showMail.Text = mymail;
                        showName.Text = myName;
                        showBday.Text = myBday;
                        showHometown.Text = myHometown;

                        //SÓLO ESTUDIANTES
                        if (isStudent)
                        {
                            StudentBasicInfo.Visible = showCareer.Visible = downloadbutton.Visible = gradesTable.Visible = true;
                            showCareer.BringToFront();
                            showCareer.Text = myCareer;
                            gradesTable.Columns.Add("Subject", "Subject");
                            gradesTable.Columns.Add("P1", "P1");
                            gradesTable.Columns.Add("P2", "P2");
                            gradesTable.Columns.Add("P3", "P3");
                            gradesTable.Rows.Add(mySubjectName, mygrades[0], mygrades[1], mygrades[2]);
                            //export
                            /*word.Application app = new word.Application();
                            word.Document doc = app.Documents.Add();
                            doc.Content.Text = "hola word";

                            doc.SaveAs2(base.GetFileName("PRUEBA") + ".docx");
                            doc.Close();
                            app.Quit();*/
                        }
                        if (isTeacher)
                        {
                            gradesTable.Visible = showSubject.Visible = setSubject.Visible = true;
                            showSubject.BringToFront();
                            showSubject.Text = myTeacherSubject;

                            gradesTable.Columns.Add("N°", "N°");
                            gradesTable.Columns.Add("Student", "Student");
                            gradesTable.Columns.Add("P1", "P1");
                            gradesTable.Columns.Add("P2", "P2");
                            gradesTable.Columns.Add("P3", "P3");
                            for (int c=1,i = 0; i < Adaptee.data.users.students.Count; i++)
                            {
                                if (Adaptee.data.users.students[i].subjectID.ToString() == myTeachersSubject_ID)
                                    gradesTable.Rows.Add(c++, Adaptee.data.users.students[i].name, Adaptee.data.users.students[i].grades[0], Adaptee.data.users.students[i].grades[1], Adaptee.data.users.students[i].grades[2]);
                            }
                        }
                        if (isSupervisor)
                        {
                            noaccess.Visible = true;
                        }
                    }
                }
                else
                {
                    //no existe la cuenta
                    string message = "This user does not exist. \nPlease, try again";
                    string title = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        setMail.Text = "Mail";
                        setPassword.Text = "Password";
                        mymail = "";
                        mypass = "";
                        return;
                    }
                }

            }
        }

        private void pagetittle_Click(object sender, EventArgs e)
        {

        }
    }
}

