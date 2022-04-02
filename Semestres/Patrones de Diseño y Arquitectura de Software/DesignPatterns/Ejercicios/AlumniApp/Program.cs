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
            //StreamReader r = new StreamReader("..\\..\\Data.json");
            //string jsonString = r.ReadToEnd();
            //Data m = JsonConvert.DeserializeObject<Data>(jsonString);
            //Console.WriteLine("data: ",m.users);

            StreamReader r = new StreamReader("..\\..\\Data.json");
            using (r)
            {
                string json = r.ReadToEnd();
                Data data = JsonConvert.DeserializeObject<Data>(json);
                Console.WriteLine("data: ", data.users[0].students);
            }

                /* Adapter */
            Client client = new Client();
            client.Operation();


                /*Builder*/
            UserDirector director = new UserDirector();

            // Students
            UserBuilder builder1 = new StudentsBuilder();
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



