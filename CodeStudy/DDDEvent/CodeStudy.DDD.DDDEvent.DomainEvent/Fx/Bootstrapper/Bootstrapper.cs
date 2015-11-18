using DomainEvent.Fx.IoC;
using System;

namespace DomainEvent.Fx.Bootstrapper
{
    /// <summary>
    /// 启动器基类
    /// </summary>
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            try
            {
                InversionOfControl.InitializeWith(new DependencyResolverFactory());
            }
            catch (ArgumentException ex)
            {
                // Config file is Missing
                var e = new ArgumentException("启动器配置文件丢失导致异常", ex);
                throw new ArgumentException("启动器发生异常", e);
            }
        }

        /// <summary>
        /// 执行启动器
        /// </summary>
        public static void Run()
        {
            InversionOfControl.ResolveAll<IBootstrapperTask>().Do(task => task.Execute());
        }
    }
}