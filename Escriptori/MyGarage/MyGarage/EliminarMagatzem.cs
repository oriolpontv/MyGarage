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
    public partial class EliminarMagatzem : Form
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

        public EliminarMagatzem()
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
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "DELETE FROM MAGATZEM WHERE id_peça = " + this.textBox1.Text;
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();
                MessageBox.Show("Peça eliminada correctament!");
                this.textBox1.Clear();
                this.Close();
            }
        }
    }
}
