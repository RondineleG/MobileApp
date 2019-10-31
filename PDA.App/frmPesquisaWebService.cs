using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using PDA.Models;
using System.Runtime.Serialization.Json;
using System.Text;


namespace PDA.MobileApp
{
    public partial class frmPesquisaWebService : Form
    {
        public frmPesquisaWebService()
        {
            InitializeComponent();
        }      

        private void btnBuscar_Click_1(object sender, EventArgs e)
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
                //lblTexto.Text = json;

                txtId.Text = Convert.ToString(aluno.id);
                txtNome.Text = aluno.nome;
                txtSobrenome.Text = aluno.sobrenome;
                txtTelefone.Text = aluno.telefone;
                txtRa.Text = Convert.ToString(aluno.ra);
                txtBuscaId.BackColor = Color.White;
                MessageBox.Show("Dados Recebidos Com Sucesso !!!");


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnAtualiza_Click_1(object sender, EventArgs e)
        {
            HttpWebResponse response = null;
        if ((txtBuscaId.TextLength) <= 0)
        {
            MessageBox.Show("Para Atualizar e preciso de um ID", "ATENCAO", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            txtBuscaId.BackColor = Color.Red;
            txtBuscaId.Focus();
            return;
        }
        Uri url = new Uri("http://localhost:61263/ServiceAluno.svc/Atualizar");

        Aluno aluno = new Aluno();
        aluno.id = Convert.ToInt32(txtId.Text);
        aluno.nome = txtNome.Text;
        aluno.sobrenome = txtSobrenome.Text;
        aluno.telefone = txtTelefone.Text;
        aluno.ra = Convert.ToInt32(txtRa.Text);


        string postData = JsonConvert.SerializeObject(aluno);
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.Method = "PUT";
        webRequest.KeepAlive = true;
        webRequest.ContentType = "application/json";
        webRequest.ContentLength = postData.Length;
        try
        {
            using (StreamWriter requestWriter2 = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter2.Write(postData);
            }

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                // dumps the HTML from the response into a string variable
                postData = responseReader.ReadToEnd();
            }


            MessageBox.Show("Dados Cadastrados Com Sucesso");

            txtNome.Text = "";
            txtSobrenome.Text = "";
            txtTelefone.Text = "";
            txtRa.Text = "";

        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }

       
        }

        private void btnCadastro_Click_1(object sender, EventArgs e)
        {
            var cadastro = new frmCadastroWebService();
            cadastro.ShowDialog();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            HttpWebResponse response = null;
            string id = txtBuscaId.Text;
            if (txtBuscaId.Text == string.Empty)
            {
                MessageBox.Show("Digite o ID pra efetuar a Exclusao", "ATENCAO", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                txtBuscaId.BackColor = Color.Red;
                txtBuscaId.Focus();
                return;
            }
            Uri url = new Uri("http://localhost:61263/ServiceAluno.svc/Deletar/" + id);

            try
            {

                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir esse aluno ?", "ATENCAO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    request.Method = "DELETE";
                    response = (HttpWebResponse)request.GetResponse();

                    MessageBox.Show("Aluno Excluido Com Sucesso !!!");

                    txtBuscaId.Text = "";
                    txtNome.Text = "";
                    txtSobrenome.Text = "";
                    txtTelefone.Text = "";
                    txtRa.Text = "";
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    Console.Write("Errorcode: {0}", (int)response.StatusCode);
                }
                else
                {
                    Console.Write("Error: {0}", ex.Status);
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }
    }
}