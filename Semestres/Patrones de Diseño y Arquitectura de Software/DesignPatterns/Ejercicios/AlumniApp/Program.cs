using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace AlumniApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // var msj = ConfigurationManager.AppSettings["export"];
            // Console.WriteLine(msj);

            /* Adapter */
            Client client = new Client();
            client.Operation();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            /*Builder*/
            // create a menu director
            UserDirector director = new UserDirector();

            // create burger menu using burger menu builder
            UserBuilder builder1 = new StudentBuilder();
            director.Construct(builder1);
            Menu user1 = builder1.GetResult();
            Console.WriteLine("Burger menu: {0}", user1);

            // create kids menu using kids menu builder
            UserBuilder builder2 = new TeacherBuilder();
            director.Construct(builder2);
            Menu user2 = builder2.GetResult();
            Console.WriteLine("Kids menu: {0}", user2);

        }
    }
}
