using Microsoft.Azure.WebJobs.Host;
using Unity;

namespace Anthill.Common.AzureJob
{
    public class JobActivator : IJobActivator
    {
        private readonly IUnityContainer _container;

        public JobActivator(IUnityContainer container)
        {
            _container = container;
        }

        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
