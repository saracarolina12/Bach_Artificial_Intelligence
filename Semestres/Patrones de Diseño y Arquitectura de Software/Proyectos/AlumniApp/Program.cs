using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;

namespace AlumniApp
{
     class Program
    {
        

        static void Main()
        {

                /* Adapter */
            Client client = new Client();
            client.getData();


                /*Windows Forms*/                               //llamo a forms donde por dentro llama a builder
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        }
    }
}



