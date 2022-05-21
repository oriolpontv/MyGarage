using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGarage
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToLongDateString();
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factures factures = new Factures();
            factures.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Treballadors treballadors = new Treballadors();
            treballadors.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Proveidors proveidors = new Proveidors();
            proveidors.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reparacions reparacions = new Reparacions();
            reparacions.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Vehicles vehicles = new Vehicles();
            vehicles.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pressupostos pressupostos = new Pressupostos();
            pressupostos.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Magatzem magatzem = new Magatzem();
            magatzem.Show();
        }
    }
}
