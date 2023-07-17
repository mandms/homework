namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public void Update(TEntity entity);
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Add(IEnumerable<TEntity> entities);
        public void Remove(TEntity entity);
        public void Remove(IEnumerable<TEntity> entities);
        public TEntity GetById(int id);
        public void SaveChanges();
    }
}
