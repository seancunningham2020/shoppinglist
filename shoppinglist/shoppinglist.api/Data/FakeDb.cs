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
            productList = new List<ProductModel>();
        }

        public void Add(ProductModel newProduct)
        {
            productList.Add(newProduct);
        }

        public void Update(ProductModel product)
        {
            var existingProduct = FindExistingProduct(product.Name);
            existingProduct.Quantity = product.Quantity;
        }

        public void Delete(string productName)
        {
            var productToDelete = FindExistingProduct(productName);
            productList.Remove(productToDelete);
        }

        public ProductModel Get(string productName)
        {
            return FindExistingProduct(productName);
        }

        public List<ProductModel> Get()
        {
            return productList;
        }

        private ProductModel FindExistingProduct(string productName)
        {
            return productList.FirstOrDefault(x => x.Name == productName);
        }
    }
}