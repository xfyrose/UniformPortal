using System;

namespace Util.Services
{
    public interface IDto<T>
    {
        T Id { get; set; }
    }

    public interface IDto : IDto<Guid>
    {
    }
}