using System.Collections.Generic;
using Universal.Domains.Queries;
using Universal.Services.Dtos;
using Util.Services;

namespace Universal.Services.Contracts
{
    public interface IUserService : IBatchService<UserDto, UserQuery>
    {
        void Export();

        void Enable(List<string> ids);
        void Disable(List<string> ids);
    }
}