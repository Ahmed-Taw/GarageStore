using AutoMapper;
using Garage.Business.Infrastructure.DTOs;
using Garage.DAL.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Business.AutoMapperProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarEntity, CarDTO>();
            CreateMap<CarEntity, CarDetailsDTO>()
                .ForMember(d => d.Location, opt => opt.MapFrom(s => s.CarLocation.Location))
                .ForMember(d => d.WarehouseName, opt => opt.MapFrom(s => s.CarLocation.Warehouse.Name));

        }
    }
}
