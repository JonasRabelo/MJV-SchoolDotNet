using Models;

namespace Data.Repository.IRepository
{
    public interface IJogoRepository<T> where T : class
    {
        bool Create(T entity);
        void UpdateSaldo(T entity);
        bool Delete(int id);
        List<T> GetAll(int id);
        double GetValorDoJogoById(int id);
    }
}
