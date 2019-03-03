using AutoMapper;
using OneCard.MVC.Models.DTOs;
using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//        public AutoMapperConfig()
//{
//    Mapper.CreateMap<CategoryType, CategoryTypeDto>();
//    Mapper.CreateMap<CategoryTypeDto, CategoryType>();
//}
namespace OneCard.MVC.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void RegisterAutoMapper()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                #region CategoryType
                cfg.CreateMap<CategoryType, CategoryTypeDto>().ReverseMap();
                cfg.CreateMap<CategoryTypeDto, CategoryType>().ReverseMap();
                #endregion
            });
        }


    }
}