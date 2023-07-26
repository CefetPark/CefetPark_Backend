
using AutoMapper;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Endereco.Post;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Endereco.Get;
using CefetPark.Application.ViewModels.Response.Estacionamento.Get;
using CefetPark.Domain.Entidades;

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
            #endregion

            #region Obter
            CreateMap<Endereco, ObterEnderecoResponse>();
            CreateMap<Estacionamento, ObterEstacionamentoResponse>();
            CreateMap<Departamento, ObterCommonResponse>();
            CreateMap<Marca, ObterCommonResponse>();
            #endregion


        }

    }
}
