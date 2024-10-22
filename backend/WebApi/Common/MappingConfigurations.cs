using AutoMapper;
using WebApi.Application.RestaurantOperations.Commands.CreateRestaurant;
using WebApi.Application.RestaurantOperations.Commands.UpdateRestaurant;
using WebApi.Application.RestaurantOperations.Queries.GetRestaurant;
using WebApi.Application.RestaurantOperations.Queries.GetRestaurantDetails;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<Restaurant, GetRestaurantViewModel>();
            CreateMap<Restaurant, GetRestaurantDetailViewModel>()
            .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables.Select(
                t => new RestaurantTablesViewModel
                {
                    Id = t.Id,
                    Capacity = t.Capacity,
                    IsAvailable = t.IsAvailable,
                    TableType = t.TableType
                }
            )));

            CreateMap<CreateRestaurantViewModel, Restaurant>();
            CreateMap<UpdateRestaurantViewModel, Restaurant>();

        }
    }
}