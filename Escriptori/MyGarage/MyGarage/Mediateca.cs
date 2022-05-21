using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyGarage
{
    public partial class Mediateca : Form
    {

        List<string> listFiles = new List<string>();
        public Mediateca()
        {
            InitializeComponent();
        }

        private void Mediateca_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id_pressupost = textBox1.Text;

            WebRequest request2 = WebRequest.Create("http://192.168.1.30/mygarage/images/pressupost_" + id_pressupost + "/imatge_frontal_pressupost_" + id_pressupost + ".jpg");
            WebResponse response2 = request2.GetResponse();
            Stream stream2 = response2.GetResponseStream();
            pictureBox2.Image = Bitmap.FromStream(stream2);

            WebRequest request3 = WebRequest.Create("http://192.168.1.30/mygarage/images/pressupost_" + id_pressupost + "/imatge_lateral_pressupost_" + id_pressupost + ".jpg");
            WebResponse response3 = request3.GetResponse();
            Stream stream3 = response3.GetResponseStream();
            pictureBox3.Image = Bitmap.FromStream(stream3);

            WebRequest request4 = WebRequest.Create("http://192.168.1.30/mygarage/images/pressupost_" + id_pressupost + "/imatge_revers_pressupost_" + id_pressupost + ".jpg");
            WebResponse response4 = request4.GetResponse();
            Stream stream4 = response4.GetResponseStream();
            pictureBox4.Image = Bitmap.FromStream(stream4);

            WebRequest request5 = WebRequest.Create("http://192.168.1.30/mygarage/images/pressupost_" + id_pressupost + "/imatge_lateral2_pressupost_" + id_pressupost + ".jpg");
            WebResponse response5 = request5.GetResponse();
            Stream stream5 = response5.GetResponseStream();
            pictureBox5.Image = Bitmap.FromStream(stream5);
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
