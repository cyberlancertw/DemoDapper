namespace DemoDapper.Models
{
    public interface IFactory<T>
    {
        public IEnumerable<T> GetAll();
        public T GetOne(int id);
        public void Create(T entity);
    }
}
