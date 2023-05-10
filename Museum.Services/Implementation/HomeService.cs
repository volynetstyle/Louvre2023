using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Interfaces;
using Museum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Implementation.Servises
{
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly BaseRepository<ArtistModel> _repository;
        public HomeService(IMapper mapper, BaseRepository<ArtistModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Test()
        {
            var t1 = _repository.GetAll();
        }
    }
}
