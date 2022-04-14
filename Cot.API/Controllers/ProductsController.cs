using AutoMapper;
using Cot.API.DTOs;
using Cot.Core.Model;
using Cot.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _proService;
        private IMapper _mapper;

        public ProductsController(IProductService proService, IMapper mapper)
        {
            _proService = proService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pro = await _proService.GetAllAsync();

            //return Ok(categories);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(pro));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pro = await _proService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(pro));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto proDto)
        {
            var newPro = await _proService.AddAsync(_mapper.Map<Product>(proDto));

            //return Created(null, _mapper.Map<CategoryDto>(newCat));
            return Created(string.Empty, _mapper.Map<ProductDto>(newPro));
        }

        [HttpPut]
        public IActionResult Update(ProductDto proDto)
        {
            if (string.IsNullOrEmpty(proDto.Id.ToString()) || proDto.Id == 0)
            {
                throw new Exception("Id alani zorunludur.");
            }
            _proService.Update(_mapper.Map<Product>(proDto));
            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var pro = _proService.GetByIdAsync(id).Result;//asenkron metod yazmadanda asenkron yapilari kullanmak icin sonuna Result ekliyerek asenkron bir metoddan bilgi cekebiliriz.
            _proService.Remove(pro);
            return NoContent();
        }

       
       
    }
}
