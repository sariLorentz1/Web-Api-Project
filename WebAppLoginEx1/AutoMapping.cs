using AutoMapper;
using DTO;
using entities;

namespace WebAppLoginEx1
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>().ReverseMap(); ;
            CreateMap<Order, OrderDTO>().ReverseMap(); ;
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
