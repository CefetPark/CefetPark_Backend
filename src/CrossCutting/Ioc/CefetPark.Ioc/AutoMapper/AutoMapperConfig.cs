
using AutoMapper;
using CefetPark.Application.ViewModels.Request.Carro.Post;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Convidado.Post;
using CefetPark.Application.ViewModels.Request.Endereco.Post;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Application.ViewModels.Request.FilaEstacionamento.Post;
using CefetPark.Application.ViewModels.Request.Modelo.Post;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Convidado.Get;
using CefetPark.Application.ViewModels.Response.Endereco.Get;
using CefetPark.Application.ViewModels.Response.Estacionamento.Get;
using CefetPark.Application.ViewModels.Response.FilaEstacionamento.Get;
using CefetPark.Application.ViewModels.Response.Modelo.Get;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Models;

namespace CefetPark.Ioc.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region Cadastrar
            CreateMap<CadastrarEstacionamentoRequest, Estacionamento>();
            CreateMap<CadastrarEnderecoRequest, Endereco>();
            CreateMap<CadastrarUsuarioRequest, Usuario>();
            CreateMap<CadastrarCommonRequest, Departamento>();
            CreateMap<CadastrarCommonRequest, Marca>();
            CreateMap<CadastrarCommonRequest, Cor>();
            CreateMap<CadastrarModeloRequest, Modelo>();
            CreateMap<CadastrarCommonRelationRequest, Usuario>();
            CreateMap<CadastrarCarroRequest, Carro>();
            CreateMap<CadastrarRegistroEntradaSaidaRequest, RegistroEntradaSaida>();
            CreateMap<CadastrarConvidadoRequest, Convidado>();
            CreateMap<CadastrarConvidadoCarroRequest, Carro>();
            #endregion

            #region Obter
            CreateMap<Modelo, ObterModeloResponse>();
            CreateMap<Modelo, ObterCommonResponse>();
            CreateMap<Usuario, ObterUsuarioResponse>();
            CreateMap<Carro, ObterCarroResponse>();
            CreateMap<Usuario, ObterCarroUsuarioResponse>();
            CreateMap<Endereco, ObterEnderecoResponse>();
            CreateMap<Estacionamento, ObterEstacionamentoResponse>();
            CreateMap<Departamento, ObterCommonResponse>();
            CreateMap<Marca, ObterCommonResponse>();
            CreateMap<TipoUsuario, ObterCommonResponse>();
            CreateMap<Cor, ObterCommonResponse>();
            CreateMap<RegistroEntradaSaida, ObterRegistroEntradaSaidaSemSaidaResponse>();
            CreateMap<Carro, ObterConvidadoCarroResponse>();
            CreateMap<EntrarFilaEstacionamentoRequest, EntrarFilaEstacionamento>();
            CreateMap<FilaEstacionamento, ObterFilaEstacionamentoResponse>();
            CreateMap<IntegranteFilaEstacionamento, ObterIntegrantesFilaEstacionamentoResponse>();
            CreateMap<Convidado, ObterConvidadoResponse>();
            #endregion


        }

    }
}
