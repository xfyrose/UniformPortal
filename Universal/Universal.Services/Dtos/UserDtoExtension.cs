using Universal.Domains.Models;

namespace Universal.Services.Dtos
{
    public static class UserDtoExtension
    {
        public static User ToEntity(this UserDto dto)
        {
            User result = AutoMapper.Mapper.Map<User>(dto);

            //result.Id = dto.Id.ToString();

            return result;
        }

        public static UserDto ToDto(this User entity)
        {
            UserDto result = AutoMapper.Mapper.Map<UserDto>(entity);

            //result.Id = entity.Id.ToString();

            return result;
        }
    }
}