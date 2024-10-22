using AutoMapper;
using WebApi.Application.RestaurantOperations.Queries.GetRestaurant;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<Restaurant, GetRestaurantViewModel>();
        }
    }
}