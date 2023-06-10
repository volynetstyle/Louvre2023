using AutoMapper;
using Museum.App.Services.Attributes;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{
    [Service]
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

        public bool Any(Expression<Func<TAdapter, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            return _repository.Any(expression);
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

        public async Task AddAsync(TAdapter item)
        {
            var entity = _mapper.Map<TModel>(item);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TAdapter item)
        {
            var entity = _mapper.Map<TModel>(item);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TAdapter item)
        {
            var entity = _mapper.Map<TModel>(item);
            await _repository.DeleteAsync(entity);
        }

        public async Task<TAdapter> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TAdapter>(entity);
        }

        public async Task<IEnumerable<TAdapter>> FindAsync(Expression<Func<TAdapter, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            var entities = await _repository.FindAsync(expression);
            return _mapper.Map<IEnumerable<TAdapter>>(entities);
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task<IEnumerable<TAdapter>> PaginateAsync(int pageNumber, int pageSize)
        {
            var entities = await _repository.PaginateAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<TAdapter>>(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TAdapter, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TModel, bool>>>(predicate);
            return await _repository.AnyAsync(expression);
        }

        public int CountBy(Expression<Func<TAdapter, bool>> predicate)
        {
            return _repository.CountBy(_mapper.Map<Expression<Func<TModel, bool>>>(predicate));
        }

        public async Task<int> CountByAsync(Expression<Func<TAdapter, bool>> predicate)
        {
            return await _repository.CountByAsync(_mapper.Map<Expression<Func<TModel, bool>>>(predicate));
        }
    }
}
