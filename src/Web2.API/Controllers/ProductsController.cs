using Microsoft.AspNetCore.Mvc;
using Web2.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product{ Id = 1, Name = "Iphone X"},
            new Product{ Id = 2, Name = "Google Pixel 8"},
            new Product{ Id = 3, Name = "Samsung galaxy s10"}
        };
        
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = products.Find(x => x.Id == id);

            return product == null ? NotFound() : Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var newProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };

            products.Add(newProduct);

            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }

            return NoContent();
        }
    }
}
