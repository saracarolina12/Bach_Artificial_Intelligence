using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace AlumniApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string mymail;
        private string mypass;

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
                int existsMail = 0, existsMailID=-1;
                Console.WriteLine("{0}", Program.data.users.students[0].name);
                /*for(int i=1; i< Program.data.users.students.Count; i++)
                {
                    if(mymail == Program.data.users.students[i].id.ToString())
                    {
                        //exists
                        existsMail = 1;
                        existsMailID = i;
                        break;
                    }
                }
                if(existsMail == 1) //si existe
                {
                    //if(data.users.students[existsMailID])
                }*/
            }
        }
    }
}
