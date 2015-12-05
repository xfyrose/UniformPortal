using Universal.Domains.Models;
using Universal.Domains.Queries;
using Universal.Services.Contracts;
using Universal.Services.Dtos;

namespace Universal.Services.Implementation
{
    public class UserService : BatchService<User, UserDto, UserQuery>, IUserService
    {
         
    }
}