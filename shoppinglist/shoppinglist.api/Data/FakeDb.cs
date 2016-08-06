using shoppinglist.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppinglist.api.Data
{
    public class FakeDb
    {
        private readonly List<ProductModel> productList;

        private static readonly Lazy<FakeDb> Lazy = new Lazy<FakeDb>(() => new FakeDb());

        public static FakeDb Instance => Lazy.Value;

        private FakeDb()
        {
            productList = new List<ProductModel>
                          {
                              new ProductModel
                              {
                                  Id = 1,
                                  Name = "Product 1",
                                  Quantity = 0
                              },
                              new ProductModel
                              {
                                  Id = 2,
                                  Name = "Product 2",
                                  Quantity = 0
                              }
                          };
        }

        public void Add(ProductModel newProduct)
        {
            productList.Add(newProduct);
        }

        public void Update(ProductModel product)
        {
            var existingProduct = productList.Single(x => x.Name == product.Name);
            existingProduct.Quantity = product.Quantity;
        }

        public void Delete(string productName)
        {
            var productToDelete = productList.Single(x => x.Name == productName);
            productList.Remove(productToDelete);
        }

        public ProductModel Get(string productName)
        {
            return productList.Find(x => x.Name == productName);
        }

        public List<ProductModel> Get()
        {
            return productList;
        }
    }
}