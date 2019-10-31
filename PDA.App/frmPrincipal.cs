using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using PDA.Models;

namespace PDA.MobileApp
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((txtBuscaId.TextLength) <= 0)
            {
                MessageBox.Show("Digite o ID pra efetuar a pesquisa", "ATENCAO", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                txtBuscaId.BackColor = Color.Red;
                txtBuscaId.Focus();
                return;
            }
            if (rdbWebApi.Checked == true)
            { 
            try
            {
                var id = txtBuscaId.Text;          

                Uri url = new Uri("http://pda.gear.host/api/aluno/recuperar/" + id);
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                var resposta = request.GetResponse();
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var aluno = JsonConvert.DeserializeObject<Aluno>(objResponse.ToString());
                var json = JsonConvert.SerializeObject(aluno, Formatting.Indented);
                txtBuscaId.BackColor = Color.White;
                lblTexto.Text = json;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            }
            else if (rdbWebService.Checked == true) 
            {
                try
                {
                    string id = txtBuscaId.Text;
                    Uri url = new Uri("http://localhost:61263/ServiceAluno.svc/RecuperarPorId/" + id);
                    WebRequest request = WebRequest.Create(url);
                    request.Method = "GET";
                    request.ContentType = "application/json; charset=utf-8";
                    var resposta = request.GetResponse();
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    var aluno = JsonConvert.DeserializeObject<Aluno>(objResponse.ToString());
                    var json = JsonConvert.SerializeObject(aluno, Formatting.Indented);
                    txtBuscaId.BackColor = Color.White;
                    lblTexto.Text = json;                  


                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            
            }

        }

        private void btnFormulario_Click(object sender, EventArgs e)
        {
            var form = new frmPesquisaWebAPI();
            form.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWcf_Click(object sender, EventArgs e)
        {
            var cadastro = new frmPesquisaWebService();
            cadastro.Show();
        }

        
    }
}

   