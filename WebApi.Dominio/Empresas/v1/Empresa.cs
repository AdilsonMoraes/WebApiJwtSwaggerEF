using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.Dominio.Empresas.v1
{
    public class Empresa
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string Uf { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
