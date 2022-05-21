using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace MyGarage
{
    public partial class EnviarMail : Form
    {
        public EnviarMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage("mygarage.dam@gmail.com", this.textBox1.Text, this.textBox3.Text, this.textBox2.Text);
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.UseDefaultCredentials = false;
            NetworkCredential cre = new NetworkCredential("mygarage.dam@gmail.com", "Fat/3232");//your mail password
            sc.EnableSsl = true;
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
            MessageBox.Show("Mail enviat correctament.");
        }
    }
}
