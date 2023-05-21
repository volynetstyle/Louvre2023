using AutoMapper;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{
    public class BaseService<TModel, TAdapter> : IBasicService<TModel, TAdapter>
        where TAdapter : class
        where TModel : class
    {
        private readonly IMapper _mapper;
        private readonly IBasicRepository<TModel> _repository;

        public BaseService(IMapper mapper, IBasicRepository<TModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add<TnewEnity>(TnewEnity item)
        {
            _repository.Add(_mapper.Map<TModel>(item));
        }

        public void Add(TAdapter item)
        {
            Add<TAdapter>(item);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Delete(TAdapter item)
        {
            _repository.Delete(_mapper.Map<TModel>(item));
        }

        public IEnumerable<TAdapter> Find(Expression<Func<TAdapter, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            return _mapper.Map<IEnumerable<TAdapter>>(_repository.Find(expression));
        }

        public IEnumerable<TAdapter> GetAll()
        {
            return _mapper.Map<IEnumerable<TAdapter>>(_repository.GetAll());
        }

        public async Task<IEnumerable<TAdapter>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TAdapter>>(entities);
        }

        public TAdapter GetById(int id)
        {
            return _mapper.Map<TAdapter>(_repository.GetById(id));
        }

        public IEnumerable<TAdapter> Paginate(int pageNumber, int pageSize)
        {
            return _mapper.Map<IEnumerable<TAdapter>>(_repository.Paginate(pageNumber, pageSize));
        }

        public void Update(TAdapter item)
        {
            _repository.Update(_mapper.Map<TModel>(item));
        }
    }
}
