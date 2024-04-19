using Business.Abstract;
using Business.Concrate;
using Data_Access.Concrate.EntityFramework;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase  //apı isimleri çoğul verilier
    {
        IProductService _productService;  //loosely coupled
        public ProductsController(IProductService productService)  //Bir bağımlılık var ama soyuta o yüzden her zman değişebilir
        {
            _productService = productService;
        }

        [HttpGet ("GetAll")]
        public IActionResult /*string*/ Get() //Burada alıyoruz
        {//Dependency chain
           
            var result = _productService.GetAll();
            if (result.Success)
            {
              return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpPost("add")]
        public IActionResult /*string*/ Post(Product product) // burada biz gönderiyoruz
        {//Dependency chain

            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet ("GetByID")]
        public IActionResult /*string*/ GetById(int id)
        {//Dependency chain

            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
    }
}
