using System;
using System.Collections.Generic;
using System.Text;
using WebApi.DTO.Fornecedor.v1;

namespace WebApi.Interface.Servico.Fornecedor.v1
{
    public interface IFornecedorServico
    {
        List<Dominio.Fornecedores.v1.Fornecedor> ProcesarConsulta(ConsultaFornecedorDTO dadosConsultaFornecedor);
        void Salvar(FornecedorDTO dadosFornecedor);
    }
}
