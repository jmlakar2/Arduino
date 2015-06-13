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

namespace gamepadApp
{
    public partial class mainForm : Form
    {
        private SerialPort serialPort = new SerialPort();
        private String zadnja_poruka = "";
        private String trenutni_poruka;
        private String spremiX = "500";
        private String spremiY = "500";
        public mainForm()
        {
            InitializeComponent();
            btnOdspoji.Enabled = false;
        }

        private void btnSpoji_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.DataReceived += new SerialDataReceivedEventHandler(primajPodatke);
                serialPort.PortName = "COM8";
                serialPort.BaudRate = 9600;
                serialPort.Open();

                serialPort.Write("start");

                btnOdspoji.Enabled = true;
                btnSpoji.Enabled = false;
            }
            catch
            {
                MessageBox.Show("ARDUINO NIJE SPOJEN NA COM8!!!");
            }
        }

        private void primajPodatke(object sender, SerialDataReceivedEventArgs e)
        {
            trenutni_poruka = "";
            trenutni_poruka = serialPort.ReadLine();
            this.Invoke(new EventHandler(saljiTipku));
        }

        private void saljiTipku(object sender, EventArgs e)
        {
            try
            {
                lblTrenutna.Text = trenutni_poruka;
                lblZadnja.Text = zadnja_poruka;

                if (zadnja_poruka.Contains("X"))
                    spremiX = trenutni_poruka;
                if (zadnja_poruka.Contains("Y"))
                {
                    spremiY = trenutni_poruka;
                    if (int.Parse(spremiX) > 900)
                        SendKeys.Send("s");
                    else if (int.Parse(spremiX) < 10)
                        SendKeys.Send("w");
                    else if (int.Parse(spremiY) > 900)
                        SendKeys.Send("a");
                    else if (int.Parse(spremiY) < 10)
                        SendKeys.Send("d");
                }

                if (trenutni_poruka.Contains("e"))
                    SendKeys.Send("e");
                else if (trenutni_poruka.Contains("r"))
                    SendKeys.Send("r");
                else if (trenutni_poruka.Contains("t"))
                    SendKeys.Send("t");
                else if (trenutni_poruka.Contains("z"))
                    SendKeys.Send("z");
            }
            catch { label3.Text = "wat"; }
            zadnja_poruka = trenutni_poruka;
        }

        private void btnOdspoji_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Write("stop");
                //serialPort.DataReceived -= new SerialDataReceivedEventHandler(primajPodatke);
                System.Threading.Thread.Sleep(2000);
                //serialPort.DataReceived -= new SerialDataReceivedEventHandler(primajPodatke);
                btnSpoji.Enabled = true;
                btnOdspoji.Enabled = false;
                serialPort.Close();
            }
            catch { }
        }

        private void zatvaraneForme(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort.Write("stop");
                System.Threading.Thread.Sleep(2000);
                serialPort.Close();
            }
            catch { }
        }
    }
}
