using System.Linq.Expressions;
using TestTask.Data;

namespace TestTask.Services.Implementations
{
    public class Generic<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private bool disposedValue;

        protected Generic(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
            _context.SaveChanges();
        }
        public T Read(int id)
        {
            return _context.Find<T>(id);
        }

        public IQueryable<T> ReadAll()
        {
            return _context.Set<T>();
        }
        public IQueryable<T> ReadAll(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition);
        }
        public void Update(T Entity)
        {
            _context.Update<T>(Entity);
            _context.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
