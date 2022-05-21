using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Reparacions : Form
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

        public Reparacions()
        {
            InitializeComponent();
        }

        private void Reparacions_Load(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM REPARACIONS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM REPARACIONS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox4.Text) && String.IsNullOrEmpty(textBox5.Text) && String.IsNullOrEmpty(textBox6.Text) && String.IsNullOrEmpty(textBox7.Text) && String.IsNullOrEmpty(textBox8.Text) && String.IsNullOrEmpty(textBox9.Text) && String.IsNullOrEmpty(textBox10.Text) && String.IsNullOrEmpty(textBox11.Text) && String.IsNullOrEmpty(textBox12.Text) && String.IsNullOrEmpty(textBox13.Text))
            {
                MessageBox.Show("Omple les dades de la reparació primer!!!");
            }
            else
            {
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "INSERT INTO REPARACIONS (responsable, id_vehicle, id_client, dni_client, descripcio, import, estat, diposit_entrada, kms_entrada, data_entrada, data_sortida, id_factura, id_pressupost) VALUES (" + this.textBox1.Text + "," + this.textBox2.Text + "," + this.textBox3.Text + ",'" + this.textBox4.Text + "','" + this.textBox5.Text + "'," + this.textBox6.Text + "," + this.textBox7.Text + ",'" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox10.Text + "','" + this.textBox11.Text + "'," + this.textBox12.Text + "," + this.textBox13.Text + ")";
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();

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
                this.textBox11.Clear();
                this.textBox12.Clear();
                this.textBox13.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarReparacio eliminarReparacio = new EliminarReparacio();
            eliminarReparacio.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditarReparacio editarReparacio = new EditarReparacio();
            editarReparacio.Show();
        }
    }
}
