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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cs = await _customerService.GetAllAsync();

            //return Ok(categories);
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(cs));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cs = await _customerService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(cs));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto csDto)
        {
            var newCs = await _customerService.AddAsync(_mapper.Map<Customer>(csDto));

            return Created(string.Empty, _mapper.Map<CustomerDto>(newCs));
        }
        [HttpPut]
        public IActionResult Update(CustomerDto csDto)
        {
            if (string.IsNullOrEmpty(csDto.Id.ToString()) || csDto.Id == 0)
            {
                throw new Exception("Id alani zorunludur.");
            }
            _customerService.Update(_mapper.Map<Customer>(csDto));
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var cs = _customerService.GetByIdAsync(id).Result;
            _customerService.Remove(cs);
            return NoContent();
        }

    }
}
