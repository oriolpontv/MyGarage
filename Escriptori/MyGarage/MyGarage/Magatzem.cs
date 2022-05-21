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
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Collections;

namespace MyGarage
{
    public partial class Magatzem : Form
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

        //CONNXIO CLIENTS
        MySqlConnection sqlCon2 = new MySqlConnection();
        MySqlCommand sqlCmd2 = new MySqlCommand();
        DataTable sqlDt2 = new DataTable();
        String sqlQuery2;
        MySqlDataAdapter DtA2 = new MySqlDataAdapter();
        MySqlDataReader sqlRd2;

        DataSet DS2 = new DataSet();

        public Magatzem()
        {
            InitializeComponent();
        }

        private void Magatzem_Load(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM MAGATZEM";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox4.Text) && String.IsNullOrEmpty(textBox5.Text) && String.IsNullOrEmpty(textBox6.Text) && String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Omple les dades pel magatzem primer!!!");
            }
            else
            {
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "INSERT INTO MAGATZEM (id_peça, nom, descripcio, preu, referencia, quantitat, id_proveidor) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "'," + this.textBox6.Text + "," + this.textBox7.Text + ")";
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

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM MAGATZEM";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarMagatzem eliminarMagatzem = new EliminarMagatzem();
            eliminarMagatzem.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditarMagatzem editarMagatzem = new EditarMagatzem();
            editarMagatzem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //OBTENIR DADES DEL CLIENT
            sqlCon2.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon2.Open();
            sqlCmd2.Connection = sqlCon2;
            sqlCmd2.CommandText = "SELECT * FROM MAGATZEM";
            sqlRd2 = sqlCmd2.ExecuteReader();
            sqlDt2.Load(sqlRd2);

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font_bold = new XFont("Verdana", 18, XFontStyle.Bold);
            XFont font_bold_2 = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

            gfx.DrawString("Inventari", font_bold, XBrushes.Black, new XRect(40, 40, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Id", font_bold, XBrushes.Black, new XRect(40, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Nom", font_bold, XBrushes.Black, new XRect(80, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Quantitat", font_bold, XBrushes.Black, new XRect(240, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Referencia", font_bold, XBrushes.Black, new XRect(390, 80, page.Width, page.Height), XStringFormats.TopLeft);

            int x = 120;
            int y1 = 40;
            int y2 = 80;
            int y3 = 280;
            int y4= 390;
            foreach (DataRow row in sqlDt2.Rows)
            {

                String id_peca = row["id_peça"].ToString();
                String nom = row["nom"].ToString();
                String referencia = row["referencia"].ToString();
                String quantitat = row["quantitat"].ToString();


                gfx.DrawString(id_peca, font, XBrushes.Black, new XRect(y1, x, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(nom, font, XBrushes.Black, new XRect(y2, x, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(quantitat + " uds.", font, XBrushes.Black, new XRect(y3, x, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Ref." + referencia, font, XBrushes.Black, new XRect(y4, x, page.Width, page.Height), XStringFormats.TopLeft);

                x += 20;
                //y1 += 20;
                //y2 += 20;
                //y3 += 20;
                //y4 += 20;

            }

            string filename = "inventari_mygarage.pdf";

            document.Save(filename);

            Process.Start(filename);

            sqlRd2.Close();
            sqlCon2.Close();
        }
    }
}
