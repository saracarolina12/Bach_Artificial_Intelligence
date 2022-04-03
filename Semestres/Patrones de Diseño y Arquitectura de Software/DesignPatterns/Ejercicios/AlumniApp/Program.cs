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
    static class Program
    {
        
       
        static void Main()
        {

            /*StreamReader read = new StreamReader("..\\..\\Data.json");
            using (read)
            {
                string json = read.ReadToEnd();
                Root data = JsonConvert.DeserializeObject<Root>(json);
                //Console.WriteLine("data: {0}",data.users.supervisor.Count);
            }*/


                /* Adapter */
            Client client = new Client();
            client.Operation();


                /*Builder*/
            UserDirector director = new UserDirector();

            // Students
            UserBuilder builder1 = new StudentsBuilder(1);
            director.Construct(builder1);
            User user1 = builder1.GetResult();
            Console.WriteLine("* Students: {0}", user1);

            // Teachers
            UserBuilder builder2 = new TeachersBuilder();
            director.Construct(builder2);
            User user2 = builder2.GetResult();
            Console.WriteLine("* Teachers: {0}", user2);

            // Supervisor
            
            UserBuilder builder3 = new SupervisorBuilder();
            director.Construct(builder3);
            User user3 = builder3.GetResult();
            Console.WriteLine("* Supervisor: {0}", user3);


            /*Windows Forms*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        }
    }
}



