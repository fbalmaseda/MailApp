using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSalesDesignDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String texto = guna2TextBox1.Text;
            String email = guna2TextBox2.Text;
            string asunto = guna2TextBox3.Text;
            sendMail(email, asunto, texto); 

        }      
    

    public string sendMail(string to, string asunto, string body)
    {
        string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
        string from = "tu_usuario@reduc.edu.cu";
        string displayName = "TU_NOMBRE";
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, displayName);
            mail.To.Add(to);

            mail.Subject = asunto;
            mail.Body = body;
            mail.IsBodyHtml = true;


            SmtpClient client = new SmtpClient("smtp.reduc.edu.cu", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
            client.Credentials = new NetworkCredential(from, "AQUI_PONES_TU_CLAVE");
            client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false
            

            client.Send(mail);
            msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

        }
        catch (Exception ex)
        {
            msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
        }

        return msge;
    }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}