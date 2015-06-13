using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace serialControl1
{
    public partial class ControlPanel : Form
    {
        //SerialPort serialPort = new SerialPort();
        //string stupanj = "";
        SerialCn serialCn = new SerialCn();
        public ControlPanel()
        {
            InitializeComponent();
            
        }

        private void spojiButton_Click(object sender, EventArgs e)
        {
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(primajPodatke);

            try
            {
                serialCn.serialConnect("COM8", 9600);
                status.Text = "SPOJEN";

                if (serialCn.isOpen())
                {
                    spojiButton.Enabled = false;
                    odspojiButton.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("ARDUINO NIJE SPOJEN NA COM8!!!");
            }
            
        }

        private void odspojiButton_Click(object sender, EventArgs e)
        {
            if (serialCn.isOpen())
            {
                serialCn.serialDisconnect();
                spojiButton.Enabled = true;
                odspojiButton.Enabled = false;
            }
            status.Text = "NIJE SPOJEN";
        }

        /*
        private void primajPodatke(Object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            stupanj = serialPort.ReadExisting();
            this.Invoke(new EventHandler(prikaziStupnje));
        }
        */
        private void zatvaranjeForme(object sender, FormClosingEventArgs e)
        {
            if (serialCn.isOpen())
                serialCn.serialDisconnect();
        }

        private void upravljanje(object sender, KeyEventArgs e)
        {
            if (serialCn.isOpen())
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        serialCn.sendSerialMsg("lijevo");
                        break;
                    case Keys.Right:
                        serialCn.sendSerialMsg("desno");
                        break;
                    case Keys.Up:
                        serialCn.sendSerialMsg("naprijed");
                        break;
                    case Keys.Down:
                        serialCn.sendSerialMsg("nazad");
                        break;
                    case Keys.R:
                        serialCn.sendSerialMsg("reset");
                        break;
                    case Keys.Space:
                        serialCn.sendSerialMsg("truba");
                        break;
                    case Keys.Q:
                        serialCn.sendSerialMsg("lLED");
                        break;
                    default:
                        MessageBox.Show("TIPKA KOJU STE PRITISNULI NE RADI NIŠTA JOŠ:(");
                        break;
                }
            }
        }
    }
}
