using System.Collections.Generic;
using shoppinglist.api.Models;

namespace shoppinglist.api.Repositories
{
    public interface IShoppingListRepository
    {
        void Add(ProductModel newProduct);

        void Delete(string productName);

        List<ProductModel> Get();

        ProductModel Get(string productName);

        void Update(ProductModel product);
    }
}