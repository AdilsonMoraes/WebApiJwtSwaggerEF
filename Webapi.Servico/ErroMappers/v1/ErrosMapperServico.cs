using System.Collections.Generic;
using WebApi.Dominio.Erro.v1;
using WebApi.Interface.Servico.ErroMapper.v1;

namespace Webapi.Servico.ErroMappers.v1
{
    public class ErrosMapperServico : IErrosMapperServico
    {
        public IEnumerable<Erro> Mapeia(List<string> errors)
        {
            List<Erro> erros = new List<Erro>();

            errors.ForEach(e =>
            {
                var errosSplit = e.Split('|');

                Erro erro = new Erro(errosSplit[0],
                    errosSplit[1]);

                erros.Add(erro);
            });

            return erros;
        }
    }
}
