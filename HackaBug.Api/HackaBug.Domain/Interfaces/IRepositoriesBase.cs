using System.Collections;
using System.Collections.Generic;

namespace HackaBug.Domain.Interfaces
{
    public interface IRepositoriesBase<T> where T: class 
    {
        T GetId(int id);

        IEnumerable<T> ListAll();

        void Add(T obj);

        void Update(T obj);

        void Dell(T obj);


    }
}