using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using WindowsFormsApplication1;
using Consulta;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        string username = "alex";
        string password = "alex";

         Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }
       


        private void button1_Click(object sender, EventArgs e)
        {

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);

            
                //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
               server.Connect(ipep);//Intentamos conectar el socket
               this.BackColor = Color.Green;

               
               

                if (username == Usuario.Text && password == Contraseña.Text)
                {
                    MessageBox.Show("Inicio de sesión aprobado");

                }
                else
                {

                    MessageBox.Show("Incorrecto, inténtalo de nuevo");

                }
                //Form1 consulta

                // Se terminó el servicio. 
                // Nos desconectamos
                 this.BackColor = Color.Gray;
                 server.Shutdown(SocketShutdown.Both);
                server.Close();

                Form2 consulta = new Form2();
                consulta.ShowDialog();

            }
                catch (SocketException )
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
               MessageBox.Show("No he podido conectar con el servidor");
                return;
            } 

        
        }

        private void Usuario_TextChanged(object sender, EventArgs e)
        {
            string usuario = Usuario.Text;

        }

        private void Contraseña_TextChanged(object sender, EventArgs e)
        {
            string contraseña = Contraseña.Text;
        }
    }
}
