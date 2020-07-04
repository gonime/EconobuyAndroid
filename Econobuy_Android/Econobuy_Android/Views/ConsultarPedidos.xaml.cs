using Econobuy_Android.Models;
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
    public partial class ConsultarPedidos : ContentPage
    {
        public ConsultarPedidos()
        {
            InitializeComponent();
            preenchePedidos();
        }

        public void preenchePedidos()
        {
            var lista = new List<Pedido>();
            var itens = new List<Itens>();
            itens.Add(new Itens() {Nome = "Arroz Branco Camil 5kg", valor_un = 9.00M, Qtde = 2, valor_total = 18.00M, img = "arroz.jpg" });
            itens.Add(new Itens() { Nome = "Sabonete Dove", valor_un = 2.00M, Qtde = 10, valor_total = 20.00M, img = "sabonete.jpg" });
            itens.Add(new Itens() { Nome = "Barra de chocolate Nestle", valor_un = 5.00M, Qtde = 2, valor_total = 10.00M, img = "choc.jpg" });
            lista.Add(new Pedido() { Mercado = "Mercado Diego e Bruna", Data = DateTime.Now, CEP = "12940-580", Cidade = "Atibaia", Bairro = "Centro", 
                Logradouro = "Avenida 9 de julho", Numero = "580", Email = "mereconobuy@yahoo.com", Telefone_1 = "(11)95085-7388", Telefone_2 = "", Status = "Aguardando",  Valor = 48.00M, Msg = "", Itens = itens });
            itens = new List<Itens>();
            itens.Add(new Itens() { Nome = "Arroz Branco Camil 5kg", valor_un = 9.00M, Qtde = 2, valor_total = 18.00M, img = "arroz.jpg" });
            itens.Add(new Itens() { Nome = "Sabonete Dove", valor_un = 2.00M, Qtde = 10, valor_total = 20.00M, img = "sabonete.jpg" });
            itens.Add(new Itens() { Nome = "Barra de chocolate Nestle", valor_un = 5.00M, Qtde = 2, valor_total = 10.00M, img = "choc.jpg" });
            lista.Add(new Pedido()
            {
                Mercado = "Mercado Souza e Bueno",
                Data = DateTime.Now,
                CEP = "12940-580",
                Cidade = "Atibaia",
                Bairro = "Centro",
                Logradouro = "Avenida Major Juvenal Alvim",
                Numero = "580",
                Email = "mereconobuy@yahoo.com",
                Telefone_1 = "(11)95085-7388",
                Telefone_2 = "",
                Status = "Aprovado",
                Valor = 48.00M,
                Msg = "",
                Itens = itens
            }); 
            itens = new List<Itens>();
            itens.Add(new Itens() { Nome = "Arroz Branco Camil 5kg", valor_un = 9, Qtde = 2, valor_total = 18, img = "arroz.jpg" });
            itens.Add(new Itens() { Nome = "Sabonete Dove", valor_un = 2, Qtde = 10, valor_total = 20, img = "sabonete.jpg" });
            itens.Add(new Itens() { Nome = "Barra de chocolate Nestle", valor_un = 5, Qtde = 2, valor_total = 10, img = "choc.jpg" });
            lista.Add(new Pedido()
            {
                Mercado = "Mercado Convém",
                Data = DateTime.Now,
                CEP = "12947-002",
                Cidade = "Atibaia",
                Bairro = "Vila Helena",
                Logradouro = "Alameda Prof. Lucas Nogueira Garcez",
                Numero = "580",
                Email = "mereconobuy@yahoo.com",
                Telefone_1 = "(11)95085-7388",
                Telefone_2 = "",
                Status = "Reprovado",
                Valor = 48,
                Msg = "Estamos sem estoque dos produtos solicitados",
                Itens = itens
            });
            ListaPedidos.ItemsSource = lista;
        }

        private void ListaPedidos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Pedido ped = (Pedido)ListaPedidos.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new VisualizarPedido(ped));
        }
    }
}