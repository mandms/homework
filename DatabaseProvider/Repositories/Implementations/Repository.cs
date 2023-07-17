using DatabaseProvider.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> Entities { get; }
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
