using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Dominio.Login.v1
{
    public class UsuarioLogin
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool IsAdministrator { get; set; }
        public string TokenAuth { get; set; }
    }
}
