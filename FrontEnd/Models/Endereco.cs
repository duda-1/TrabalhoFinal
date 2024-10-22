using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Num { get; set; }
        public int ClienteId { get; set; }  

        public override string ToString()
        {
            return $"Id: {Id} - Nome Cliente: {ClienteId} - Nome Cidade: {Cidade} - Nome Rua: {Rua} - Nome Bairro: {Bairro} - Nº: {Num} ";
        }
    }
}
