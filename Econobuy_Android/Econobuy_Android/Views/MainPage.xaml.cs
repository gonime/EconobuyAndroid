using Econobuy_Android.Models;
using Econobuy_Android.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Econobuy_Android
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void cadastrarBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroCliente());
        }

        private void loginBtn_Clicked(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                User = userEntry.Text,
                Senha = senhaEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Cliente>();
                var UserDetail = conn.Table<Cliente>().Where(x => x.User == cliente.User && x.Senha == cliente.Senha).FirstOrDefault();
                if (UserDetail == null)
                {
                    loginLB.Text = "Usuário ou senha inválidos";
                }
                else
                {
                    App.Current.MainPage = new Home(UserDetail.Id);
                }
            }
        }
    }
}
