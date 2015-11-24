using System.Collections.Generic;

namespace Util.Services
{
    public interface IBatchService<TDto, in TQuery> : IServiceBase<TDto, TQuery> where TDto : new()
    {
        List<TDto> Save(List<TDto> addList, List<TDto> updateList, List<TDto> deleteList);
    }
}