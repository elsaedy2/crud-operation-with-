using ErpApi.Data;

using ErpApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _context.categories.OrderBy(x => x.Name).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
          var result=_context.categories.FirstOrDefault(x=>x.Id==id);
            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Category model)
        {

            try
            {
                _context.categories.Add(model);
                _context.SaveChanges();
                return Ok(model);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

       
        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Category model)
        {
            var result=_context.categories.FirstOrDefault(x=>x.Id == id);
            if(result != null)
            {
                result.Name = model.Name;
                _context.categories.Update(result);
                _context.SaveChanges();
                return Ok(result);
            }
            return BadRequest();
            



            
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id , Category model)
        {
            var result = _context.categories.FirstOrDefault(x => x.Id == id);

            if(result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
                return Ok(result);
            }
            return BadRequest();    
              
         
         
        }
    }
}
