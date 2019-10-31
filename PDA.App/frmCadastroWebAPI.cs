using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace PDA.MobileApp
{
    public partial class frmCadastroWebAPI : Form
    {
        public frmCadastroWebAPI()
        {
            InitializeComponent();
        }       

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {            
            try
            {
                Uri url = new Uri("http://pda.gear.host/api/aluno/");
                WebRequest request = WebRequest.Create(url);
                var postData = "&nome=" + Uri.EscapeDataString(txtNome.Text);
                postData += "&sobrenome=" + Uri.EscapeDataString(txtSobrenome.Text);
                postData += "&telefone=" + Uri.EscapeDataString(txtTelefone.Text);
                postData += "&ra=" + Uri.EscapeDataString(txtRa.Text);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                MessageBox.Show("Aluno Cadastrado Com Sucesso.");

                txtNome.Text = "";
                txtSobrenome.Text = "";
                txtTelefone.Text = "";
                txtRa.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}