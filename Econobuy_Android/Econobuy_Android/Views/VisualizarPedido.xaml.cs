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
    public partial class VisualizarPedido : ContentPage
    {
        public VisualizarPedido(Pedido ped)
        {
            InitializeComponent();
            preencheCampos(ped);
        }

        public void preencheCampos(Pedido ped)
        {
            lbMercado.Text = ped.Mercado;
            lbData.Text = ped.Data.ToString();
            lbCEP.Text = "CEP: " + ped.CEP;
            lbBairro.Text = "Bairro: " + ped.Bairro;
            lbCidade.Text = "Cidade: " + ped.Cidade;
            lbLogradouro.Text = "Logradouro: " + ped.Logradouro + ", " + ped.Numero;
            lbTel1.Text = "Telefone 1: " + ped.Telefone_1;
            if (ped.Telefone_2 != "") lbTel2.Text = "Telefone 2: " + ped.Telefone_2;
            else lbTel2.IsVisible = false;
            lbStatus.Text = "Status: " + ped.Status;
            lbEmail.Text = "E-mail: " + ped.Email;
            if (ped.Msg != "") lbMsg.Text = "Mensagem: " + ped.Msg;
            else lbMsg.IsVisible = false;
            ListaItens.ItemsSource = ped.Itens;
        }
    }
}