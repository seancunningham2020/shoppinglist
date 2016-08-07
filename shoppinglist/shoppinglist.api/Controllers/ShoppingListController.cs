using shoppinglist.api.Models;
using shoppinglist.api.Repositories;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(shoppingListRepository.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var product = shoppingListRepository.Get(name);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Not Found" });
            }

            return Ok(product);
        }

        // POST: api/ShoppingList
        [HttpPost]
        public IHttpActionResult Post(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return BadRequest(messages);
            }

            var existingProduct = shoppingListRepository.Get(product.Name);
            if (existingProduct != null)
            {
                return BadRequest("This product already exists");
            }

            shoppingListRepository.Add(product);

            var updatedProduct = shoppingListRepository.Get(product.Name);

            return Ok(updatedProduct);
        }

        public IHttpActionResult Put(ProductModel product)
        {
            var existingProduct = shoppingListRepository.Get(product.Name);
            if (existingProduct == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Not Found" });
            }

            shoppingListRepository.Update(product);
            return Ok(new { Message = "Ok" });
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            shoppingListRepository.Delete(name);

            return Ok(new { Message = "Ok" });
        }
    }
}
