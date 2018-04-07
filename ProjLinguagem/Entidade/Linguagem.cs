using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Linguagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        public override string ToString()
        {
            return "Id: " + this.Id +
                "\nNome: " + this.Nome +
                "\nDescrição: " + this.Descricao;
        }
    }
}
