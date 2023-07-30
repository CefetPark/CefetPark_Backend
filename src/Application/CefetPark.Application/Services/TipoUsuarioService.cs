using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ICommonRepository commonRepository, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<TipoUsuario>();

            var response  = _mapper.Map<IEnumerable<ObterCommonResponse>>(entidades);

            return response;
        }
    }
}
