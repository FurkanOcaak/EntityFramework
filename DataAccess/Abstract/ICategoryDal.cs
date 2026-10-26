using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal: IEntityRepository<Category>// bundan dolayı ICategoryDal interface'i, IEntityRepository<Product> interface'ini implement eder. Bu sayede ICategoryDal interface'i, IEntityRepository<Product> interface'inin tüm metotlarını kullanabilir.
    {
        //List<Category> GetAll();
        //void Add(Category category);
        //void Update(Category category);
        //void Delete(Category category);
        //List<Category> GetAllByCategory(int categoryId);


    }
}
