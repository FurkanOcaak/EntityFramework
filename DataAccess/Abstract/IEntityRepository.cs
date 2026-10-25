using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{// class referans tip, IEntity referans tip, IEntity interface implement eden classlar için geçerli olacak
    // new() referans tipin newlenebilir olması için
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);// The filter parameter is optional, allowing retrieval of all entities or filtered results.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
 
    }
}
