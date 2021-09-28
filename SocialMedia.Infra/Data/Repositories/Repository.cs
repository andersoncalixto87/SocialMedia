using System;
using System.Linq;
using SocialMedia.Core.Interfaces.Repositories;

namespace SocialMedia.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SocialMediaContext _socialMediaContext;
        public Repository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
        public void Add(T obj)
        {
            try
            {
                _socialMediaContext.Set<T>().Add(obj);
                _socialMediaContext.SaveChanges();
            }
            catch (Exception ex )
            {                
                throw ex;
            }
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            return _socialMediaContext.Set<T>().ToList(); 
        }

        public T GetById(int Id)
        {
            return _socialMediaContext.Set<T>().Find(Id); 
        }

        public void Remove(T obj)
        {
            try
            {
                _socialMediaContext.Set<T>().Remove(obj);
                _socialMediaContext.SaveChanges();
            }
            catch (Exception ex )
            {                
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                _socialMediaContext.Set<T>().Update(obj);
                _socialMediaContext.SaveChanges();
            }
            catch (Exception ex )
            {                
                throw ex;
            }
        }
    }
}