using AutoMapper;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{
    public class BaseService<TModel, TAdapter> : IBasicService<TModel, TAdapter>
        where TAdapter : class
        where TModel : class
    {
        private readonly IMapper _mapper;
    private readonly BaseRepository<TModel> _repository;

    public BaseService(IMapper mapper, BaseRepository<TModel> repository)
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
        _repository.Add(_mapper.Map<TModel>(item));
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
        throw new NotImplementedException();
    }

    public IEnumerable<TAdapter> GetAll()
    {
        return _mapper.Map<IEnumerable<TAdapter>>(_repository.GetAll());
    }

    public TAdapter GetById(int id)
    {
        return _mapper.Map<TAdapter>(_repository.GetById(id));
    }

    public IEnumerable<TAdapter> Paginate(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public void Update(TAdapter item)
    {
        _repository.Update(_mapper.Map<TModel>(item));
    }
}
}
