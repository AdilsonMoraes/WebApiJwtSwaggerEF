using Moq;
using WebApi.Dominio.Login.v1;
using WebApi.Interface.Infraestrutura.Login.v1;
using WebApi.Interface.Servico.Login.v1;

namespace Webapi.Teste
{
    public class TesteInclusaoUsuario
    {
        private Mock<IUsuarioLoginServico> usuarioLoginServico;
        private Mock<IUsuarioLoginRepositorio> usuarioLoginRepositorio;

        public TesteInclusaoUsuario()
        {
            usuarioLoginServico = new Mock<IUsuarioLoginServico>();
            usuarioLoginRepositorio = new Mock<IUsuarioLoginRepositorio>();

            var user = new UsuarioLogin()
            {
                Usuario = "Adilson",
                Senha = "teste123",
                IsAdministrator = true,
                TokenAuth = ""
            };


            usuarioLoginServico.Setup(t => t.Cadastra(user)).Returns(true);
        }





    }
}
