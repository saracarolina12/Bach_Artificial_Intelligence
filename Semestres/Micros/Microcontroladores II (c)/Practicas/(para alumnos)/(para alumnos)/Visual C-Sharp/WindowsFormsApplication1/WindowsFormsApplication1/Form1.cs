using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        
        public int[] array2 = new int[] { 1, 3, 5, 7, 9 };
        public int[] melodia = new int[] { 1, 2, 3, 1, 1, 2, 3, 1, 3, 4, 5, 3, 4, 5, 5, 6, 5, 4, 3, 1, 5, 6, 5, 4, 3, 1, 1, 7, 1, 1, 7, 1, 0 };
        public int tope = 33; //la máxima longitud de una melodía serán 99 notas
        public int lugar = 100; //NO CAMBIAR ESTE VALOR!!! la máxima longitud de una melodía serán 99 notas
        public int error = 0;
        public DateTime Inicio;
        public DateTime Final;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            try //intenta hacer lo que hay dentro de este try
            {
                sPuerto.Open(); //abrir el puerto serial
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ABRIR EL PUERTO SERIAL\n\n" + ex); //Me muestra el error
                Application.Exit(); //cierra el programa
            }
            if (sPuerto.IsOpen)
            {
                //MessageBox.Show("TEXTO","TÍTULO");
                //A continuación se muestra la información del puerto (si se desea cambiar se debe hacer desde las propiedades del puerto)
                MessageBox.Show("El puerto " + sPuerto.PortName + " se abrió con una velocidad de " + sPuerto.BaudRate + "\nParidad: " + sPuerto.Parity + "\nNúmero de bits: " + sPuerto.DataBits + "\nBits de parada: " + sPuerto.StopBits, "Información de la conexión");
            }
        }


        private void sPuerto_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int Dato = sPuerto.ReadByte();

            if (Dato == 73) //Cuando recibe el dato "I" o 73 (instrucción de inicio) cambia el valor de "lugar" a 1
            {
                lugar = 0;
                lblErr.Text = ".";
                lblTime.Text = ".";
                Inicio = DateTime.Now; 
            }

            if ((lugar != 100) && (lugar < tope)) //Sólo será 0 cuando no se ha enviado desde el micro la instrucción de comienzo
            {

                if (lugar == 0) // si es la primera tecla que desplegará, sólo la muestra sin revisar nada
                {
                    if (melodia[lugar] == 1) //Es decir si es DO
                    {
                        btnDo.BackColor = Color.Red;

                        btnRe.BackColor = Color.Gray;
                        btnMi.BackColor = Color.Gray;
                        btnFa.BackColor = Color.Gray;
                        btnSol.BackColor = Color.Gray;
                        btnLa.BackColor = Color.Gray;
                        btnSi.BackColor = Color.Gray;
                    }
                    if (melodia[lugar] == 2) //Es decir si es RE
                    {
                        btnRe.BackColor = Color.Orange;

                        btnDo.BackColor = Color.Gray;
                        btnMi.BackColor = Color.Gray;
                        btnFa.BackColor = Color.Gray;
                        btnSol.BackColor = Color.Gray;
                        btnLa.BackColor = Color.Gray;
                        btnSi.BackColor = Color.Gray;
                    }
                    if (melodia[lugar] == 3) //Es decir si es MI
                    {
                        btnMi.BackColor = Color.Yellow;

                        btnDo.BackColor = Color.Gray;
                        btnRe.BackColor = Color.Gray;
                        btnFa.BackColor = Color.Gray;
                        btnSol.BackColor = Color.Gray;
                        btnLa.BackColor = Color.Gray;
                        btnSi.BackColor = Color.Gray;
                    }
                    if (melodia[lugar] == 4) //Es decir si es FA
                    {
                        btnFa.BackColor = Color.Green;

                        btnDo.BackColor = Color.Gray;
                        btnRe.BackColor = Color.Gray;
                        btnMi.BackColor = Color.Gray;
                        btnSol.BackColor = Color.Gray;
                        btnLa.BackColor = Color.Gray;
                        btnSi.BackColor = Color.Gray;
                    }
                    if (melodia[lugar] == 5) //Es decir si es SOL
                    {
                        btnSol.BackColor = Color.Blue;

                        btnDo.BackColor = Color.Gray;
                        btnRe.BackColor = Color.Gray;
                        btnMi.BackColor = Color.Gray;
                        btnFa.BackColor = Color.Gray;
                        btnLa.BackColor = Color.Gray;
                        btnSi.BackColor = Color.Gray;
                    }
                    if (melodia[lugar] == 6) //Es decir si es LA
                    {
                        btnLa.BackColor = Color.Purple;

                        btnDo.BackColor = Color.Gray;
                        btnRe.BackColor = Color.Gray;
                        btnMi.BackColor = Color.Gray;
                        btnFa.BackColor = Color.Gray;
                        btnSol.BackColor = Color.Gray;
                        btnSi.BackColor = Color.Gray;
                    }
                    if (melodia[lugar] == 7) //Es decir si es SI
                    {
                        btnSi.BackColor = Color.Pink;

                        btnDo.BackColor = Color.Gray;
                        btnRe.BackColor = Color.Gray;
                        btnMi.BackColor = Color.Gray;
                        btnFa.BackColor = Color.Gray;
                        btnSol.BackColor = Color.Gray;
                        btnLa.BackColor = Color.Gray;
                    }
                    sPuerto.Write(Convert.ToString(melodia[lugar]));
                    label7.Text=Convert.ToString(melodia[lugar]);
                    lugar++;
                }
                else // si (lugar!=1) es decir si ya mostrará la segunda o mayor tecla, debe revisar la respuesta...
                { 
                    int tecla = melodia[lugar-1];
                    if ((Dato - 48)!= tecla) //Es decir si la tecla no fue la que correspondía
                    {
                        error++;
                        lblErr.Text = "Errores acumulados: " + System.Convert.ToString(error);
                    }                
                    else//si no hubo error entonces despliega la siguiente tecla
                    {
                            if (melodia[lugar] == 1)  //Es decir si es DO
                            {
                                btnDo.BackColor = Color.Red;

                                btnRe.BackColor = Color.Gray;
                                btnMi.BackColor = Color.Gray;
                                btnFa.BackColor = Color.Gray;
                                btnSol.BackColor = Color.Gray;
                                btnLa.BackColor = Color.Gray;
                                btnSi.BackColor = Color.Gray;
                            }
                            if (melodia[lugar] == 2)  //Es decir si es RE
                            {
                                btnRe.BackColor = Color.Orange;

                                btnDo.BackColor = Color.Gray;
                                btnMi.BackColor = Color.Gray;
                                btnFa.BackColor = Color.Gray;
                                btnSol.BackColor = Color.Gray;
                                btnLa.BackColor = Color.Gray;
                                btnSi.BackColor = Color.Gray;
                            }
                            if (melodia[lugar] == 3) //Es decir si es MI
                            {
                                btnMi.BackColor = Color.Yellow;

                                btnDo.BackColor = Color.Gray;
                                btnRe.BackColor = Color.Gray;
                                btnFa.BackColor = Color.Gray;
                                btnSol.BackColor = Color.Gray;
                                btnLa.BackColor = Color.Gray;
                                btnSi.BackColor = Color.Gray;
                            }
                            if (melodia[lugar] == 4)  //Es decir si es FA
                            {
                                btnFa.BackColor = Color.Green;

                                btnDo.BackColor = Color.Gray;
                                btnRe.BackColor = Color.Gray;
                                btnMi.BackColor = Color.Gray;
                                btnSol.BackColor = Color.Gray;
                                btnLa.BackColor = Color.Gray;
                                btnSi.BackColor = Color.Gray;
                            }
                            if (melodia[lugar] == 5)  //Es decir si es SOL
                            {
                                btnSol.BackColor = Color.Blue;

                                btnDo.BackColor = Color.Gray;
                                btnRe.BackColor = Color.Gray;
                                btnMi.BackColor = Color.Gray;
                                btnFa.BackColor = Color.Gray;
                                btnLa.BackColor = Color.Gray;
                                btnSi.BackColor = Color.Gray;
                            }
                            if (melodia[lugar] == 6)  //Es decir si es LA
                            {
                                btnLa.BackColor = Color.Purple;

                                btnDo.BackColor = Color.Gray;
                                btnRe.BackColor = Color.Gray;
                                btnMi.BackColor = Color.Gray;
                                btnFa.BackColor = Color.Gray;
                                btnSol.BackColor = Color.Gray;
                                btnSi.BackColor = Color.Gray;
                            }
                            if (melodia[lugar] == 7) //Es decir si es SI
                            {
                                btnSi.BackColor = Color.Pink;

                                btnDo.BackColor = Color.Gray;
                                btnRe.BackColor = Color.Gray;
                                btnMi.BackColor = Color.Gray;
                                btnFa.BackColor = Color.Gray;
                                btnSol.BackColor = Color.Gray;
                                btnLa.BackColor = Color.Gray;
                            }
                            sPuerto.Write(Convert.ToString(melodia[lugar]));
                            label7.Text=Convert.ToString(melodia[lugar]);
                            lugar++; //dejo el apuntador del lugar para la siguiente nota que habría de tocarse
                        
                    }  
                }                    
            }
            if (lugar == tope)
            {

                btnDo.BackColor = Color.LightGray;
                btnRe.BackColor = Color.LightGray;
                btnMi.BackColor = Color.LightGray;
                btnFa.BackColor = Color.LightGray;
                btnSol.BackColor = Color.LightGray;
                btnLa.BackColor = Color.LightGray;
                btnSi.BackColor = Color.LightGray;
                //MessageBox.Show("Has completado la melodía");
                lugar = 100;
                if (error == 0)
                {
                    lblErr.Text = "Excelente!";
                }
                else
                {
                    //lblErr.Text = "Errores: " + System.Convert.ToString(error);
                    lblErr.Text = "Cometiste " + System.Convert.ToString(error) + " errores en total";
                    Final = DateTime.Now;
                    TimeSpan duracion = Final - Inicio;
                    double segundosTotales = duracion.TotalSeconds;
                    int segundos = duracion.Seconds;
                    lblTime.Text = "Tu tiempo fue de: " + Convert.ToString(segundos) + " segundos";
                }

            }
            this.lblDato.Text = Convert.ToString(Dato);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
