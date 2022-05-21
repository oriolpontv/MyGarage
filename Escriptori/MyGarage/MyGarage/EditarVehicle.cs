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
    public partial class EditarVehicle : Form
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

        public EditarVehicle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indica un ID de vehicle.");
            }
            else
            {
                button2.Enabled = true;
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM VEHICLES WHERE id_vehicle = " + textBox1.Text;
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();
                this.textBox2.Text = sqlDt.Rows[0]["marca"].ToString();
                this.textBox3.Text = sqlDt.Rows[0]["model"].ToString();
                this.textBox4.Text = sqlDt.Rows[0]["any"].ToString();
                this.textBox5.Text = sqlDt.Rows[0]["combustible"].ToString();
                this.textBox6.Text = sqlDt.Rows[0]["motor"].ToString();
                this.textBox7.Text = sqlDt.Rows[0]["etiqueta"].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "UPDATE VEHICLES SET marca = '" + textBox2.Text + "', model = '" + textBox3.Text + "', any = '" + textBox4.Text + "', combustible = '" + textBox5.Text + "', motor = '" + textBox6.Text + "', etiqueta = '" + textBox7.Text + "' WHERE id_vehicle = " + textBox1.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            MessageBox.Show("Client actualitzat correctament!");
        }

        private void EditarVehicle_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
