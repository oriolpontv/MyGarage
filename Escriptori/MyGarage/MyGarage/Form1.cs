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
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string usuari = this.textBox1.Text;
            string contrasenya = this.textBox2.Text;

            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT dni_mecanic, contrasenya FROM MECANICS WHERE dni_mecanic = '" + usuari + "' AND contrasenya ='" + contrasenya + "'";
            sqlRd = sqlCmd.ExecuteReader();
            if (sqlRd.Read())
            {
                MessageBox.Show("Accés correcte. Benvingut a MyGarage.");
                Menu menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Accés denegat. Revisa les teves dades.");
                this.textBox1.Clear();
                this.textBox1.Clear();
            }
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyGarage és una aplicació creada per Oriol Pont Valera com a projecte de M13 del CFGS de DAM. L'accés requereix un usuari creat o existent a la BBDD del servidor. Per a més informació sobre l'aplicació, contactar a oriolpv.dam2@alumnescostafreda.cat.");
            Menu menu = new Menu();
        }
    }
}
