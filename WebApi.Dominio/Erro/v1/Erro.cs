using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Dominio.Erro.v1
{
    public class Erro
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public Erro()
        {

        }

        public Erro(string codigo, string descricao)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
        }
    }
}
