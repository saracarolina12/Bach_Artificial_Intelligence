using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
    class Start
    {
        public static int TOTAL_SODA = 0, TOTAL_BREAD = 0, TOTAL_VEGETABLES = 0;
        public static int SODA_TRUCK = 0, BREADK_TRUCK = 0, VEGETABLES_TRUCK = 0;
        public static void runCode()
        {
            /* Adapter */
            Client client = new Client();
            client.getQR();

            Singleton s1 = Singleton.GeneratePath();

        }
    }
}
