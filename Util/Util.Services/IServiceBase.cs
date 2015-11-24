using System.Collections.Generic;
using Util.Core;
using Util.Domains.Repositories;

namespace Util.Services
{
    public interface IServiceBase<TDto, in TQuery> : IDependency where TDto : new()
    {
        TDto Create();
        TDto Get(object id);
        List<TDto> GetByIds(string ids);
        List<TDto> GetAll();
        PagerList<TDto> Query(TQuery query);
        void Save(TDto dto);
        void Delete(string ids);
    }
}