namespace DomainEvent.Fx.Bootstrapper
{
    /// <summary>
    /// 启动器任务接口
    /// </summary>
    public interface IBootstrapperTask
    {
        /// <summary>
        /// 执行启动器任务
        /// </summary>
        void Execute();
    }
}