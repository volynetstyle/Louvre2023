using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Interfaces;
using Museum.Models;
using Museum.App.ViewModels.Home;
using System.Linq.Expressions;

namespace Museum.App.Services.Implementation.Servises
{
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly IBasicRepository<Artists> _repository;
        public HomeService(IMapper mapper, 
                           IBasicRepository<Artists> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add(HomeViewModel item)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(HomeViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HomeViewModel> Find(Expression<Func<HomeViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HomeViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public HomeViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HomeViewModel> Paginate(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(HomeViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
