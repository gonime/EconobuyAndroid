using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Econobuy_Android.Models
{
    public class Itens
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal valor_un { get; set; }
        public int Qtde { get; set; }
        public decimal valor_total { get; set; }

        public string img { get; set; }

    }
}
