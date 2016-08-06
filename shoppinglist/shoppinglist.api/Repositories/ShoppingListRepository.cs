using shoppinglist.api.Data;
using shoppinglist.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace shoppinglist.api.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly FakeDb fakeDb = FakeDb.Instance;
        
        public List<ProductModel> Get()
        {
            return fakeDb.Get().ToList();
        }

        public ProductModel Get(string productName)
        {
            return fakeDb.Get(productName);
        }

        public void Add(ProductModel newProduct)
        {
            fakeDb.Add(newProduct);
        }

        public void Update(ProductModel product)
        {
            fakeDb.Update(product);
        }

        public void Delete(string productName)
        {
            fakeDb.Delete(productName);
        }
    }
}