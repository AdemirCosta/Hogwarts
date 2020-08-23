using Api.Models.Dtos;
using AutoMapper;
using Core.Entities;

namespace Test.Settings.Factories
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CharacterDto, Character>();
            });

            return config.CreateMapper();
        }
    }
}
