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
    public partial class EditarReparacio : Form
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

        public EditarReparacio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Indica un ID de reparació.");
            }
            else
            {
                button2.Enabled = true;
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM REPARACIONS WHERE id_reparacio = " + textBox14.Text;
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();
                this.textBox1.Text = sqlDt.Rows[0]["responsable"].ToString();
                this.textBox2.Text = sqlDt.Rows[0]["id_vehicle"].ToString();
                this.textBox3.Text = sqlDt.Rows[0]["id_client"].ToString();
                this.textBox4.Text = sqlDt.Rows[0]["dni_client"].ToString();
                this.textBox5.Text = sqlDt.Rows[0]["descripcio"].ToString();
                this.textBox6.Text = sqlDt.Rows[0]["import"].ToString();
                this.textBox7.Text = sqlDt.Rows[0]["estat"].ToString();
                this.textBox8.Text = sqlDt.Rows[0]["diposit_entrada"].ToString();
                this.textBox9.Text = sqlDt.Rows[0]["kms_entrada"].ToString();
                this.textBox10.Text = sqlDt.Rows[0]["data_entrada"].ToString();
                this.textBox11.Text = sqlDt.Rows[0]["data_sortida"].ToString();
                this.textBox12.Text = sqlDt.Rows[0]["id_factura"].ToString();
                this.textBox13.Text = sqlDt.Rows[0]["id_pressupost"].ToString();
            }
        }

        private void EditarReparacio_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "UPDATE REPARACIONS SET responsable = " + textBox1.Text + ", id_vehicle = " + textBox2.Text + ", id_client = " + textBox3.Text + ", dni_client = '" + textBox4.Text + "', descripcio = '" + textBox5.Text + "', import = '" + textBox6.Text + "', estat = " + textBox7.Text + ", diposit_entrada = '" + textBox8.Text + "', kms_entrada = '" + textBox9.Text + "', id_factura = " + textBox12.Text + ", id_pressupost = " + textBox13.Text + " WHERE id_reparacio = " + textBox14.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            MessageBox.Show("Reparació editada correctament!");
        }
    }
}
