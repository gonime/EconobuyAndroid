using Econobuy_Android.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econobuy_Android.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : MasterDetailPage
    {
        public Home(int id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Cliente>();
                var nome = conn.Table<Cliente>().Where(x => x.Id == id).Select(x => x.Nome).FirstOrDefault();
                Detail = new NavigationPage(new HomeDetail(nome));
            }
        }

        private void btPedidos_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ConsultarPedidos());
            IsPresented = false;
        }

        private void btLogout_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}