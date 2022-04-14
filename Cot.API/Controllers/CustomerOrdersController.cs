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
    public class CustomerOrdersController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;
        private IMapper _mapper;

        public CustomerOrdersController(ICustomerOrderService customerOrderService, IMapper mapper)
        {
            _customerOrderService = customerOrderService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cos = await _customerOrderService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CustomerOrderDto>>(cos));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cos = await _customerOrderService.GetByIdAsync(id);

            return Ok(_mapper.Map<CustomerOrderDto>(cos));
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(CustomerOrderDto cosDto)
        {
            var newCos = await _customerOrderService.AddAsync(_mapper.Map<CustomerOrder>(cosDto));

            return Created(string.Empty, _mapper.Map<CustomerOrderDto>(newCos));
        }
        [HttpPut]
        public IActionResult Update(CustomerOrderDto cosDto)
        {
            if (string.IsNullOrEmpty(cosDto.Id.ToString()) || cosDto.Id == 0)
            {
                throw new Exception("Id alani zorunludur.");
            }
            _customerOrderService.Update(_mapper.Map<CustomerOrder>(cosDto));
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var cos = _customerOrderService.GetByIdAsync(id).Result;
            _customerOrderService.Remove(cos);
            return NoContent();
        }
    }
}
