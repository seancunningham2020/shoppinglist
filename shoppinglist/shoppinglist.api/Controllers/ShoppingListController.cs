using shoppinglist.api.Models;
using shoppinglist.api.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace shoppinglist.api.Controllers
{
    public class ShoppingListController : ApiController
    {
        public readonly IShoppingListRepository shoppingListRepository;

        public ShoppingListController()
        {

        }

        public ShoppingListController(IShoppingListRepository shoppingListRepository)
        {
            this.shoppingListRepository = shoppingListRepository;
        }
        
        // GET: api/ShoppingList
        public IEnumerable<ProductModel> Get()
        {
            return shoppingListRepository.Get();
        }

        // GET: api/ShoppingList/Name
        public ProductModel Get(string name)
        {
            return shoppingListRepository.Get(name);
        }

        // POST: api/ShoppingList
        public void Post(ProductModel product)
        {
            shoppingListRepository.Add(product);
        }

        // PUT: api/ShoppingList/5
        public void Put(ProductModel product)
        {
            shoppingListRepository.Update(product);
        }

        // DELETE: api/ShoppingList/5
        public void Delete(string name)
        {
            shoppingListRepository.Delete(name);
        }
    }
}
