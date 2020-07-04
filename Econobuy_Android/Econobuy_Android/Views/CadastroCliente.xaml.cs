using Econobuy_Android.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using Econobuy_Android.Repository;
using System.Net.Mail;
using System.Net;

namespace Econobuy_Android.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroCliente : ContentPage
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        void loginBtn_Clicked(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nome = nameEntry.Text,
                User = userEntry.Text,
                Senha = senhaEntry.Text,
                Email = emailEntry.Text,
                CEP = cepEntry.Text,
                CPF = cpfEntry.Text,
                Bairro = bairroEntry.Text,
                Cidade = cidadeEntry.Text,
                Logradouro = logradouroEntry.Text,
                Numero = numeroEntry.Text,
                Complemento = complementoEntry.Text,
                Telefone_1 = tel1Entry.Text,
                Telefone_2 = tel2Entry.Text,
                UF = ufEntry.Text
            };

            if (!checaCamposObrigatorios(cliente))
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Cliente>();
                    conn.Insert(cliente);
                    EnviaEmailCadastro(cliente.Email, cliente.User, cliente.Senha);
                    DisplayAlert("Cadastrado com sucesso!", "Entre com seu usuário!", "OK");
                    Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                DisplayAlert("Preencha todos os campos obrigatórios!", "Campos com (*) são obrigatórios!", "OK");
            }
        }

        private bool checaCamposObrigatorios(Cliente cliente)
        {
            bool var = false;
            if (cliente.Nome == null || cliente.User == null || cliente.Senha == null || cliente.Email == null || cliente.CEP == null || cliente.Cidade == null || cliente.Logradouro == null || cliente.Numero == null || cliente.Telefone_1 == null || cliente.UF == null) return true;
            return var;
        }

        async void cepEntry_TextChangedAsync(object sender, TextChangedEventArgs e)
        {
            if(cepEntry.Text.Length == 9)
            {
                var client = new HttpClient();
                string cep = cepEntry.Text;
                var json = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
                var dados = JsonConvert.DeserializeObject<ConsultaCEP>(json);

                bairroEntry.Text = dados.bairro;
                cidadeEntry.Text = dados.localidade;
                logradouroEntry.Text = dados.lougradouro;
                complementoEntry.Text = dados.complemento;
                ufEntry.Text = dados.uf;
            }
        }

        public void EnviaEmailCadastro(string email, string usuario, string senha)
        {
            try
            {
                string msg = "Seja bem-vindo a Econobuy! \n\n Seguem seus dados de acesso: \n\n Usuario: " + usuario + " \n Senha: " + senha +
                    " \n\n Caso não tenha feito este cadastro apenas ignore este e-mail. \n\n Atenciosamente, \n Equipe Econobuy.";
                MailMessage mensagemEmail = new MailMessage("sistemaeconobuy@gmail.com", email, "Seja bem-vindo a Econobuy!", msg);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sistemaeconobuy@gmail.com", "Nmb159nmb!");
                client.Send(mensagemEmail);
            }
            finally { }
            return;
        }
    }
}