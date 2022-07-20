
using Microsoft.Azure.WebJobs.Host;
using Unity;
using Unity.Lifetime;

namespace Anthill.Common.AzureJob
{
    public class ContainerConfiguration
    {

        public static void RegisterTypes<TLifetime>(IUnityContainer container)
            where TLifetime : LifetimeManager, new()
        {
            container.RegisterType<IJobActivator, JobActivator>();
        }
    }
}
