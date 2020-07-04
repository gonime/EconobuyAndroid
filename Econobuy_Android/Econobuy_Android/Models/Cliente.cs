using SQLite;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Econobuy_Android.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nome { get; set; }
        [MaxLength(20)]
        public string User { get; set; }
        [MaxLength(20)]
        public string Senha { get; set; }
        [MaxLength(14)]
        public string CPF { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string CEP { get; set; }
        [MaxLength(150)]
        public string Logradouro { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(150)]
        public string Complemento { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(50)]
        public string Cidade { get; set; }
        [MaxLength(3)]
        public string UF { get; set; }
        [MaxLength(15)]
        public string Telefone_1 { get; set; }
        [MaxLength(15)]
        public string Telefone_2 { get; set; }

        public Cliente()
        {

        }
    }
}
