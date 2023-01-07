using Microsoft.EntityFrameworkCore;
using SportEventApi.Data;
using SportEventApi.Models;

namespace SportEventApi.Services;

public abstract class ServiceBase<T> where T : class, IIdentifiedModel
{
    protected readonly GameContext _context;

    public ServiceBase(GameContext context) => _context = context;

    protected abstract DbSet<T> DataTable { get; }
    public abstract string NavigationPropertyPath { get; }

    public T? Get(Guid id) => 
        NavigationPropertyPath == string.Empty 
            ? DataTable.SingleOrDefault(x => x.Id == id) 
            : DataTable.Include(NavigationPropertyPath).SingleOrDefault(x => x.Id == id);
            
    public T? Read(Guid id) => DataTable.AsNoTracking().SingleOrDefault(x => x.Id == id);
    public IEnumerable<T> ReadAll() => DataTable.AsNoTracking().ToList();

    public virtual void Create(T item)
    {
        DataTable.Add(item);
        _context.SaveChanges();
    }

    public virtual void Update(T item)
    {
        DataTable.Update(item);
        _context.SaveChanges();
    }

    public virtual void Delete(T item)
    {
        DataTable.Remove(item);
        _context.SaveChanges();
    }
}