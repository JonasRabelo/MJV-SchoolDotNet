
using Models;

namespace Data.Repository.IRepository
{
    public interface IUsuarioRepository <T> where T : class
    {
        T CreateByName(string name);
        void Update(T entity);
        void Delete(int id);
        T Get(string name);
        T GetById(int id);
    }
}
