using System;
using System.Collections.Generic;using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace MyGarage
{
    public partial class Clients : Form
    {

        MySqlConnection sqlCon = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;

        DataSet DS = new DataSet();

        String server = "192.168.1.30";
        String database = "mygarage";
        String username = "admindb";
        String password = "Fat/3232";

        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {

            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM CLIENTS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox4.Text) && String.IsNullOrEmpty(textBox5.Text) && String.IsNullOrEmpty(textBox6.Text) && String.IsNullOrEmpty(textBox7.Text) && String.IsNullOrEmpty(textBox8.Text) && String.IsNullOrEmpty(textBox9.Text) && String.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Omple les dades del client primer!!!");
            }
            else
            {
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "INSERT INTO CLIENTS (nom, cognoms, dni, adreça, telefon, id_vehicle, email, contrasenya, tipus, ref_client) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "'," + this.textBox6.Text + ",'" + this.textBox10.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "')";
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();

                MailMessage msg = new MailMessage("mygarage.dam@gmail.com", this.textBox10.Text, "BENVINGUT A CLIENT", "Benvingut " + this.textBox1.Text + " a MyGarage Client. T'informem que l'usuari i la contrasenya per accedir al teu espai personal des de la nostra APP son els seguents: " + textBox3.Text + " i " + textBox7.Text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("mygarage.dam@gmail.com", "Fat/3232");//your mail password
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                MessageBox.Show("MaiL enviat correctament.");

                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.textBox6.Clear();
                this.textBox7.Clear();
                this.textBox8.Clear();
                this.textBox9.Clear();
                this.textBox10.Clear();

                Vehicles vehicles = new Vehicles();
                vehicles.Show();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarClient eliminarClient = new EliminarClient();
            eliminarClient.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM CLIENTS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditarClient editarClient = new EditarClient();
            editarClient.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EnviarMail enviarMail = new EnviarMail();
            enviarMail.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            ManualClients manualClients = new ManualClients();
            manualClients.Show();
        }
    }
}
