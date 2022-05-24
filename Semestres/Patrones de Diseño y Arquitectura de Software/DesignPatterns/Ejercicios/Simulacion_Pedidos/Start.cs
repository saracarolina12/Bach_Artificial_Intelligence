using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
    class Start
    {
        public static void runCode()
        {
            /* Adapter */
            Client client = new Client();
            client.getQR();

            Singleton s1 = Singleton.GeneratePath();

        }
    }
}
