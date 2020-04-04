using Academy.Models.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Abstractions
{
    public interface IRepo<T> where T : Audit
    {
        Task<List<T>> GetAll(int count);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> CheckAny(int id);
        Task<T> GetById(string id);
        Task Save(T t, string username);
        void Update(T t, string username);
        Task Delete(int t);
        Task Delete(string t);
        void Delete(T t);
        Task<(bool status, string message)> SaveContext();
    }
}
