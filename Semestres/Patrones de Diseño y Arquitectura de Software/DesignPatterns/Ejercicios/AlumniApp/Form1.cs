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

namespace AlumniApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
    }
}
