using AutoMapper;
using Cot.API.DTOs;
using Cot.Core.Model;

namespace Cot.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<CustomerOrder, CustomerOrderDto>();
            CreateMap<CustomerOrderDto, CustomerOrder>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            
        }

    }
}
