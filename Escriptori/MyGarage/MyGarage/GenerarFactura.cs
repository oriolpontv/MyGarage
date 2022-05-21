using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Collections;

namespace MyGarage
{
    public partial class GenerarFactura : Form
    {
        //CONNXIO CLIENTS
        MySqlConnection sqlCon = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;

        //CONNEXIO VEHICLES
        MySqlConnection sqlCon2 = new MySqlConnection();
        MySqlCommand sqlCmd2 = new MySqlCommand();
        DataTable sqlDt2 = new DataTable();
        String sqlQuery2;
        MySqlDataAdapter DtA2 = new MySqlDataAdapter();
        MySqlDataReader sqlRd2;

        //CONNEXIO PRESSUPOSTOS
        MySqlConnection sqlCon3 = new MySqlConnection();
        MySqlCommand sqlCmd3 = new MySqlCommand();
        DataTable sqlDt3 = new DataTable();
        String sqlQuery3;
        MySqlDataAdapter DtA3 = new MySqlDataAdapter();
        MySqlDataReader sqlRd3;

        DataSet DS = new DataSet();

        String server = "192.168.1.30";
        String database = "mygarage";
        String username = "admindb";
        String password = "Fat/3232";

        public GenerarFactura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OBTENIR DADES DEL CLIENT
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM CLIENTS WHERE id_client = " + textBox1.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            String nom = sqlDt.Rows[0]["nom"].ToString();
            String cognoms = sqlDt.Rows[0]["cognoms"].ToString();
            String dni = sqlDt.Rows[0]["dni"].ToString();
            String adreça = sqlDt.Rows[0]["adreça"].ToString();
            String telefon = sqlDt.Rows[0]["telefon"].ToString();
            String id_vehicle = sqlDt.Rows[0]["id_vehicle"].ToString();
            String tipus = sqlDt.Rows[0]["tipus"].ToString();
            String matricula = sqlDt.Rows[0]["ref_client"].ToString();

            //OBTENIR DADES DEL VEHICLE
            sqlCon2.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon2.Open();
            sqlCmd2.Connection = sqlCon2;
            sqlCmd2.CommandText = "SELECT * FROM VEHICLES WHERE id_vehicle = " + textBox1.Text;
            sqlRd2 = sqlCmd2.ExecuteReader();
            sqlDt2.Load(sqlRd2);
            sqlRd2.Close();
            sqlCon2.Close();
            String marca = sqlDt2.Rows[0]["marca"].ToString();
            String model = sqlDt2.Rows[0]["model"].ToString();
            String any = sqlDt2.Rows[0]["any"].ToString();
            String combustible = sqlDt2.Rows[0]["combustible"].ToString();
            String motor = sqlDt2.Rows[0]["motor"].ToString();

            //OBTENIR DADES REPARACIONS
            sqlCon3.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon3.Open();
            sqlCmd3.Connection = sqlCon3;
            sqlCmd3.CommandText = "SELECT descripcio, import FROM REPARACIONS WHERE id_vehicle = " + textBox1.Text;
            sqlRd3 = sqlCmd3.ExecuteReader();
            sqlDt3.Load(sqlRd3);

            PdfDocument document = new PdfDocument();
            
            PdfPage page = document.AddPage();
            
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font_bold = new XFont("Verdana", 18, XFontStyle.Bold);
            XFont font_bold_2 = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

            XImage img = XImage.FromFile(@"D:/DAM/PROJECTE FINAL/LOGO-PDF.png");
            gfx.DrawImage(img, 30, 40);

            //gfx.DrawString("MyGarage", font_bold, XBrushes.Black, new XRect(40, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Ctra. Tarragona s/n", font, XBrushes.Black, new XRect(40, 100, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Tel. 973 500 000", font, XBrushes.Black, new XRect(40, 120, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("info@mygarage.com", font, XBrushes.Black, new XRect(40, 140, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Dades del client", font_bold, XBrushes.Black, new XRect(40, 180, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Nom: "+nom, font, XBrushes.Black, new XRect(40, 220, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Cognoms: "+cognoms, font, XBrushes.Black, new XRect(40, 240, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("DNI: "+dni, font, XBrushes.Black, new XRect(40, 260, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Adreça: "+adreça, font, XBrushes.Black, new XRect(40, 280, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Telèfon: "+telefon, font, XBrushes.Black, new XRect(40, 300, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("ID Vehicle: " + id_vehicle, font, XBrushes.Black, new XRect(40, 320, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Client: " + tipus, font, XBrushes.Black, new XRect(40, 340, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Matrícula: " + matricula, font, XBrushes.Black, new XRect(40, 360, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Dades del vehicle", font_bold, XBrushes.Black, new XRect(300, 180, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Marca: " + marca, font, XBrushes.Black, new XRect(300, 220, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Model: " + model, font, XBrushes.Black, new XRect(300, 240, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Any: " + any, font, XBrushes.Black, new XRect(300, 260, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Combustible: " + combustible, font, XBrushes.Black, new XRect(300, 280, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Motor: " + motor, font, XBrushes.Black, new XRect(300, 300, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Resum reparació", font_bold, XBrushes.Black, new XRect(40, 400, page.Width, page.Height), XStringFormats.TopLeft);

            int x = 440;
            int y = 440;
            int valor_import = 0;

            foreach (DataRow row in sqlDt3.Rows)
            {

                String descripcio = row["descripcio"].ToString();
                String import_previ = row["import"].ToString();

                int import = int.Parse(import_previ);

                gfx.DrawString(descripcio, font, XBrushes.Black, new XRect(40, x, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(import + "€", font, XBrushes.Black, new XRect(500, y, page.Width, page.Height), XStringFormats.TopLeft);

                x += 20;
                y += 20;
                valor_import += import;

            }

            gfx.DrawString("Base imposable", font_bold_2, XBrushes.Black, new XRect(350, 700, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(valor_import + "€", font, XBrushes.Black, new XRect(500, 700, page.Width, page.Height), XStringFormats.TopLeft);

            double iva = (valor_import*1.21) - valor_import;

            gfx.DrawString("IVA(21%)", font_bold_2, XBrushes.Black, new XRect(350, 720, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString((float)iva + "€", font, XBrushes.Black, new XRect(500, 720, page.Width, page.Height), XStringFormats.TopLeft);

            double total_iva = iva + valor_import; 

            gfx.DrawString("Total", font_bold_2, XBrushes.Black, new XRect(350, 740, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(total_iva + "€", font, XBrushes.Black, new XRect(500, 740, page.Width, page.Height), XStringFormats.TopLeft);

            string filename = "pressupost_" + dni + "_1.pdf";
            
            document.Save(filename);
            
            Process.Start(filename);

            sqlRd3.Close();
            sqlCon3.Close();
        }
    }
}
