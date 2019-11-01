using WebApi.Dominio.Login.v1;
using WebApi.DTO.Login.v1;

namespace WebApi.Interface.Servico.Login.v1
{
    public interface IUsuarioLoginServico
    {
        UsuarioLogin Retorna(UsuarioLogin user);
        UsuarioLogin RetornaLogin(string login);
        void Cadastra(UsuarioLogin login);
        void AlteraSenhaDo(string login, string senha);
    }
}
