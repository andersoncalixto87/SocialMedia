using System.Collections.Generic;

namespace SocialMedia.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
         void Add(T obj);
         void Update(T obj);
         void Remove(T obj);
         IEnumerable<T> GetAll();
         T GetById(int Id);
    }
}