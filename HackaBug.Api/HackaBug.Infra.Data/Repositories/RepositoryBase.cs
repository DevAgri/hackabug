using System;
using System.Data.Entity;
using HackaBug.Domain.Interfaces;
using HackaBug.Infra.Data.Context;

namespace HackaBug.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoriesBase<T> where T : class
    {
        public HackabugContext Db = new HackabugContext();
        
        public void Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();
        }

        public void Dell(T obj)
        {
            Db.Entry<T>(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public T GetId(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public System.Collections.Generic.IEnumerable<T> ListAll()
        {
            return Db.Set<T>();
        }

        public void Update(T obj)
        {
            Db.Entry<T>(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}