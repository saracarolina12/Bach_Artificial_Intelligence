using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simulacion_Pedidos
{
    class Start
    {
        public static int TOTAL_SODA = 0, TOTAL_BREAD = 0, TOTAL_VEGETABLES = 0;
        public static int SODA_TRUCK = 0, BREADK_TRUCK = 0, VEGETABLES_TRUCK = 0;
        public static string global_route = "..\\..\\Stores-data\\QRs\\Tienda_1.png";
        public static int route_index=1;
        public static int idx = 0;
        public static bool CB_datagrid = false;
        public static bool CB_texfile = false;
        public static bool CB_textBox = false;
        public static string report_route = "..\\..\\report.txt";
        public static Form3 thisForm3;
        public static List<KeyValuePair<string, string>> textArray = new List<KeyValuePair<string, string>>();
        public static void runCode()
        {
            /* Adapter */
            Client client = new Client();
            client.getQR();

            /* Singleton */
            Singleton instance = Singleton.Instance;
            instance = Singleton.GetInstance();
            global_route = Singleton.GenerateRoute();

            /* Strategy */
            if (File.Exists(report_route))
            {
                File.Delete(report_route);
            }

            File.Create(report_route).Dispose();
        }

        public static void selectStrategy(string dataToWrite)
        {
            if(CB_datagrid)
            {
                

                var context = new Context(new DataGrid() { newLine = dataToWrite });
                context.ContextInterface();
            }
            if (CB_texfile)
            {
                var context = new Context(new TextFile() { newLine = dataToWrite });
                context.ContextInterface();
            }
            if (CB_textBox)
            {
                var context = new Context(new TextBox() { newLine = dataToWrite });
                context.ContextInterface();

                var thisDataGridModifier = new TextBox() { newLine = dataToWrite };
                thisDataGridModifier.addToDataGrid(thisForm3);
            }

        }
    }
}