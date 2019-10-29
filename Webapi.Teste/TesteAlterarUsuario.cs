using Moq;
using WebApi.Dominio.Login.v1;
using WebApi.Interface.Infraestrutura.Login.v1;
using WebApi.Interface.Servico.Login.v1;

namespace Webapi.Teste
{
    public class TesteAlterarUsuario
    {
        private Mock<IUsuarioLoginServico> usuarioLoginServico;
        private Mock<IUsuarioLoginRepositorio> usuarioLoginRepositorio;

        public TesteAlterarUsuario()
        {
            usuarioLoginServico = new Mock<IUsuarioLoginServico>();
            usuarioLoginRepositorio = new Mock<IUsuarioLoginRepositorio>();

            var user = new UsuarioLogin()
            {
                Usuario = "Adilson",
                Senha = "adilson",
                IsAdministrator = true,
                TokenAuth = ""
            };


            usuarioLoginServico.Setup(t => t.AlteraSenhaDo(user)).Returns(true);
        }





    }
}
