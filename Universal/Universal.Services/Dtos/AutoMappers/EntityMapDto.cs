using Universal.Domains.Models;

namespace Universal.Services.Dtos.AutoMappers
{
    public static class EntityMapDto
    {
        static EntityMapDto()
        {
            AutoMapper.Mapper.CreateMap(typeof(User), typeof(UserDto));
            AutoMapper.Mapper.CreateMap(typeof(UserDto), typeof(User));
        }
    }
}