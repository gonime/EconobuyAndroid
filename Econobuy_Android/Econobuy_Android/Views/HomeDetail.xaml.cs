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
    public partial class HomeDetail : ContentPage
    {
        public HomeDetail(string nome)
        {
            InitializeComponent();
            lbHome.Text = lbHome.Text + " " + nome.ToString() + "!";
        }
    }
}