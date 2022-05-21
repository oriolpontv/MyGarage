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

namespace MyGarage
{
    public partial class EditarClient : Form
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


        public EditarClient()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indica un ID de client.");
            }
            else
            {
                button2.Enabled = true;
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM CLIENTS WHERE id_client = " + textBox1.Text;
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();
                this.textBox2.Text = sqlDt.Rows[0]["nom"].ToString();
                this.textBox3.Text = sqlDt.Rows[0]["cognoms"].ToString();
                this.textBox4.Text = sqlDt.Rows[0]["dni"].ToString();
                this.textBox5.Text = sqlDt.Rows[0]["adreça"].ToString();
                this.textBox6.Text = sqlDt.Rows[0]["telefon"].ToString();
                this.textBox7.Text = sqlDt.Rows[0]["id_vehicle"].ToString();
                this.textBox8.Text = sqlDt.Rows[0]["contrasenya"].ToString();
                this.textBox9.Text = sqlDt.Rows[0]["tipus"].ToString();
                this.textBox10.Text = sqlDt.Rows[0]["ref_client"].ToString();
                this.textBox11.Text = sqlDt.Rows[0]["email"].ToString();
            }
            /*sqlCmd.CommandText = "SELECT * FROM CLIENTS WHERE id_client = " + textBox1.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "UPDATE CLIENTS SET nom = '" + textBox2.Text + "', cognoms = '" + textBox3.Text + "', dni = '" + textBox4.Text + "', adreça = '" + textBox5.Text + "', telefon = '" + textBox6.Text + "', id_vehicle = " + textBox7.Text + ", contrasenya = '" + textBox8.Text + "', tipus = '" + textBox9.Text + "', ref_client = '" + textBox10.Text + "' WHERE id_client = " + textBox1.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            MessageBox.Show("Client actualitzat correctament!");
        }

        private void EditarClient_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
