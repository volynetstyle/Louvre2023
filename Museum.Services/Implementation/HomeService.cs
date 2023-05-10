using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Interfaces;
using Museum.Models;
using Museum.App.ViewModels.Home;

namespace Museum.App.Services.Implementation.Servises
{
    public class HomeService
    {
        private readonly IMapper _mapper;
        private readonly IBasicRepository<Artists> _repository;
        public HomeService(IMapper mapper, 
                           IBasicRepository<Artists> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

    }
}
