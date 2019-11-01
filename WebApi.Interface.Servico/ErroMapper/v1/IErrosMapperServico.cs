using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Erro.v1;

namespace WebApi.Interface.Servico.ErroMapper.v1
{
    public interface IErrosMapperServico
    {
        IEnumerable<Erro> Mapeia(List<string> errors);
    }
}
