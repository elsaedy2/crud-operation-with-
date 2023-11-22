using ErpApi.Data;
using ErpApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ProductsController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult GetAll( )
        {
            try
            {
                var result = _context.products.Include(x => x.Category).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id )
        {
            try
            {
                var result = _context.products.Include(x=>x.Category).OrderBy(x=>x.Name).FirstOrDefault(x => x.Id == id);
              return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost ("Add")]
        public IActionResult Add([FromBody] Product product)
        {
            try
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Product product)
        {
            var result = _context.products.Include(x=>x.Category).FirstOrDefault(x => x.Id == id);
           if(result != null)
            {
                result.Name = product.Name;
                result.price = product.price;
                result.CategoryId = product.CategoryId;
                result.quntaity = product.quntaity;
                result.Total = product.Total;
                // _context.products.Update(result);
                _context.SaveChanges();
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _context.products.Include(x=>x.Category).FirstOrDefault(x=>x.Id == id);
            if(result != null)
            {
                _context.products.Remove(result);
                _context.SaveChanges();
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
