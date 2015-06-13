using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace termostatApp
{
    public partial class FrmTerm : Form
    {
        SerialPort serialPort = new SerialPort();

        string temperatura;
        public FrmTerm()
        {
            InitializeComponent();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(primajPodatke);
            try
            {
                serialPort.PortName = "COM8";
                serialPort.BaudRate = 9600;
                serialPort.Open();
            }
            catch
            {
                MessageBox.Show("ARDUINO NIJE SPOJEN NA COM8!!!");
            }
        }

        private void primajPodatke(object sender, SerialDataReceivedEventArgs e)
        {
            temperatura = "";
            temperatura = serialPort.ReadLine();
            this.Invoke(new EventHandler(prikaziStupnje));
        }

        private void prikaziStupnje(object sender, EventArgs e)
        {
            lblTemp.Text = temperatura;
        }

        private void zatvaranjeForme(object sender, FormClosingEventArgs e)
        {
            serialPort.Close();
        }
    }
}
