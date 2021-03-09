using NextForms.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NextForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            id.Visible = false;
            this.endid.Visible = false;


            Desaparecer();

        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            FimCadastro.Visible = false;
            this.nome.Clear();
            Bloquear();
            //this.textBox2.AppendText(this.textBox1.Text);
            RestClient restClient = new RestClient(string.Format("https://localhost:44332/api/DadosPessoais/PesquisarCpf?cpf=" + this.textBox1.Text));
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.ContentLength != -1 || restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                MessageBox.Show("Não encontrado ");
            }
            else
            {
                try
                {
                    Aparecer();
                    DadosPessoais dados = new JsonDeserializer().Deserialize<DadosPessoais>(restResponse);
                    id.Text = dados.Id.ToString();
                    nome.Text = dados.Nome;
                    cpf.Text = dados.CPF;
                    dtnasc.Text = dados.DataNascimento;
                    email.Text = dados.Email;
                    tel.Text = dados.Telefone;
                    senha.Text = dados.Senha;
                    endid.Text = dados.EnderecosResidencialId.ToString();
                    cep.Text = dados.EnderecosResidencial.CEP;
                    logradouro.Text = dados.EnderecosResidencial.Logradouro;
                    num.Text = dados.EnderecosResidencial.Numero;
                    bairro.Text = dados.EnderecosResidencial.Bairro;
                    cidade.Text = dados.EnderecosResidencial.Cidade;
                    uf.Text = dados.EnderecosResidencial.UF;
                    complemento.Text = dados.EnderecosResidencial.Complemento;
                    this.id.Visible = false;
                    this.endid.Visible = false;
                }
                catch
                {
                    Desaparecer();
                    MessageBox.Show("Não encontrado ");
                }

            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Pesquisar.Enabled = true;
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            DadosPessoais dados = new DadosPessoais();
            dados.Id = int.Parse(id.Text);
            dados.Nome = nome.Text;
            dados.CPF = cpf.Text;
            dados.DataNascimento = dtnasc.Text;
            dados.Email = email.Text;
            dados.Telefone = tel.Text;
            dados.Senha = senha.Text;
            dados.EnderecosResidencialId = int.Parse(endid.Text);
            dados.EnderecosResidencial.Id= int.Parse(endid.Text);
            dados.EnderecosResidencial.CEP = cep.Text;
            dados.EnderecosResidencial.Logradouro = logradouro.Text;
            dados.EnderecosResidencial.Numero = num.Text;
            dados.EnderecosResidencial.Bairro = bairro.Text;
            dados.EnderecosResidencial.Cidade = cidade.Text;
            dados.EnderecosResidencial.UF = uf.Text;
            dados.EnderecosResidencial.Complemento = complemento.Text;

            try
            {
                if (dados.CPF != "")
                {
                    Client.PUT("https://localhost:44332/api/DadosPessoais/" + dados.Id, dados.Id.ToString(), dados, null);
                    ApagarConteudo();
                    MessageBox.Show("Alterado com sucesso!");
                }
            }
            catch
            {
                Desaparecer();
                MessageBox.Show("Erro ao salvar ");
            }

        }
        

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            Aparecer();
            Salvar.Visible = false;
            Editar.Visible = false;
            Deletar.Visible = false;
            //this.textBox2.AppendText(this.textBox1.Text);


            DadosPessoais dados = new DadosPessoais();

            dados.Nome = nome.Text;
            dados.CPF = cpf.Text;
            dados.DataNascimento = dtnasc.Text;
            dados.Email = email.Text;
            dados.Telefone = tel.Text;
            dados.Senha = senha.Text;
 
            dados.EnderecosResidencial.CEP = cep.Text;
            dados.EnderecosResidencial.Logradouro = logradouro.Text;
            dados.EnderecosResidencial.Numero = num.Text;
            dados.EnderecosResidencial.Bairro = bairro.Text;
            dados.EnderecosResidencial.Cidade = cidade.Text;
            dados.EnderecosResidencial.UF = uf.Text;
            dados.EnderecosResidencial.Complemento = complemento.Text;
                
            try
            {
                if(dados.CPF != "" ) {

                    Client.POST("https://localhost:44332/api/", "DadosPessoais", dados, null);
                    ApagarConteudo();
                    MessageBox.Show("Salvo com sucesso!");
                }

            }
            catch
            {
                Desaparecer();
                MessageBox.Show("Erro ao salvar ");
            }

        }
        private void Deletar_Click(object sender, EventArgs e)
        {
            DadosPessoais dados = new DadosPessoais();
            dados.Id = int.Parse(id.Text);

            try
            {
                if (dados.Id.ToString() != "")
                {
                    Client.DELETE("https://localhost:44332/api/DadosPessoais/" + dados.Id, dados.Id.ToString(), null);
                    ApagarConteudo();
                    MessageBox.Show("Deletado com sucesso!");
                }
            }
            catch
            {
                Desaparecer();
                MessageBox.Show("Erro ao salvar ");
            }
        }

        private void FimCadastro_Click(object sender, EventArgs e)
        {
            Cadastrar_Click(sender, e);
        }

        private void ApagarConteudo()
        {
            nome.Clear();
            cpf.Clear();
            email.Clear();
            dtnasc.Clear();
            tel.Clear();
            senha.Clear();
            cep.Clear();
            logradouro.Clear();
            email.Clear();
            num.Clear();
            bairro.Clear();
            cidade.Clear();
            uf.Clear();
            complemento.Clear();

        }
        private void Aparecer()
        {
            nome.Visible = true;
            cpf.Visible = true;
            email.Visible = true;
            dtnasc.Visible = true;
            tel.Visible = true;
            senha.Visible = true;
            cep.Visible = true;
            logradouro.Visible = true;
            email.Visible = true;
            num.Visible = true;
            bairro.Visible = true;
            cidade.Visible = true;
            uf.Visible = true;
            complemento.Visible = true;

            nometext.Visible = true;
            cpftext.Visible = true;
            emailtext.Visible = true;
            dttext.Visible = true;
            teltext.Visible = true;
            senhatext.Visible = true;
            ceptext.Visible = true;
            logratext.Visible = true;
            emailtext.Visible = true;
            numtext.Visible = true;
            bairrotext.Visible = true;
            cidadetext.Visible = true;
            uftext.Visible = true;
            completext.Visible = true;

            Salvar.Visible = true;
            Editar.Visible = true;
            Deletar.Visible = true;
            Cadastrar.Visible = true;
            FimCadastro.Visible = true;
        }
        private void Desaparecer()
        {
            nome.Visible = false;
            cpf.Visible = false;
            email.Visible = false;
            dtnasc.Visible = false;
            tel.Visible = false;
            senha.Visible = false;
            cep.Visible = false;
            logradouro.Visible = false;
            email.Visible = false;
            num.Visible = false;
            bairro.Visible = false;
            cidade.Visible = false;
            uf.Visible = false;
            complemento.Visible = false;

            nometext.Visible = false;
            cpftext.Visible = false;
            emailtext.Visible = false;
            dttext.Visible = false;
            teltext.Visible = false;
            senhatext.Visible = false;
            ceptext.Visible = false;
            logratext.Visible = false;
            emailtext.Visible = false;
            numtext.Visible = false;
            bairrotext.Visible = false;
            cidadetext.Visible = false;
            uftext.Visible = false;
            completext.Visible = false;

            Salvar.Visible = false;
            Editar.Visible = false;
            Deletar.Visible = false;
            FimCadastro.Visible = false;
        }

        private void Bloquear()
        {
            nome.Enabled = false;
            cpf.Enabled = false;
            email.Enabled = false;
            dtnasc.Enabled = false;
            tel.Enabled = false;
            senha.Enabled = false;
            cep.Enabled = false;
            logradouro.Enabled = false;
            email.Enabled = false;
            num.Enabled = false;
            bairro.Enabled = false;
            cidade.Enabled = false;
            uf.Enabled = false;
            complemento.Enabled = false;

        }
        private void Desbloaquear()
        {
            nome.Enabled = true;
            cpf.Enabled = true;
            email.Enabled = true;
            dtnasc.Enabled = true;
            tel.Enabled = true;
            senha.Enabled = true;
            cep.Enabled = true;
            logradouro.Enabled = true;
            email.Enabled = true;
            num.Enabled = true;
            bairro.Enabled = true;
            cidade.Enabled = true;
            uf.Enabled = true;
            complemento.Enabled = true;

        }

        private void Editar_Click(object sender, EventArgs e)
        {
            Desbloaquear();
        }

        
    }
}
