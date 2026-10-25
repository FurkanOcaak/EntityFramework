using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()//ctor
        {
            _products = new List<Product>{
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Kupa", UnitPrice = 500,UnitsInStock = 3},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Silgi", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Kalem", UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Defter", UnitPrice = 85, UnitsInStock = 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product);// bu şekilde silme yapamayız çünkü referans tiptir. int, string gibi değer tipleri için geçerlidir. Bu yüzden LINQ language integrated query kullanacağız.

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;
            //        break;
            //    }
            //}                           //FirstOrDefault metodu ile de yapabiliriz. Bu metot, koleksiyonun ilk elemanını döndürür. Eğer koleksiyon boşsa, null döndürür.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //LINQ kullanımı. Tek bir eleman döndürür. Eğer birden fazla eleman varsa, hata verir. Eğer hiç eleman yoksa, null döndürür.)
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //Where metodu ile filtreleme yapıyoruz. ToList metodu ile de listeye çeviriyoruz.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
