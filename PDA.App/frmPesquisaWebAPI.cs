using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using PDA;
using PDA.Models;

namespace PDA.MobileApp
{
    public partial class frmPesquisaWebAPI : Form
    {
        public frmPesquisaWebAPI()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscaId.Text == string.Empty)
            {
                MessageBox.Show("Digite o ID pra efetuar a pesquisa", "ATENCAO", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                txtBuscaId.BackColor = Color.Red;
                txtBuscaId.Focus();
                return;
            }
                        try
            {
                string id = txtBuscaId.Text;
                Uri url = new Uri("http://pda.gear.host/api/aluno/Recuperar/" + id);
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                var resposta = request.GetResponse();
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var aluno = JsonConvert.DeserializeObject<Aluno>(objResponse.ToString());
                var json = JsonConvert.SerializeObject(aluno, Formatting.Indented);

                txtId.Text = Convert.ToString(aluno.id);
                txtNome.Text = aluno.nome;
                txtSobrenome.Text = aluno.sobrenome;
                txtTelefone.Text = aluno.telefone;
                txtRa.Text = Convert.ToString(aluno.ra);
                MessageBox.Show("Dados Recebidos Com Sucesso !!!");

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            if ((txtBuscaId.TextLength) <= 0)
            {
                MessageBox.Show("Para Atualizar e preciso de um ID", "ATENCAO", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                txtBuscaId.BackColor = Color.Red;
                txtBuscaId.Focus();
                return;
            }

            try
            {
                string id = txtBuscaId.Text;
                var postData = "&nome=" + Uri.EscapeDataString(txtNome.Text);
                postData += "&sobrenome=" + Uri.EscapeDataString(txtSobrenome.Text);
                postData += "&telefone=" + Uri.EscapeDataString(txtTelefone.Text);
                postData += "&ra=" + Uri.EscapeDataString(txtRa.Text);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://pda.gear.host/api/aluno/" + id);
                var data = Encoding.ASCII.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] arr = encoding.GetBytes(postData);
                request.Method = "PUT";
                request.KeepAlive = true;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(arr, 0, arr.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString();
                dataStream.Close();

                MessageBox.Show("Dados Atualizados Com Sucesso  " + returnString);


                txtBuscaId.Text = "";
                txtId.Text = "";
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

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            var cadastro = new frmCadastroWebAPI();
            cadastro.Show();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
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
            Uri url = new Uri("http://pda.gear.host/api/aluno/" + id);

            try
            {

                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir esse aluno ?", "ATENCAO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    request.Method = "DELETE";

                    response = (HttpWebResponse)request.GetResponse();

                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    Console.Write(sr.ReadToEnd());

                    MessageBox.Show("Aluno Excluido Com Sucesso !!!");

                    txtBuscaId.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


      }

    }
