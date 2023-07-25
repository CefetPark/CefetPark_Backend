using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;

namespace CefetPark.Application.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EstacionamentoService(ICommonRepository commonRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CadastrarAsync(CadastrarEstacionamentoRequest request)
        {
            var entidade = _mapper.Map<Estacionamento>(request);


            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
