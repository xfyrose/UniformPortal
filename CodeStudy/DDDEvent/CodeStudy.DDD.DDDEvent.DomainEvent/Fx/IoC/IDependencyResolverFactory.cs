namespace DomainEvent.Fx.IoC
{
    /// <summary>
    /// IDependencyResolverFactory
    /// </summary>
    public interface IDependencyResolverFactory : IDependency
    {
        /// <summary>
        /// Create Instance
        /// </summary>
        /// <returns></returns>
        IDependencyResolver CreateInstance();
    }
}