using System;
using System.Collections.Generic;
using System.Text;

namespace Econobuy_Android.Models
{
    public class Pedido
    {
        public string Mercado { get; internal set; }
        public DateTime Data { get; internal set; }
        public string CEP { get; internal set; }
        public string Cidade { get; internal set; }
        public string Bairro { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Numero { get; internal set; }
        public string Email { get; internal set; }
        public string Telefone_1 { get; internal set; }
        public string Telefone_2 { get; internal set; }
        public string Status { get; internal set; }
        public decimal Valor { get; internal set; }
        public string Msg { get; internal set; }
        public List<Itens> Itens { get; internal set; }
    }
}
