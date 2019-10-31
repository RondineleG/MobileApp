using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using PDA.Models;

namespace PDA.MobileApp
{
    public partial class frmCadastroWebService : Form
    {
        public frmCadastroWebService()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {

            Uri url = new Uri("http://localhost:61263/ServiceAluno.svc/Inserir");
           
            Aluno aluno = new Aluno();
            aluno.nome = txtNome.Text;
            aluno.sobrenome = txtSobrenome.Text;
            aluno.telefone = txtTelefone.Text;
            aluno.ra = Convert.ToInt32(txtRa.Text);

            string postData = JsonConvert.SerializeObject(aluno, Formatting.Indented);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
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
    }
}