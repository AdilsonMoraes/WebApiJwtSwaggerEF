using System;
using WebApi.Dominio.Empresas.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.DTO.Empresa.v1;
using WebApi.Enums.Exceptions.Empresa.v1;
using WebApi.Interface.Infraestrutura.Empresas.v1;
using WebApi.Interface.Servico.Empresa.v1;

namespace Webapi.Servico.Empresas.v1.Servico
{
    public class EmpresaServico : IEmpresaServico
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresaServico(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public void Salvar(Empresa empresa)
        {
            var empresaCadastrada = _empresaRepositorio.BuscarPeloCnpjUfNome(empresa.Cnpj, empresa.Uf, empresa.NomeFantasia);

            if (empresaCadastrada != null)
            {
                throw new ErroException(EmpresaEnumException.EMPRESA_JA_CADASTRADA.Codigo.ToString(),
                    EmpresaEnumException.EMPRESA_JA_CADASTRADA.Valor);
            }

            _empresaRepositorio.Salvar(empresa);
        }

        public void Deletar(string cnpj, string uf, string nome)
        {
            var empresaCadastrada = _empresaRepositorio.BuscarPeloCnpjUfNome(cnpj, uf, nome);
            if (empresaCadastrada != null)
            {
                _empresaRepositorio.Deletar(empresaCadastrada);
            }            
        }

        public Empresa BuscarPeloCnpjUfNome(string cnpj, string uf, string nome)
        {

            if(string.IsNullOrWhiteSpace(cnpj) || string.IsNullOrWhiteSpace(cnpj))
            {
                throw new ErroException(EmpresaEnumException.CNPJ_NAO_INFORMADO.Codigo.ToString(),
                    EmpresaEnumException.CNPJ_NAO_INFORMADO.Valor);
            }

            if (string.IsNullOrWhiteSpace(uf) || string.IsNullOrWhiteSpace(uf))
            {
                throw new ErroException(EmpresaEnumException.UF_NAO_INFORMADO.Codigo.ToString(),
                    EmpresaEnumException.UF_NAO_INFORMADO.Valor);
            }

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nome))
            {
                throw new ErroException(EmpresaEnumException.NOME_NAO_INFORMADO.Codigo.ToString(),
                    EmpresaEnumException.NOME_NAO_INFORMADO.Valor);
            }


            var empresaCadastrada = _empresaRepositorio.BuscarPeloCnpjUfNome(cnpj, uf, nome);
            if(empresaCadastrada == null)
            {
                throw new ErroException(EmpresaEnumException.EMPRESA_NAO_ENCONTRADA.Codigo.ToString(),
                    EmpresaEnumException.EMPRESA_NAO_ENCONTRADA.Valor);
            }

            return empresaCadastrada;
        }




    }
}
