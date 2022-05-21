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
    public partial class EditarMagatzem : Form
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

        public EditarMagatzem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indica un ID de peça.");
            }
            else
            {
                button2.Enabled = true;
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM MAGATZEM WHERE id_peça = " + textBox1.Text;
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();
                this.textBox2.Text = sqlDt.Rows[0]["nom"].ToString();
                this.textBox3.Text = sqlDt.Rows[0]["descripcio"].ToString();
                this.textBox4.Text = sqlDt.Rows[0]["preu"].ToString();
                this.textBox5.Text = sqlDt.Rows[0]["referencia"].ToString();
                this.textBox6.Text = sqlDt.Rows[0]["quantitat"].ToString();
                this.textBox7.Text = sqlDt.Rows[0]["id_proveidor"].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "UPDATE MAGATZEM SET nom = '" + textBox2.Text + "', descripcio = '" + textBox3.Text + "', preu = '" + textBox4.Text + "', referencia = '" + textBox5.Text + "', quantitat = " + textBox6.Text + ", id_proveidor = " + textBox7.Text + " WHERE id_peça = " + textBox1.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            MessageBox.Show("Peça actualitzada correctament!");
        }

        private void EditarMagatzem_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
